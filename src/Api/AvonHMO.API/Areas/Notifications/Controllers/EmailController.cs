using AvonHMO.API.Extensions;
using AvonHMO.API.Filters;
using AvonHMO.API.Helpers;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Notifications;
using AvonHMO.Domain.Interfaces;
using BrightStar.Util.Storage.RepoManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace AvonHMO.API.Areas.Notifications.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    [APIKeyAuth]
    public class EmailController : ControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMemoryCache _memoryCache;
        private readonly IRepositoryManager _service;
        private readonly IStorageRepoManager _storageService;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public ILogger<EmailController> Logger { get; }
        public IConfiguration Configuration { get; }
        public EmailController(ILogger<EmailController> logger, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor, IMemoryCache memoryCache, IRepositoryManager service, IStorageRepoManager storageService, IConfiguration config, IWebHostEnvironment env)
        {
            Logger = logger;
            Configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
            _memoryCache = memoryCache;
            _service = service;
            _storageService = storageService;
            _config = config;
            _env = env;
        }


        /// <summary>
        /// Send email
        /// </summary>
        /// <remarks>
        /// Request body:  FormData => var formData =new FormData(); formData.Append("title","somevalue"); etc
        ///     
        ///     {
        ///         requestReference:string,
        ///         recipientEmailAddress:string,
        ///         addressesToCopy:[ string ],
        ///         addressesToBlindCopy:[ string ],
        ///         mailBody:string,
        ///         messageTitle:string,
        ///         hasAttachment:false,
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns response object</response>

        [HttpPost("email"), DisableRequestSizeLimitAttribute]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ResponseDTO))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SendEmail([FromForm] EmailRequestDTO requestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                var request = await Request.ReadFormAsync();
            try
            {
                string userId = httpContextAccessor.HttpContext.LoggedInUserId() ?? throw new InvalidOperationException("Unable to retrieve API Caller information");


                var emailLog = new EmailViewModel() 
                { 
                    RecipientEmailAddress = requestDTO.RecipientEmailAddress,
                    RequestReference= requestDTO.RequestReference,
                    MailBody= requestDTO.MailBody,
                    MessageTitle= requestDTO.MessageTitle,
                    HasAttachment= requestDTO.HasAttachment,
                };

                emailLog.UserId = userId;

                if (requestDTO.AddressesToCopy.Count > 0)
                {
                    foreach (var item in requestDTO.AddressesToCopy)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            emailLog.RecipientEmailAddress = string.Concat(emailLog.RecipientEmailAddress, $",{item}");
                        }
                    }

                }
                if (requestDTO.AddressesToBlindCopy.Count > 0)
                {
                    foreach (var item in requestDTO.AddressesToBlindCopy)
                    {
                        if (!string.IsNullOrWhiteSpace(item))
                        {
                            emailLog.RecipientEmailAddress = string.Concat(emailLog.RecipientEmailAddress, $",{item}");
                        }
                    }
                }
                var settings = FetchSettings();
                string sender = settings.fromEmail;

                MailMessage message = new MailMessage(sender,
                    requestDTO.RecipientEmailAddress);


                var templateName = "generalTemp";

                var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                var templateResult = templateBuilder.BuildTemplate(new MailTemplateModel()
                {
                    MailBody = requestDTO.MailBody
                });

               
                message.Subject = requestDTO.MessageTitle;
                message.IsBodyHtml = true;
                message.Body = templateResult;
                if (requestDTO.AddressesToCopy.Count > 0)
                {
                    foreach (var item in requestDTO.AddressesToCopy)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            message.CC.Add(item);
                        }
                    }
                }
                if (requestDTO.AddressesToBlindCopy.Count > 0)
                {
                    foreach (var item in requestDTO.AddressesToBlindCopy)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            message.Bcc.Add(item);
                        }
                    }
                }
                var filenames = new List<string>();
                if (request != null && request.Files.Any())
                {
                    emailLog.HasAttachment = true;
                    foreach (var file in request.Files)
                    {
                        filenames.Add(file.FileName);

                        message.Attachments.Add(new Attachment(file.OpenReadStream(),
                        file.FileName,
                       file.ContentType));
                    }
                    emailLog.AttachmentFileName = string.Join(";", filenames);
                }
                if (await _service.Settings.IsDuplicateRequest(requestDTO.RequestReference))
                {
                    return Conflict(new ResponseDTO()
                    {
                        responseCode = "01",
                        message = $"Duplicate Request, Request with Refrence {requestDTO.RequestReference} already exist"
                    });
                    ;
                }
                //Log to db.
                var logId = _service.Settings.AddEmailLog(emailLog);


                using (SmtpClient client = new SmtpClient())

                {
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = settings.enableSSL;
                    client.Host = settings.smtpClient;
                    client.Port = settings.serverPort;
                    client.Credentials = new NetworkCredential(sender, settings.password);

                    try
                    {
                        client.Send(message);
                        Logger.LogInformation($"Email successfully sent for the request {requestDTO}");

                        //update Log

                        emailLog.SendDateAndTime = DateTime.Now;
                        emailLog.SendStatus = "Sent successfully";
                        emailLog.SendSuccessfully = true;
                        emailLog.EmailLogId = logId;
                        _service.Settings.UpdateEmailLog(emailLog);

                        try
                        {
                            var fileUri = new List<string>();
                            if (request != null && request.Files.Any())
                            {
                                var storageContainer = _config.GetSection("Azure:AzureStorageContainer").Value;
                                foreach (var file in request.Files)
                                {
                                    filenames.Add(file.FileName);
                                    var uploadResponse = await _storageService.AzureStorage.UploadAsync(file, storageContainer);
                                    if (uploadResponse != null)
                                    {
                                        fileUri.Add(uploadResponse.fileUri);
                                    }

                                }
                                if (fileUri.Any())
                                {

                                    emailLog.AttachmentFileUrl = string.Join(";", fileUri); 
                                    _service.Settings.UpdateEmailLog(emailLog);
                                }
                            }
                        }
                        catch
                        {

                        }

                        return Ok(new ResponseDTO() { responseCode = "00", message = "Success" });
                    }
                    catch 
                    {
                        emailLog.SendDateAndTime = DateTime.Now;
                        emailLog.SendStatus = "Send failed";
                        emailLog.SendSuccessfully = false;
                        emailLog.EmailLogId = logId;
                        _service.Settings.UpdateEmailLog(emailLog);

                        throw;
                    }

                    return Ok();
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"An error occured while sending the email for the request {requestDTO}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        ///<summary>
        ///All email logs for Login user 
        ///</summary>
        [HttpGet("email/user")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<EmailViewModel>>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEmailLogForUser()
        {
            var log = await _service.Settings.GetEmailLogForUser(HttpContext.LoggedInUserId());

            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<List<EmailViewModel>>
                  {
                      Data = log,
                      Message = "",
                      StatusCode = 200
                  });
        }

        ///<summary>
        ///All Email Log 
        ///</summary>
        [HttpGet("email")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<EmailViewModel>>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task< IActionResult> GetEmailLog()
        {
            var log =await _service.Settings.GetEmailLog();

            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<List<EmailViewModel>>
                  {
                      Data = log,
                      Message = "",
                      StatusCode = 200
                  });
        }

        ///<summary>
        ///Email Log By Id
        ///</summary>
        ///<param name="id"></param>

        [HttpGet("email/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<EmailViewModel>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEmailLog([FromQuery] Guid id)
        {
            var log = await _service.Settings.GetEmailLogById(id);

            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<EmailViewModel>
                  {
                      Data = log,
                      Message = "",
                      StatusCode = 200
                  });
        }
        public class EmailSettings
        {
            public string smtpClient { get; set; }
            public string fromEmail { get; set; }
            public int serverPort { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public bool enableSSL { get; set; }
            public string fromDisplayName { get; set; }
        }
        private EmailSettings FetchSettings()
        {
            EmailSettings settings = null;

            if (_memoryCache.TryGetValue("EmailSettingKey", out settings))
            {
                return settings;
            }


            var smtpHost = _service.Settings.GetSetting("SMTP_HOST");
            var smtpUsername = _service.Settings.GetSetting("SMTP_USERNAME");
            var smtpPassword = _service.Settings.GetSetting("SMTP_PASSWORD");
            var smtpPort = int.Parse(_service.Settings.GetSetting("SMTP_PORT"));
            var enableSsl = bool.Parse(_service.Settings.GetSetting("SMTP_ENABLE_SSL"));
            var fromDisplayName = _service.Settings.GetSetting("FROM_DISPLAY_NAME");
            var fromEmail = _service.Settings.GetSetting("FROM_EMAIL");

            settings = new EmailSettings()
            {
                enableSSL = enableSsl,
                fromEmail = fromEmail,
                password = smtpPassword,
                serverPort = smtpPort,
                smtpClient = smtpHost,
                fromDisplayName = fromDisplayName,
                username = smtpUsername
            };

            // Set cache options
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromDays(1));

            // Set object in cache
            _memoryCache.Set("EmailSettingKey", settings, cacheOptions);

            return settings;
        }
        private class MailTemplateModel
        {
            public string MailBody { get; set; }
        }
    }
}
