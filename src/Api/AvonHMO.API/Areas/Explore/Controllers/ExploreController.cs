using AvonHMO.API.Contracts;
using AvonHMO.API.Controllers;
using AvonHMO.API.Extensions;
using AvonHMO.API.Filters;
using AvonHMO.API.Helpers;
using AvonHMO.API.Models;
using AvonHMO.API.Models.EmailTemplateTokens;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.Application.ViewModels.Avon.Communication;
using AvonHMO.Application.ViewModels.Avon.Explore;
using AvonHMO.Application.ViewModels.Avon.Plan;
using AvonHMO.Common;
using AvonHMO.Communications.Sendgrid;
using AvonHMO.Domain.Interfaces;
using AvonHMO.Domain.Interfaces.Avon;
using AvonHMO.Entities;
using BrightStar.Util.Storage.RepoManager;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvonHMO.API.Areas.Explore.Controllers
{


    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    [APIKeyAuth]
    public class ExploreController : ControllerBase
    {
        private readonly IRepositoryManager _service;
        private readonly IStorageRepoManager _storageService;
        private readonly IConfiguration _config;
        IWebHostEnvironment _env;
        IEmailService _emailService;


        public ExploreController(IRepositoryManager service, IStorageRepoManager storageService, IConfiguration config, IWebHostEnvironment env, IEmailService emailService)
        {
            _service = service;
            _storageService = storageService;
            _config = config;
            _env = env;
            _emailService = emailService;
        }
        /// <summary>
        /// This endpoint Create Partner Brokers
        /// </summary>
        /// <param name="brokerModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.ExploreAvon.PostPartnerBroker)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostPartnerBroker([FromBody] PartnerBrokerViewModel brokerModel)
        {

            if (brokerModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<PartnerBrokerViewModel>(brokerModel);


            if (errorMessage.Any())
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessage)
                    });

            if (!brokerModel.Email.IsEmailAddress())
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "A valid email address is required"
                   });


            var createResult = await _service.Avon.CreatePartnerBroker(brokerModel);

            if (createResult)
            {



                var templateName = "partner_network";
                var templateNameAvon = "partner_network_broker_avon";
                var emailSubject = "Partner Broker Request";
                var emailSubjectAvon = $"{brokerModel.FirstName} {brokerModel.Surname} Sign-up request for Partner Broker";

                var templateBuilder = new EmailTemplateBuilder(_env, templateName);
                var templateBuilderAvon = new EmailTemplateBuilder(_env, templateNameAvon);

                var templateResult = templateBuilder.BuildTemplate(new ProviderNetworkEmailToken()
                {
                    title = brokerModel.Title,
                    firstName = brokerModel.FirstName,
                    surName = brokerModel.Surname,
                    phoneNumber = brokerModel.PhoneNumber,
                    email = brokerModel.Email,
                    companyName = brokerModel.CompanyName,
                    message = brokerModel.Message,
                    requestType = "Partner Broker"

                });
                var templateResultAvon = templateBuilderAvon.BuildTemplate(new ProviderNetworkEmailToken()
                {
                    title = brokerModel.Title,
                    firstName = brokerModel.FirstName,
                    surName = brokerModel.Surname,
                    phoneNumber = brokerModel.PhoneNumber,
                    email = brokerModel.Email,
                    companyName = brokerModel.CompanyName,
                    message = brokerModel.Message,
                    requestType = "Partner Broker"

                });

                var avonEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);
                var infoEmail = _service.Settings.GetSetting(AvonConstants.Settings.INFO_EMAIL);

                var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);

                //var emailSender = new SendGridNotification(avonEmail, sendersName, apiKey);
                //var emailResponse = await emailSender.SendEmailMailAsync(emailSubject, brokerModel.Email, templateResult);

                _emailService.Send(emailSubject, brokerModel.Email, templateResult);


                //var emailSender_Avon = new SendGridNotification(avonEmail, sendersName, apiKey);
                //var emailResponse_Avon = await emailSender_Avon.SendEmailMailAsync(emailSubjectAvon, infoEmail, templateResultAvon);


                _emailService.Send(emailSubjectAvon, infoEmail, templateResultAvon);



                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = "Your request is well received. A member of our team will be in touch within 24 hours." });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error creating Partner Broker"
                    });
            }

        }

        /// <summary>
        /// The endPoint to get all partnerBroker
        /// </summary>
        [HttpGet(ApiRoutes.ExploreAvon.GetAllPartnerBroker)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPartnerBroker()
        {
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = await _service.Avon.GetPartnerBroker(),
                      Message = "",
                      StatusCode = 200
                  });
        }


        /// <summary>
        /// This endpoint Create Partner Agent
        /// </summary>
        /// <param name="agentModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.ExploreAvon.PostPartnerAgent)]
        public async Task<IActionResult> PostPartnerAgent([FromBody] PartnerAgentViewModel agentModel)
        {

            if (agentModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<PartnerAgentViewModel>(agentModel);


            if (errorMessage.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessage)
                    });


            if (!agentModel.Email.IsEmailAddress())
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "A valid email address is required"
                   });



            var createResult = await _service.Avon.CreatePartnerAgent(agentModel);

            if (createResult)
            {

                var templateName = "partner_network";
                var templateNameAvon = "partner_network_broker_agent";
                var emailSubject = "Partner Agent Request";
                var emailSubjectAvon = $"{agentModel.FirstName} {agentModel.Surname} Sign-up request for Partner Agent";

                var templateBuilder = new EmailTemplateBuilder(_env, templateName);
                var templateBuilderAvon = new EmailTemplateBuilder(_env, templateNameAvon);

                var templateResult = templateBuilder.BuildTemplate(new ProviderNetworkEmailToken()
                {
                    title = agentModel.Title,
                    firstName = agentModel.FirstName,
                    surName = agentModel.Surname,
                    phoneNumber = agentModel.PhoneNumber,
                    email = agentModel.Email,
                    companyName = agentModel.CompanyName,
                    message = agentModel.Message,
                    requestType = "Partner Agent"

                });
                var templateResultAvon = templateBuilderAvon.BuildTemplate(new ProviderNetworkEmailToken()
                {
                    title = agentModel.Title,
                    firstName = agentModel.FirstName,
                    surName = agentModel.Surname,
                    phoneNumber = agentModel.PhoneNumber,
                    email = agentModel.Email,
                    companyName = agentModel.CompanyName,
                    message = agentModel.Message,
                    requestType = "Partner Agent"

                });

                var avonEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);
                var infoEmail = _service.Settings.GetSetting(AvonConstants.Settings.INFO_EMAIL);

                var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);

                //var emailSender = new SendGridNotification(avonEmail, sendersName, apiKey);
                //var emailResponse = await emailSender.SendEmailMailAsync(emailSubject, agentModel.Email, templateResult);

                _emailService.Send(emailSubject, agentModel.Email, templateResult);


                //var emailSender_Avon = new SendGridNotification(avonEmail, sendersName, apiKey);
                //var emailResponse_Avon = await emailSender_Avon.SendEmailMailAsync(emailSubjectAvon, infoEmail, templateResultAvon);

                _emailService.Send(emailSubjectAvon, infoEmail, templateResultAvon);

                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = "Your request is well received. A member of our team will be in touch within 24 hours." });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error creating Partner Agent"
                    });
            }

        }

        /// <summary>
        /// The endPoint to call to get all partnerAgent
        /// </summary>
        [HttpGet(ApiRoutes.ExploreAvon.GetAllPartnerAgent)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPartnerAgent()
        {
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = await _service.Avon.GetPartnerAgent(),
                      Message = "",
                      StatusCode = 200
                  });
        }

        /// <summary>
        /// This endpoint Create Partner provider
        /// </summary>
        /// <param name="providerModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.ExploreAvon.PostPartnerProvider)]

        public async Task<IActionResult> PostPartnerProvider([FromBody] PartnerProviderViewModel providerModel)
        {

            if (providerModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<PartnerProviderViewModel>(providerModel);


            if (errorMessage.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessage)
                    });


            var createResult = await _service.Avon.CreatePartnerProvider(providerModel);

            if (createResult)
            {
                var templateName = "partner_network";
                var templateNameAvon = "partner_network_avon";
                var emailSubject = "Partner Provider Request";
                var emailSubjectAvon = $"Request to become a Provider";

                var templateBuilder = new EmailTemplateBuilder(_env, templateName);
                var templateBuilderAvon = new EmailTemplateBuilder(_env, templateNameAvon);

                var templateResult = templateBuilder.BuildTemplate(new ProviderNetworkEmailToken()
                {
                    title = providerModel.Title,
                    firstName = providerModel.FirstName,
                    surName = providerModel.Surname,
                    phoneNumber = providerModel.PhoneNumber,
                    email = providerModel.Email,
                    companyName = providerModel.ProviderName,
                    message = "",
                    requestType = "Partner Provider"

                });
                var templateResultAvon = templateBuilderAvon.BuildTemplate(new ProviderNetworkEmailToken()
                {
                    title = providerModel.Title,
                    firstName = providerModel.FirstName,
                    surName = providerModel.Surname,
                    phoneNumber = providerModel.PhoneNumber,
                    email = providerModel.Email,
                    companyName = providerModel.ProviderName,
                    message = "",
                    requestType = "Partner Provider"

                });

                var avonEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);
                var infoEmail = _service.Settings.GetSetting(AvonConstants.Settings.INFO_EMAIL);

                var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);

                //var emailSender = new SendGridNotification(avonEmail, sendersName, apiKey);
                //var emailResponse = await emailSender.SendEmailMailAsync(emailSubject, providerModel.Email, templateResult);

                _emailService.Send(emailSubject, providerModel.Email, templateResult);

                //var emailSender_Avon = new SendGridNotification(avonEmail, sendersName, apiKey);
                //var emailResponse_Avon = await emailSender_Avon.SendEmailMailAsync(emailSubjectAvon, infoEmail, templateResultAvon);

                _emailService.Send(emailSubjectAvon, infoEmail, templateResultAvon);




                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = "Your request is well received. A member of our team will be in touch within 24 hours." });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error creating Partner Provider"
                    });
            }

        }


        /// <summary>
        /// The endPoint to call to get all partnerProvider
        /// </summary>
        [HttpGet(ApiRoutes.ExploreAvon.GetAllPartnerProvider)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPartnerProvider()
        {
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = await _service.Avon.GetPartnerProvider(),
                      Message = "",
                      StatusCode = 200
                  });
        }


        /// <summary>
        /// This endpoint Create Risk Assessment Request
        /// </summary>
        /// <param name="riskModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.ExploreAvon.RiskAssessmentRequest)]

        public async Task<IActionResult> RiskAssessmentRequest([FromBody] RiskAssessmentRequestViewModel riskModel)
        {

            if (riskModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<RiskAssessmentRequestViewModel>(riskModel);


            if (errorMessage.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessage)
                    });

            var createResult = await _service.Avon.CreateHealthRiskAssessment(riskModel);


            if (createResult)
            {
                var userId = HttpContext.LoggedInUserId();// loggedInUserId;
                var questionAnswer = _service.Avon.ComputeRiskAssessmentAnswer(riskModel.assessmentResult, userId);
                //  model.userId = Guid.Parse(userId);



                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = questionAnswer });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error saving Health Risk Assessment Request"
                    });
            }

        }




        /// <summary>
        /// The endPoint to call to get all RiskAssessmentRequest
        /// </summary>
        [HttpGet(ApiRoutes.ExploreAvon.GetAllRiskAssessmentRequest)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllRiskAssessmentRequest()
        {
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = await _service.Avon.GetHealthRiskAssessment(),
                      Message = "",
                      StatusCode = 200
                  });
        }


        /// <summary>
        /// The endPoint to call to get all RiskAssessment Questions
        /// </summary>
        [HttpGet(ApiRoutes.ExploreAvon.GetAllRiskAssessmentQuestions)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllRiskAssessmentQuestions()
        {
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = await _service.Avon.GetHealthRiskAssessmentQuestion(),
                      Message = "",
                      StatusCode = 200
                  });
        }


        /// <summary>
        /// This enpoint returns HospitalReview taking hospitalCode as parameter
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.ExploreAvon.GetHospitalReviewByHospitalCode)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HospitalReviewViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FetchHospitalReview([FromQuery] PagingParam pagination, [FromRoute] string hospitalCode)
        {

            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<HospitalReviewViewModel>
                {
                    Data = _service.Avon.FetchHospitalReviewByHospitalCode(pagination, hospitalCode).ToList(),
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK
                });

        }

        /// <summary>
        /// This enpoint returns all HospitalReview 
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.ExploreAvon.GetHospitalReview)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HospitalReviewViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FetchHospitalReview([FromQuery] PagingParam pagination)
        {

            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<HospitalReviewViewModel>
                {
                    Data = _service.Avon.FetchHospitalReview(pagination).ToList(),
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK
                });

        }




        /// <summary>
        /// This endpoint create hospital image
        /// </summary>
        /// <param></param>
        /// <returns></returns>


        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.ExploreAvon.HospitalReviewImg)]
        public async Task<IActionResult> HospitalImage()
        {

            var model = new HospitalImageRequestModel();
            var request = await Request.ReadFormAsync();

            string fileUri = string.Empty;



            model.HospitalCode = request["HospitalCode"].FirstOrDefault();

            //upload prescription pix
            try
            {
                if (request.Files.Any())
                {
                    IFormFile formFile = null;
                    formFile = request.Files[0];
                    if (formFile != null)
                    {
                        var storageContainer = _config.GetSection("Azure:AzureStorageContainer").Value;
                        var uploadResponse = await _storageService.AzureStorage.UploadAsync(formFile, storageContainer);
                        if (uploadResponse != null)
                        {
                            fileUri = uploadResponse.fileUri;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(fileUri))
                {
                    model.Image = fileUri;
                }

            }
            catch
            {

            }


            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<HospitalImageRequestModel>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });




            var response = await _service.Avon.CreateHospitalImage(model);

            if (response)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Hospital Image saved successfully",
                    Data = null
                });
            }


            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "There was an error creating Hospital Image",
            });
        }

        /// <summary>
        /// This enpoint returns HospitalImage taking hospitalCode as parameter
        /// </summary>
        /// <param name="hospitalCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.ExploreAvon.GetHospitalReviewImgByHospitalCode)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HospitalImageViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FetchHospitalImageByHospitalCode([FromRoute] string hospitalCode)
        {

            var hospitalImage = _service.Avon.FetchHospitalImageByHospitalCode(hospitalCode).ToList();


            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<HospitalImageViewModel>
                {
                    Data = hospitalImage,
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK
                });

        }


        /// <summary>
        /// This endpoint create requeste Quote
        /// </summary>
        /// <param name="quoteModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.ExploreAvon.CreateRequestQuote)]
        public async Task<IActionResult> CreateRequestQuote([FromBody] RequestQuoteRequestModel quoteModel)
        {

            if (quoteModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<RequestQuoteRequestModel>(quoteModel);


            if (errorMessage.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessage)
                    });
            var planName = quoteModel.PlanName;

            var createResult = await _service.Avon.CreateRequestQuote(quoteModel);

            if (createResult)
            {

                var templateName = "quote_request";
                var emailSubject = "Plan Quote Request";

                var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                var templateResult = templateBuilder.BuildTemplate(new QuoteRequestEmailToken()
                {
                    name = quoteModel.Name,
                    planName = planName,
                    companyName = quoteModel.CompanyName,
                    companyAddress = quoteModel.CompanyAddress,
                    contactRole = quoteModel.ContactRole,
                    noToEnrollee = quoteModel.NoToEnrollee,
                    emailAddress = quoteModel.EmailAddress,
                    companyAndLargeAssociation = quoteModel.CompanyAndLargeAssociation,
                    internationalHealthPlan = quoteModel.InternationalHealthPlan

                });

                var avonEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);
                var infoEmail = _service.Settings.GetSetting(AvonConstants.Settings.INFO_EMAIL);

                var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);


                //var emailSender_Avon = new SendGridNotification(avonEmail, sendersName, apiKey);

                //var emailResponse_Avon = await emailSender_Avon.SendEmailMailAsync(emailSubject, infoEmail, templateResult);
                _emailService.Send(emailSubject, infoEmail, templateResult);



                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = "Your request is well received. A member of our team will be in touch within 24 hours." });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error creating Quote Request"
                    });
            }

        }

        /// <summary>
        /// The endpoint to get all requestQuote
        /// </summary>
        [HttpGet(ApiRoutes.ExploreAvon.GetAllRequestQuote)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<RequestQuoteModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRequestQuote()
        {
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = await _service.Avon.GetQuoteRequests(),
                      Message = "",
                      StatusCode = 200
                  });
        }

        /// <summary>
        /// This enpoint returns quotes  by quote Id
        /// </summary>
        /// <returns> Enrollee contact detail</returns>
        /// 

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<RequestQuoteModel>), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.ExploreAvon.GetAllRequestQuoteById)]
        public async Task<IActionResult> GetAllRequestQuoteById([FromRoute] Guid quoteID)
        {
            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object>
                {
                    Data = await _service.Avon.GetQuoteRequestById(quoteID),
                    Message = "",
                    StatusCode = 200
                });
        }


        /// <summary>
        /// This enpoint returns FAQ
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.ExploreAvon.GetAllFAQ)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<List<FAQViewModel>>), StatusCodes.Status200OK)]
        public IActionResult FAQCategories([FromQuery] PagingParam pagination)
        {
            var faq = _service.Avon.FAQs(pagination).ToList();

            return StatusCode(StatusCodes.Status200OK,
               new PagedResponse<FAQViewModel>
               {
                   Data = faq,
                   hasError = false,
                   PageNumber = pagination.PageNumber,
                   PageSize = pagination.PageSize,
                   StatusCode = 200,

               });

        }

        /// <summary>
        /// This enpoint searches through FAQ 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.ExploreAvon.FAQwithSearch)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<List<FAQViewModel>>), StatusCodes.Status200OK)]
        public IActionResult FAQwithSearch([FromQuery] PagingParam pagination, [FromQuery] string searchText)
        {
            var fAQs = _service.Avon.SearchFAQs(pagination, searchText).ToList();

            return StatusCode(StatusCodes.Status200OK,
               new PagedResponse<FAQViewModel>
               {
                   Data = fAQs,
                   hasError = false,
                   PageNumber = pagination.PageNumber,
                   PageSize = pagination.PageSize,
                   StatusCode = 200,

               });

        }

        /// <summary>
        /// This enpoint returns FAQ Categories
        /// </summary>
        /// <param></param>
        /// <returns></returns>

        [HttpGet(ApiRoutes.ExploreAvon.GetAllFAQCategories)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<FAQCategoryViewModel>>), StatusCodes.Status200OK)]
        public IActionResult MainCategories()
        {
            var category = _service.Avon.GetFAQCategories().ToList();

            if (!category.Any()) return StatusCode(StatusCodes.Status204NoContent);

            return StatusCode(StatusCodes.Status200OK,
               new ApiResponse<List<FAQCategoryViewModel>>
               {
                   Data = category,
                   hasError = false,
                   StatusCode = 200,
               });
        }




        /// <summary>
        /// This endpoint Create Customer's feedback
        /// </summary>
        /// <param name="feedbackModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.ExploreAvon.PostFeedback)]

        public async Task<IActionResult> PostFeedback([FromBody] FeedbackRequestModel feedbackModel)
        {

            if (feedbackModel == null) return StatusCode(StatusCodes.Status400BadRequest, 
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<FeedbackRequestModel>(feedbackModel);


            if (errorMessage.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessage)
                    });

            var createResult = await _service.Avon.CreateFeedback(feedbackModel);


            if (createResult)
            {

                var templateName = "feedback";
                var emailSubject = "User's Feedback";

                var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                var templateResult = templateBuilder.BuildTemplate(new FeedbackEmailToken()
                {
                    senderName = feedbackModel.Name,
                    email = feedbackModel.Email,
                    message = feedbackModel.Message,
                    subject = feedbackModel.Subject
                });

                var avonEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);
                var infoEmail = _service.Settings.GetSetting(AvonConstants.Settings.FEEDBACK_EMAIL);

                var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);


                //var emailSender_Avon = new SendGridNotification(avonEmail, sendersName, apiKey);

                //var emailResponse_Avon = await emailSender_Avon.SendEmailMailAsync(emailSubject, infoEmail, templateResult);
                _emailService.Send(emailSubject, infoEmail, templateResult);


                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = "Your feedback is well appreciated" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error saving your feedback"
                    });
            }

        }



        /// <summary>
        /// This enpoint returns all Feedback 
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.ExploreAvon.GetFeedback)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<FeedbackViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FetchFeedback([FromQuery] PagingParam pagination)
        {

            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<FeedbackViewModel>
                {
                    Data = _service.Avon.FetchFeedback(pagination).ToList(),
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK
                });

        }


    }
}
