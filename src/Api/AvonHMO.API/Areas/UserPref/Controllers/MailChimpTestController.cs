using AvonHMO.API.Filters;
using AvonHMO.API.Helpers;
using AvonHMO.Communications;
using AvonHMO.Domain.Interfaces;
using BrightStar.Util.Storage;
using BrightStar.Util.Storage.RepoManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace AvonHMO.API.Areas.UserPref.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    public class MailChimpTestController : ControllerBase
    {

        private readonly IRepositoryManager _service;
        private readonly IEmailService _emailService;
        private readonly IStorageRepoManager _storageService;
        private readonly IConfiguration _config;
        public MailChimpTestController(IRepositoryManager service, IEmailService emailService, IStorageRepoManager storageService, IConfiguration config)
        {
            _service = service;
            _emailService = emailService;
            _storageService = storageService;
            _config = config;
        }

        [HttpGet("mailchimp/test")]
        public async Task<IActionResult> SendMail()
        {
            //C:\iRmas\ErrorLog\2022322
            //Stream fs = System.IO.File.OpenRead(@"C:\iRmas\ErrorLog\2022322\Log.txt");
            // var fileName = "Log.txt";

            var isValidImage = "Log.png".IsImage();

            var storageContainer = _config.GetSection("Azure:AzureStorageContainer").Value;

            try
            {
                var uploadResponse = await _storageService.AzureStorage.UploadAsync(@"C:\iRmas\ErrorLog\2022322\Log.txt", storageContainer);
            }
            catch (System.Exception ex)
            {

                throw;
            }

           

          //  _emailService.Send("Mailchimp", "mark2kk@gmail.com", "Another test from mailchimp", fs, fileName, "callcenter@avonhealthcare.com");

            return StatusCode(StatusCodes.Status200OK, "Mailchimp test sent");

            //var smtpHost = _service.Settings.GetSetting("SMTP_HOST");
            //var smtpUsername = _service.Settings.GetSetting("SMTP_USERNAME");
            //var smptPassword = _service.Settings.GetSetting("SMTP_PASSWORD");
            //var smtpPort = int.Parse(_service.Settings.GetSetting("SMTP_PORT"));
            //var enableSsl = bool.Parse(_service.Settings.GetSetting("SMTP_ENABLE_SSL"));

            //var smtpMail =new SMTPMailService(smtpHost,
            //    smtpUsername, smtpPort, smtpUsername, smptPassword, enableSsl);


            //try
            //{
            //    var messageSent = smtpMail.Send("Test Mail", "omark@simplexsystem.com", "<p>This is just a test mail</p>");

            //    return StatusCode(StatusCodes.Status200OK, messageSent);
            //}
            //catch (System.Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}




        }

    }
}
