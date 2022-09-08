using AvonHMO.API.Filters;
using AvonHMO.API.Helpers;
using AvonHMO.API.Models.EmailTemplateTokens;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.Application.ViewModels.Avon.Communication;
using AvonHMO.Common;
using AvonHMO.Domain.Interfaces;
using AvonHMO.Domain.Services.Toshfa;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AvonHMO.API.Areas.Communications
{

    public class ProviderClassesMaps
    {
        public int classCode { get; set; }

        public string className { get; set; }
    }

    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    [APIKeyAuth]
    public class CommunicationController : ControllerBase
    {

        private readonly IRepositoryManager _repo;
        IWebHostEnvironment _env;
        IEmailService _emailService;
        public CommunicationController(IRepositoryManager authRepo, IWebHostEnvironment env, IEmailService emailService)
        {
            this._repo = authRepo;
            _env = env;
            _emailService = emailService;
        }

        private List<ProviderClassesMaps> FetchProviderMaps()
        {
            return new List<ProviderClassesMaps>
            {
                new ProviderClassesMaps{ classCode =1, className="INTERNATIONAL"},
                new ProviderClassesMaps{ classCode =2, className="PRESTIGE"},
                new ProviderClassesMaps{ classCode =3, className="PREMIUM"},
                new ProviderClassesMaps{ classCode =4, className="PLUS"},
                new ProviderClassesMaps{ classCode =5, className="NHIS"},
                new ProviderClassesMaps{ classCode =6, className="BASIC"}
            };
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Route("communication/emailTest")]
        public IActionResult Index()
        {
            var sendersEmail = _repo.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);

            var copyMails = $"mark@brightstar.ng;tunde@brightstar.ng;kemi@brightstar.ng";

            // var sendersName = _repo.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);
            var templateResult = $"<p>Hi,</p><p>This is a test email. Just to confirm if there is an issue with {sendersEmail} receiving emails </p>";

            _emailService.Send("Test flight Email", sendersEmail, templateResult, null, null, sendersEmail, copyMails);


            return Ok();

        }



        [HttpPost]
        [Route("communication/contactus/email")]
        public IActionResult ContactUsMail([FromBody] ContactUsEmailViewModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object> { Data = null, Message = "Bad Request" });

            var errorMessages = ExceptionHelper.ModelRequiredFieldValidation<ContactUsEmailViewModel>(model);

            if (errorMessages.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessages)
                    });

            if (!model.senderEmail.IsEmailAddress())
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "A valid email address is required"
                   });

            var templateName = "contact_us";

            var templateBuilder = new EmailTemplateBuilder(_env, templateName);

            var templateResult = templateBuilder.BuildTemplate(new ContactUsEmailToken()
            {
                senderName = model.senderName,
                message = model.message,
                email = model.senderEmail
            });

            var contactUsEmail = _repo.Settings.GetSetting(AvonConstants.Settings.EMAIL_US);

            //var sendersName = _repo.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

            //var apiKey = _repo.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);

            // var emailSender = new SendGridNotification(model.senderName, model.senderEmail, apiKey);

            // var emailResponse = await emailSender.SendEmailMailAsync(model.subject, contactUsEmail, templateResult);

            _emailService.Send(model.subject, contactUsEmail, templateResult, null, null, contactUsEmail);


            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<UserModel>
                { Data = null, hasError = false, Message = "Thank you for getting in touch with us. Your message has been received" });
        }
    }
}
