using AvonHMO.API.Areas.Setup.Controllers;
using AvonHMO.API.Contracts;
using AvonHMO.API.Controllers;
using AvonHMO.API.Extensions;
using AvonHMO.API.Filters;
using AvonHMO.API.Helpers;
using AvonHMO.API.Models;
using AvonHMO.API.Models.EmailTemplateTokens;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.Application.ViewModels.Avon.Enrollee;
using AvonHMO.Application.ViewModels.Avon.EnrolleFlow;
using AvonHMO.Application.ViewModels.Avon.Plan;
using AvonHMO.Application.ViewModels.Avon.ViewModels;
using AvonHMO.Application.ViewModels.Toshfa;
using AvonHMO.Common;
using AvonHMO.Communications.Sendgrid;
using AvonHMO.Domain.Interfaces;
using AvonHMO.Domain.Interfaces.Avon;
using AvonHMO.Entities;
using BrightStar.Util.Storage.RepoManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AvonHMO.API.Areas.Enrollee.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    public class EnrolleeController : BaseController
    {
        private readonly IRepositoryManager _service;
        private readonly IStorageRepoManager _storageService;
        private readonly IConfiguration _config;
        IWebHostEnvironment _env;
        IEmailService _emailService;
        private readonly IHttpClientFactory _httpClientFactory;
        public EnrolleeController(IRepositoryManager service, IStorageRepoManager storageService, IConfiguration config, IHttpClientFactory httpClientFactory, IWebHostEnvironment env, IEmailService emailService)

        {
            _service = service;
            _storageService = storageService;
            _config = config;
            _httpClientFactory = httpClientFactory;
            _env = env;
            _emailService = emailService;
        }


        /// <summary>
        /// This endpoint Create RequestAuthourization
        /// </summary>
        /// <param name="reqAuthModel"></param>
        /// <returns></returns>
        /// 
        [HttpPost(ApiRoutes.Enrolle.PostRequestAuthourization)]
        public async Task<IActionResult> PostRequestAuthourization([FromBody] RequestAuthorizationViewModel reqAuthModel)
        {



            if (reqAuthModel == null) return StatusCode(StatusCodes.Status400BadRequest,
              new ApiResponse<object> { Data = null, Message = "Bad Request" });

            try
            {


                var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<RequestAuthorizationViewModel>(reqAuthModel);


                if (errorMessage.Any())
                    return StatusCode(StatusCodes.Status200OK,
                        new ApiResponse<object>
                        {
                            Data = null,
                            hasError = true,
                            Message = string.Join("; ", errorMessage)
                        });


                var userId = loggedInUserId;
                var enrolleeID = Guid.Parse(userId);
                //var enrolleeID = Guid.Parse("7BAD259C-209E-4484-83B1-7340802F53C4");
                var userExist = await _service.Avon.IsEnrolleeExist(enrolleeID);
                // reqAuthModel.EnrolleeId = enrolleeID.ToString();
                if (!userExist)
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                    {
                        hasError = true,
                        Message = "You do not have an active plan/subscription",
                        Data = null
                    });
                }

                //var paString = "AVH/";
                //var validPACode = reqAuthModel.PaCode.Contains(paString)  && reqAuthModel.PaCode.Length == 10;
                //if (!validPACode)
                //{
                //    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                //    {
                //        hasError = true,
                //        Message = "Kindly capture a valid PACode",
                //        Data = null
                //    });
                //}


                var createResult = await _service.Avon.CreateRequestAuthorization(reqAuthModel, enrolleeID);

                if (createResult)
                {
                    var templateName = "request_authorization_enrollee";
                    var templateNameProvider = "request_authorization_provider";
                    var templateNameAvon = "request_authorization";
                    var emailSubject = "Request Authorization/Out of station-emergency";

                    var templateBuilder = new EmailTemplateBuilder(_env, templateName);
                    var templateBuilderProvider = new EmailTemplateBuilder(_env, templateNameProvider);
                    var templateBuilderAvon = new EmailTemplateBuilder(_env, templateNameAvon);

                    var getUser = await _service.Enrollee.FetchBasicLocalEnrollee(enrolleeID);
                    var getProvider = new HmoProvidersViewModel();
                    if (reqAuthModel.ProviderId > 0)
                    {
                        getProvider = await _service.Enrollee.FetchProviderByProviderCode(reqAuthModel.ProviderId.Value);
                    }


                    var templateResult = templateBuilder.BuildTemplate(new RequestAuthorizationEmailToken()
                    {
                        firstName = reqAuthModel.FirstName ?? "",
                        lastName = getUser.SurName ?? "",
                        hospitalName = getProvider.Name ?? "",
                    });

                    var templateResultProvider = templateBuilderProvider.BuildTemplate(new RequestAuthorizationEmailToken()
                    {
                        firstName = reqAuthModel.FirstName ?? "",
                        lastName = getUser.SurName ?? "",
                        hcpName = getProvider.Name ?? "",
                        memberNumber = getUser.MemberNo > 0 ? getUser.MemberNo.ToString() : "0"
                    });
                    var templateResultAvon = templateBuilderAvon.BuildTemplate(new RequestAuthorizationEmailToken()
                    {
                        firstName = reqAuthModel.FirstName ?? "" + " " + getUser.SurName ?? "",
                        hcpName = getProvider.Name ?? "",
                        phoneNumber = getUser.MobileNo ?? "",
                        email = getUser.EMAIL ?? "",
                        memberNumber = getUser.MemberNo > 0 ? getUser.MemberNo.ToString() : "0"
                    });

                    var avonEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);
                    var infoEmail = _service.Settings.GetSetting(AvonConstants.Settings.INFO_EMAIL);
                    // var providerEmail = getProvider.HMOOfficerEmail ?? "";
                    var providerEmail = getProvider.email ?? "";

                    var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                    var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);


                    _emailService.Send(emailSubject, getUser.EMAIL, templateResult, null, null, avonEmail);
                    _emailService.Send(emailSubject, providerEmail, templateResultProvider, null, null, avonEmail);
                    _emailService.Send(emailSubject, avonEmail, templateResultAvon, null, null, avonEmail);




                    return StatusCode(StatusCodes.Status200OK,
                        new ApiResponse<object>
                        { Data = null, hasError = false, Message = "Request Authorization created successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new ApiResponse<object>
                        {
                            Data = null,
                            hasError = true,
                            StatusCode = StatusCodes.Status200OK,
                            Message = "There was an error creating Request Authorization"
                        });
                }
            }
            catch (Exception ex)
            {
                try
                {
                    var temlog = new TempLogModel()
                    {
                        PayLoad = System.Text.Json.JsonSerializer.Serialize(reqAuthModel),
                        Action = "PostRequestAuthourization",
                        Controller = "Enrollee",
                        Message = $"Error: {ExceptionHelper.FormatException(ex)}",
                    };
                    await _service.Avon.AddToTempLog(temlog);
                }
                catch
                {


                }
            }
            return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           StatusCode = StatusCodes.Status200OK,
                           Message = "There was an error creating Request Authorization"
                       });


        }



        /// <summary>
        /// This endpoint creates a new enrollee
        /// </summary>
        /// <remarks>
        /// Request body:  FormData => var formData =new FormData(); formData.Append("title","somevalue"); etc
        ///     
        ///     {
        ///         title:string,
        ///         firstName:string,
        ///         surname:string,
        ///         middleName:string,
        ///         gender:string,
        ///         maritalStatus:string,
        ///         dateOfBirth:string (dd/MM/yyyy),
        ///         bloodType:string,
        ///         weight:string,
        ///         height:string,
        ///         enrolleeType:string,
        ///         address:string,
        ///         lga :string,
        ///         state:string,
        ///         country:string,
        ///         phoneNumber:string,
        ///         phoneNumber2:string,
        ///         email:string,
        ///         profilePicture:file,
        ///         mailingAddress:string,
        ///         mailingState:string,
        ///         mailingLga :string,
        ///         productId :string,
        ///         isSponsored:boolean,
        ///         numberOfBenefact :string,
        ///         skipOnlinePayment:boolean
        ///         providerId:int,
        ///         paymentReference:string
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns response object</response>
        [HttpPost, DisableRequestSizeLimit]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [Route(ApiRoutes.Enrolle.CreateEnrolleee)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddEnrollee()
        {
            var model = new EnrolleePayloadModel();
            var request = await Request.ReadFormAsync();

            string fileUri = string.Empty;

            _ = int.TryParse(request["providerId"].FirstOrDefault(), out int providerId);
            _ = int.TryParse(request["productId"].FirstOrDefault(), out int productId);
            _ = decimal.TryParse(request["weight"].FirstOrDefault(), out decimal weight);
            _ = int.TryParse(request["isSponsored"].FirstOrDefault(), out int isSponsored);
            _ = int.TryParse(request["numberOfBenefact"].FirstOrDefault(), out int numberOfBenefact);
            _ = int.TryParse(request["skipOnlinePayment"].FirstOrDefault(), out int skipOnlinePayment);
            _ = decimal.TryParse(request["planRate"].FirstOrDefault(), out decimal planRate);
            _ = decimal.TryParse(request["totalAmount"].FirstOrDefault(), out decimal totalAmount);


            model.title = request["title"].FirstOrDefault();
            model.firstName = request["firstName"].FirstOrDefault();
            model.surname = request["surname"].FirstOrDefault();
            model.middleName = request["middleName"].FirstOrDefault();
            model.gender = request["gender"].FirstOrDefault();
            model.maritalStatus = request["maritalStatus"].FirstOrDefault();
            model.dateOfBirth = request["dateOfBirth"].FirstOrDefault();
            model.bloodType = request["bloodType"].FirstOrDefault();
            model.weight = weight;
            model.height = request["height"].FirstOrDefault();
            model.enrolleeType = request["enrolleeType"].FirstOrDefault();
            model.address = request["address"].FirstOrDefault();
            model.lga = request["lga"].FirstOrDefault();
            model.state = request["state"].FirstOrDefault();
            model.country = request["country"].FirstOrDefault();
            model.phoneNumber = request["phoneNumber"].FirstOrDefault();
            model.phoneNumber2 = request["phoneNumber2"].FirstOrDefault();
            model.email = request["email"].FirstOrDefault();
            model.mailingAddress = request["mailingAddress"].FirstOrDefault();
            model.mailingState = request["mailingState"].FirstOrDefault();
            model.mailingLga = request["mailingLga"].FirstOrDefault();
            model.paymentReference = request["paymentReference"].FirstOrDefault();
            model.productId = productId;
            model.isSponsored = isSponsored;
            model.numberOfBenefact = numberOfBenefact;
            model.skipOnlinePayment = skipOnlinePayment;

            model.providerId = providerId;
            model.totalAmount = totalAmount;
            model.planRate = planRate;

            model.appUser = loggedInUserId;


            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<EnrolleePayloadModel>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });


            if (!string.IsNullOrWhiteSpace(model.email))
            {
                if (!model.email.IsEmailAddress())
                    return StatusCode(StatusCodes.Status400BadRequest,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = "A valid email address is required"
                       });
            }

            if (string.IsNullOrWhiteSpace(model.enrolleeId))
            {
                if (model.productId <= 0 || !_service.Plans.AllPlans().Any(x => x.code == model.productId))
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = $"Invalid Plan (ProductId): plan with code {model.productId} does not exist"
                       });
                }
            }


            var provider = await _service.Toshfa.FetchProviderByProviderCode(model.providerId);

            if (provider != null)
            {
                model.providerState = provider.State;
                model.providerLGA = provider.LGA;
                model.providerName = provider.Name;
            }


            if (request.Files.Any())
            {
                var file = request.Files[0];
                if (file != null)
                {
                    if (!ImageHelper.AcceptImageExtention.Contains(Path.GetExtension(file.FileName)))
                        return StatusCode(StatusCodes.Status400BadRequest,
                      new ApiResponse<object>
                      {
                          Data = null,
                          hasError = true,
                          Message = $"Invalid Image, image must be any of type: {string.Join("; ", ImageHelper.AcceptImageExtention)}"
                      });

                    if ((file.Length / 1024) > 1024)
                        return StatusCode(StatusCodes.Status400BadRequest,
                      new ApiResponse<object>
                      {
                          Data = null,
                          hasError = true,
                          Message = $"Image too large, image must not exceed 1MB"
                      });
                }
            }

            string sponsorEmail = string.Empty;

            if (model.isSponsored == 1)
                sponsorEmail = HttpContext.MemberEmail();

            var response = new ResData();

            if (string.IsNullOrEmpty(model.enrolleeId))
                response = await _service.Avon.AddEnrollee(model, sponsorEmail);
            else
                response = await _service.Avon.EditEnrollee(model);

            if (!response.hasError)
            {
                //upload and update profile px
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
                        await _service.Avon.UpdateEnrolleeProfilePix(fileUri, response.enrolleeId);
                    }



                }
                catch
                {

                }


                //send subscription notification
                try
                {

                    var plan = _service.Plans.AllPlans().FirstOrDefault(x => x.code == model.productId);


                    var templateName = "new_plan_subscription";

                    var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                    var templateResult = templateBuilder.BuildTemplate(new PlanSubscriptionEmailModel()
                    {
                        PlanName = plan.planName,
                    });

                    var sendersEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);

                    var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                    var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);

                    // var emailSender = new SendGridNotification(sendersEmail, sendersName, apiKey);

                    // var emailResponse = await emailSender.SendEmailMailAsync("Plan Subscription", model.email, templateResult);
                    _emailService.Send("Plan Subscription", model.email, templateResult);
                }
                catch
                {


                }



                //create user account for sponsored enrollee
                if (string.IsNullOrEmpty(model.enrolleeId) && model.isSponsored == 1)
                {
                    var acctmodel = new UserAccountViewModel()
                    {
                        email = model.email,
                        firstName = model.firstName,
                        lastName = model.surname,
                        userName = model.email,
                        password = GenerateToken(8),
                    };

                    await CreateAccount(acctmodel);
                }



                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Enrollee Added Successfully",
                    Data = new
                    {
                        enrolleeId = response.enrolleeId,
                    }
                });

            }

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }



        /// <summary>
        /// This endpoint is use to log plan payment
        /// </summary>
        /// <remarks>
        /// This endpoint is use to log plan payment
        /// </remarks>
        /// <response code="200"></response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<PaymentResponseModel>), StatusCodes.Status200OK)]
        [Route(ApiRoutes.Enrolle.EnrolleePayment)]
        [AllowAnonymous]
        public async Task<IActionResult> AddPaymentEnrollee([FromBody] PaymentRequestModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });

            if (model.amount <= 0)
            {
                return StatusCode(StatusCodes.Status200OK,
                                 new ApiResponse<object>
                                 {
                                     Data = null,
                                     hasError = true,
                                     Message = $"Invalid Amount"
                                 });
            }

            if (model.nhis < 0)
            {
                return StatusCode(StatusCodes.Status200OK,
                                 new ApiResponse<object>
                                 {
                                     Data = null,
                                     hasError = true,
                                     Message = $"Invalid NHIS Amount"
                                 });
            }

            if (model.productId <= 0 || !_service.Plans.AllPlans().Any(x => x.code == model.productId))
            {
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Invalid Plan (ProductId): plan with code {model.productId} does not exist"
                   });
            }

            var response = await _service.Avon.AddEnrolleePayment(model);
            if (response != null && !response.hasError)
                return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = new PaymentResponseModel()
                           {
                               paymentReference = response.PaymentReference,
                               transactionReference = model.transactionReference
                           },
                           hasError = false,
                           Message = "payment added successfully"
                       });

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }




        /// <summary>
        /// This enpoint returns  List of enrollee. Sorting: Value can be id_asc or id_desc, name_asc or name_desc, status_asc or status_desc
        /// </summary>
        ///<param name="param">Paging and filter Model Prameter</param>
        /// <returns>List of Enrollee</returns>
        [HttpGet(ApiRoutes.Enrolle.getEnrolleee)]
        public IActionResult GetEnrollee([FromQuery] PaggingFilterParams param)
        {
            var data = new List<EnrolleeViewDTO>();
            var responseData = new EnrolleeFiteredModel();
            var enrollee = _service.Avon.GetEnrolleeInfo().ToList();

            if (!string.IsNullOrEmpty(param.name))
                enrollee = enrollee.Where(m => !string.IsNullOrEmpty(m.fullName) && m.fullName.Contains(param.name, StringComparison.OrdinalIgnoreCase)).ToList();

            if (param.providerCode > 0)
                enrollee = enrollee.Where(m => m.providerId == param.providerCode).ToList();

            if (!string.IsNullOrEmpty(param.phoneNo))
                enrollee = enrollee.Where(m => m.phoneNumber.Contains(param.phoneNo)).ToList();

            int totalRecord = enrollee.Count();
            responseData.pageSize = param.pageSize;
            responseData.pageNumber = param.pageNumber;
            responseData.totalCount = totalRecord;
            var skip = param.pageSize * (param.pageNumber <= 0 ? 0 : param.pageNumber - 1);

            responseData.enrollees = enrollee.OrderByDescending(d => d.dateCreated).Skip(skip).Take(param.pageSize).ToList();

            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object>
                {
                    Data = responseData,
                    Message = "",
                    StatusCode = 200
                });
        }

        /// <summary>
        /// This enpoint returns  enrollee by enrollee Id
        /// </summary>
        /// <returns> Enrollee</returns>



        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(EnrolleeViewModel), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Enrolle.enrolleeInfo)]
        public async Task<IActionResult> GetEnrolleeById([FromRoute] Guid enrolleeId)
        {

            EnrolleeViewModel data = null;

            data = await _service.Avon.GetEnrolleeInfoByEnrolleeId(enrolleeId);
            if (data != null && data.enrolleeId != Guid.Empty)
            {
                var provider = await _service.Toshfa.FetchProviderByProviderCode(data.providerInfo.providerId);
                if (provider != null)
                {
                    data.providerInfo.providerState = provider.State;
                    data.providerInfo.providerAddress = provider.Address;
                    data.providerInfo.providerLGA = provider.LGA;
                    data.providerInfo.providerName = provider.Name;
                }

                return StatusCode(StatusCodes.Status200OK,
               new ApiResponse<object>
               {
                   Data = data,
                   Message = "",
                   StatusCode = 200
               });

            }


            if (data.enrolleeId == Guid.Empty)
            {
                var enrollee = await _service.Enrollee.FetchMemberInformationByNumber(int.Parse(this.memberNumber));

                if (enrollee.Any())
                {

                    var record = enrollee.FirstOrDefault();
                    var localEnrollee = await _service.Enrollee.
                    FetchLocalEnrollee(Guid.Parse(this.loggedInUserId));

                    var gender = record.Gender.ToLower();

                    var fGender = string.Empty;

                    switch (gender)
                    {
                        case "female":
                            fGender = "f";
                            break;
                        case "male":
                            fGender = "m";
                            break;
                        default:
                            fGender = record.Gender.ToLower();
                            break;
                    }

                    data = new EnrolleeViewModel
                    {
                        enrolleeId = data.enrolleeId,
                        memberNumber = record.MemberNo,
                        isActive = true,
                        clientName = record.ClientName,
                        personalDetail = new PersonalDetailViewModel
                        {
                            surname = record.SurName,
                            firstName = record.FirstName,
                            dateOfBirth = record.DOB,
                            maritalStatus = record.MaritalStatus,
                            gender = fGender,
                            title = "",
                            weight = localEnrollee.weight,
                            bloodType = localEnrollee.bloodType,
                            height = localEnrollee.height,
                            imageUrl = record.imageUrl,
                            middleName = localEnrollee.MiddleName
                        },
                        contactDetail = new ContactDetailView
                        {
                            address = record.Address,
                            country = record.Country,
                            email = record.EMAIL,
                            lga = "",
                            mailingAddress = "",
                            phoneNumber = record.MobileNo
                        },
                        providerInfo = new ProviderInfo
                        {
                            providerAddress = "",
                            providerName = record.PrimaryProviderName,
                            providerCountry = "Nigeria",
                            providerId = record.PrimaryProviderNo,

                        },
                        planDetail = new PlanDetail
                        {
                            PlanName = record.PlanType,
                            PlanCode = record.planCode


                        }
                    };
                }


            }


            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object>
                {
                    Data = data,
                    Message = "",
                    StatusCode = 200
                });
        }


        /// <summary>
        /// This endpoint allow adding or modify their personal detail. Supply PaymentReference while adding new enrollee. Only supply enrolleeId while modifying.
        /// </summary>
        /// <remarks>
        /// Request body:  FormData => var formData =new FormData(); formData.Append("title","somevalue"); etc
        ///     
        ///     {
        ///         title:string,
        ///         firstName:string,
        ///         surname:string,
        ///         middleName:string,
        ///         gender:string,
        ///         maritalStatus:string,
        ///         dateOfBirth:string (dd/MM/yyyy),
        ///         bloodType:string,
        ///         weight:string,
        ///         height:string,
        ///         enrolleeId:string,
        ///         enrolleeType:string,
        ///         PaymentReference:string
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns response object</response>
        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Enrolle.enrolleePersonalDetail)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ModifyEnrolleePersonalDetail()
        {
            var model = new PersonalDetailDTO();
            var request = await Request.ReadFormAsync();

            string fileUri = string.Empty;
            _ = decimal.TryParse(request["weight"].FirstOrDefault(), out decimal weight);

            model.title = request["title"].FirstOrDefault();
            model.firstName = request["firstName"].FirstOrDefault();
            model.surname = request["surname"].FirstOrDefault();
            model.middleName = request["middleName"].FirstOrDefault();
            model.gender = request["gender"].FirstOrDefault();
            model.maritalStatus = request["maritalStatus"].FirstOrDefault();
            model.dateOfBirth = request["dateOfBirth"].FirstOrDefault();
            model.bloodType = request["bloodType"].FirstOrDefault();
            model.weight = weight;
            model.height = request["height"].FirstOrDefault();
            model.enrolleeId = request["enrolleeId"].FirstOrDefault();
            model.paymentReference = request["paymentReference"].FirstOrDefault();
            model.enrolleeType = request["enrolleeType"].FirstOrDefault();


            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<PersonalDetailDTO>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });


            if (request.Files.Any())
            {
                var file = request.Files[0];
                if (file != null)
                {
                    if (!ImageHelper.AcceptImageExtention.Contains(Path.GetExtension(file.FileName)))
                        return StatusCode(StatusCodes.Status200OK,
                      new ApiResponse<object>
                      {
                          Data = null,
                          hasError = true,
                          Message = $"Invalid Image, image must be any of type: {string.Join("; ", ImageHelper.AcceptImageExtention)}"
                      });

                    if ((file.Length / 1024) > 1024)
                        return StatusCode(StatusCodes.Status200OK,
                      new ApiResponse<object>
                      {
                          Data = null,
                          hasError = true,
                          Message = $"Image too large, image must not exceed 1MB"
                      });
                }
            }

            var response = new ResData();
            var msg = "Enrollee personal detail modified successfully";
            if (string.IsNullOrEmpty(model.enrolleeId))
            {
                response = await _service.Avon.AddEnrolleePrincipalInfo(model);
                msg = "Enrollee personal detail added successfully";
            }
            else
            {
                response = await _service.Avon.EditEnrolleePrincipalInfo(model);
            }

            if (!response.hasError)
            {
                //upload and update profile px
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
                        await _service.Avon.UpdateEnrolleeProfilePix(fileUri, response.enrolleeId);
                    }

                }
                catch
                {

                }

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = msg,
                    Data = new
                    {
                        enrolleeId = response.enrolleeId,
                    }
                });

            }

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }


        /// <summary>
        /// This endpoint allow enrolle modify their personal detail with birth certificate upload
        /// </summary>
        /// <remarks>
        /// Request body:  FormData => var formData =new FormData(); formData.Append("title","somevalue"); etc
        ///     
        ///     {
        ///         bloodType:string,
        ///         weight:string,
        ///         height:string,
        ///         enrolleeId:string,
        ///         phoneNumber:string
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns response object</response>


        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Enrolle.enrolleePersonalDetailBirthCert)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ModifyEnrolleeWithBirthCertPersonalDetail()
        {
            var model = new PersonalDetailBirthCertDTO();
            var request = await Request.ReadFormAsync();

            string fileUri = string.Empty;
            _ = decimal.TryParse(request["weight"].FirstOrDefault(), out decimal weight);
            model.bloodType = request["bloodType"].FirstOrDefault();
            model.weight = weight;
            model.height = request["height"].FirstOrDefault();
            model.enrolleeId = request["enrolleeId"].FirstOrDefault();
            model.phoneNumber = request["phoneNumber"].FirstOrDefault();

            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<PersonalDetailBirthCertDTO>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });

            if (string.IsNullOrEmpty(model.enrolleeId))
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Invalid EnrolleeId"
                   });

            var enrolleeId = Guid.Parse(model.enrolleeId);
            var enrolleeExist = (await _service.Avon.GetEnrollee()).Any(m => m.enrolleeId == enrolleeId);
            if (!enrolleeExist)
                return StatusCode(StatusCodes.Status200OK,
                 new ApiResponse<object>
                 {
                     Data = null,
                     hasError = true,
                     Message = $"EnrolleeId does not exist"
                 });


            if (request.Files.Any())
            {
                var file = request.Files[0];
                if (file != null)
                {
                    if (!ImageHelper.AcceptImageandFilExtention.Contains(Path.GetExtension(file.FileName)))
                        return StatusCode(StatusCodes.Status200OK,
                      new ApiResponse<object>
                      {
                          Data = null,
                          hasError = true,
                          Message = $"Invalid Image, image must be any of type: {string.Join("; ", ImageHelper.AcceptImageandFilExtention)}"
                      });

                    if ((file.Length / 1024) > 1024)
                        return StatusCode(StatusCodes.Status200OK,
                      new ApiResponse<object>
                      {
                          Data = null,
                          hasError = true,
                          Message = $"File too large, file must not exceed 1MB"
                      });
                }
            }



            if (request.Files.Any())
            {
                var formFile = request.Files[0];
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
                     
            var response = await _service.Avon.EditEnrolleeBasicInfo(model,fileUri);

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = false,
                Message = "Enrollee Personal Detail With Birth Certificate modified Successfully",
                Data = new
                {
                    enrolleeId = response.enrolleeId,
                    picturePath = fileUri
                }
            });

        }




        /// <summary>
        /// This enpoint returns  enrollee personal detail by enrollee Id
        /// </summary>
        /// <returns> Enrollee Personal detail</returns>
        /// 
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<PersonalDetailViewModel>), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Enrolle.getenrolleePersonalDetail)]
        public async Task<IActionResult> GetEnrolleePersonalDetailById([FromRoute] Guid enrolleeId)
        {
            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object>
                {
                    Data = await _service.Avon.GetEnrolleePrincipalInfo(enrolleeId),
                    Message = "",
                    StatusCode = 200
                });
        }

        /// <summary>
        /// This enpoint returns  enrollee contact detail by enrollee Id
        /// </summary>
        /// <returns> Enrollee contact detail</returns>
        /// 

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<ContactDetailView>), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Enrolle.getenrolleecontactDetail)]
        public async Task<IActionResult> GetEnrolleecontactDetailById([FromRoute] Guid enrolleeId)
        {
            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object>
                {
                    Data = await _service.Avon.GetEnrolleeContactInfo(enrolleeId),
                    Message = "",
                    StatusCode = 200
                });
        }



        /// <summary>
        /// This enpoint returns  enrollee contact detail by enrollee Id
        /// </summary>
        /// <returns> Enrollee contact detail</returns>


        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<ProviderInfo>), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Enrolle.getenrolleeproviderDetail)]
        public async Task<IActionResult> GetEnrolleeproviderDetailById([FromRoute] Guid enrolleeId)
        {
            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object>
                {
                    Data = await _service.Avon.GetEnrolleeProviderInfoByEnrolleeId(enrolleeId),
                    Message = "",
                    StatusCode = 200
                });
        }


        /// <summary>
        /// modify  erollee contact detail
        /// </summary>
        ///  <remarks>
        /// Request body:  FormData => var formData =new FormData() ...
        ///     
        ///     {
        ///         address:string,
        ///         lga:string,
        ///         state:string,
        ///         country:string,
        ///         phoneNumber:string,
        ///         phoneNumber2:string,
        ///         email:string,
        ///         mailingAddress:string,
        ///         mailingState:string,
        ///         mailingLga:string,
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns response object</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Enrolle.enrolleecontactDetail)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ModifyEnrolleeContact()
        {
            var model = new ContactDetailDTO();
            var request = await Request.ReadFormAsync();

            string fileUri = string.Empty;

            model.address = request["address"].FirstOrDefault();
            model.lga = request["lga"].FirstOrDefault();
            model.state = request["state"].FirstOrDefault();
            model.country = request["country"].FirstOrDefault();
            model.phoneNumber = request["phoneNumber"].FirstOrDefault();
            model.phoneNumber2 = request["phoneNumber2"].FirstOrDefault();
            model.email = request["email"].FirstOrDefault();
            model.mailingAddress = request["mailingAddress"].FirstOrDefault();
            model.mailingState = request["mailingState"].FirstOrDefault();
            model.mailingLga = request["mailingLga"].FirstOrDefault();
            model.enrolleeId = request["enrolleeId"].FirstOrDefault();

            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<ContactDetailDTO>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });


            if (!string.IsNullOrWhiteSpace(model.email))
            {
                if (!model.email.IsEmailAddress())
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = "A valid email address is required"
                       });
            }


            if (request.Files.Any())
            {
                var file = request.Files[0];
                if (file != null)
                {
                    if (!ImageHelper.AcceptImageExtention.Contains(Path.GetExtension(file.FileName)))
                        return StatusCode(StatusCodes.Status200OK,
                      new ApiResponse<object>
                      {
                          Data = null,
                          hasError = true,
                          Message = $"Invalid Image, image must be any of type: {string.Join("; ", ImageHelper.AcceptImageExtention)}"
                      });

                    if ((file.Length / 1024) > 1024)
                        return StatusCode(StatusCodes.Status200OK,
                      new ApiResponse<object>
                      {
                          Data = null,
                          hasError = true,
                          Message = $"Image too large, image must not exceed 1MB"
                      });
                }
            }

            var response = new ResData();
            response = await _service.Avon.EditEnrolleeContactInfo(model);

            if (!response.hasError)
            {
                //upload and update profile px
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
                        await _service.Avon.UpdateEnrolleeProfilePix(fileUri, response.enrolleeId);
                    }

                }
                catch
                {

                }

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Enrollee Contact infomation updated Successfully",
                    Data = new
                    {
                        enrolleeId = response.enrolleeId,
                    }
                });

            }

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }

        /// <summary>
        /// Bulk Activation or deactivation of enrollee.
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [HttpPost]
        [Route(ApiRoutes.Enrolle.bulkenrolleeactivate)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> BulkEnrolleeactivate([FromBody] BulkActivateDeactivateEnrolleePayload model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });

            var isBadData = model.data.Any(t => t.activateOrDeactivate != 0 || t.activateOrDeactivate != 1);
            if (isBadData)
                return StatusCode(StatusCodes.Status200OK,
                     new ApiResponse<object>
                     {
                         Data = null,
                         hasError = true,
                         Message = $"Bulk Enrollee Activation/Deactivation List Contain invalid  Activation/Deactivation code. supply 1 to activate, 0 to deactivate"
                     });

            await _service.Avon.BulkActivateDeactivateEnrollee(model);

            return StatusCode(StatusCodes.Status200OK,
            new ApiResponse<object>
            {
                Data = null,
                hasError = true,
                Message = $"Bulk Enrollee Activation/Deactivation successfully"
            });

        }

        /// <summary>
        /// Activate or deactivate enrollee. 1 to activate, 0 to deactivate
        /// </summary>


        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [HttpPost]
        [Route(ApiRoutes.Enrolle.enrolleeactivate)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Enrolleeactivate([FromBody] ActivateDeactivateEnrolleePayload model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });

            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<ActivateDeactivateEnrolleePayload>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });
            if (model.activateOrDeactivate != 0 && model.activateOrDeactivate != 1)
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "activateOrDeactivate can only have value of 1 or 0. 1 to activate and 0 to deactivate"
                   });

            if (model.enrolleeId == new Guid())
                return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = null,
                      hasError = true,
                      Message = "enrollee Id is not valid"
                  });

            string msg = model.activateOrDeactivate == 0 ? "deactivated" : "activated";
            var res = await _service.Avon.ActivateDeactivateEnrollee(model.enrolleeId, model.activateOrDeactivate);
            if (res)
                return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object>
                {
                    Data = null,
                    hasError = true,
                    Message = $"enrollee {msg} successfully"
                });

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }


        /// <summary>
        /// This enpoint returns  enrollee Subscription/principal account
        /// </summary>
        /// <returns> Enrollee Subscription</returns>


        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(EnrolleeSub), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Enrolle.enrolleeAccoutInfo)]
        public async Task<IActionResult> GetEnrolleeSubscriptionById([FromRoute] Guid enrolleeId)
        {
            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object>
                {
                    Data = await _service.Avon.GetEnrolleeSubByEnrolleeId(enrolleeId),
                    Message = "",
                    StatusCode = 200
                });
        }



        /// <summary>
        /// This endpoint returns list of member's medical record - Test MemberNo 84648
        /// </summary>
        /// <param name="memberNo"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<MedicalRecordViewModel>>), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Enrolle.EnrolleeMedicalRecord)]
        public async Task<IActionResult> EnrolleeMedicalRecords([FromRoute] string memberNo)
        {
            var _client = _httpClientFactory.CreateClient("toshfaClient");

            var request = new HttpRequestMessage(HttpMethod.Get, $"EnrolleeMedicalRecord/{memberNo}");

            var response = await _client.SendAsync(request);


            if (response.IsSuccessStatusCode)
            {
                var medicalRecords = await response.Content.ReadFromJsonAsync<MedicalRecordLists>();


                if (medicalRecords.lstEnroleeMedicalRecordsDetails != null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<List<MedicalRecordViewModel>>
                  {
                      Data = medicalRecords.lstEnroleeMedicalRecordsDetails.ToList(),
                      hasError = false,
                      StatusCode = 200,

                  });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                    {
                        hasError = true,
                        Message = "No medical record not found",
                        StatusCode = 200
                    });
                }



            }

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "No medical record not found",
                StatusCode = 200
            });

        }
        private string GenerateToken(int length)
        {
            var random = RandomNumberGenerator.GetBytes(length);
            return Convert.ToBase64String(random).Replace("=", "");
        }
        private async Task<int> generateTempMemberNumber()
        {

            string _symb = "1100000";

            var lastNum = await _service.AvonAuth.CountUsers();

            lastNum = lastNum + 1;

            return int.Parse($"{_symb}{lastNum.ToString()}".Right(9));
        }



        /// <summary>
        /// Add Referral Request 
        /// </summary> 
        /// <remarks>
        /// Request body:  FormData => var formData =new FormData(); formData.Append("title","somevalue"); etc
        ///     
        ///     {
        ///         beneficiaryName: string
        ///         enrolleeId:string,
        ///         reason:string,
        ///         referralDate:string (dd/MM/yyyy),
        ///         referralTime:string,
        ///         medicalSummary: string
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns response object</response>
        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Enrolle.PostReferralRequest)]
        public async Task<IActionResult> AddReferralRequest()
        {

            var model = new ReferralRequestRequestModel();
            var request = await Request.ReadFormAsync();

            string fileUri = string.Empty;


            var userId = loggedInUserId;

            var _userId = Guid.Parse(userId);
            // model.userId = Guid.Parse("2D6E2ED4-ACC6-4675-8EF8-CB35E76891AD");


            model.BeneficiaryName = request["beneficiaryName"].FirstOrDefault();
            var _enrolleeId = request["enrolleeId"].FirstOrDefault();
            model.EnrolleeId = Guid.Parse(_enrolleeId);
            model.Reason = request["reason"].FirstOrDefault();
            model.ReferralDate = request["referralDate"].FirstOrDefault();
            model.ReferralTime = request["referralTime"].FirstOrDefault();
            model.MedicalSummary = request["medicalSummary"].FirstOrDefault();


            var userExist = await _service.Avon.IsEnrolleeIDExist(model.EnrolleeId);

            if (!userExist)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = true,
                    Message = "You do not have an active plan/subscription",
                    Data = null
                });
            }



            //upload dependant pix
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
                    model.MedicalDocPath = fileUri;
                }

            }
            catch
            {

            }


            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<ReferralRequestRequestModel>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });



            var response = await _service.Avon.CreateReferralRequest(model, _userId);

            if (response)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Referral Request Added Successfully",
                    Data = null
                });
            }


            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<object>
            {
                hasError = true,
                Message = "There was an error creating Referral Request",
            });
        }


        /// <summary>
        /// This enpoint returns all ReferralRequest pagination as parameter
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>Referral request</returns>
        [HttpGet]
        [Route(ApiRoutes.Enrolle.GetReferralRequest)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<ReferralRequestViewModel>), StatusCodes.Status200OK)]
        public IActionResult FetchReferralRequest([FromQuery] PagingParam pagination)
        {

            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<ReferralRequestViewModel>
                {
                    Data = _service.Avon.FetchReferralRequest(pagination),
                    hasError = false,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    StatusCode = 200,

                });

        }

        /// <summary>
        /// This enpoint returns  referral request detail by enrollee Id
        /// </summary>
        /// <returns>  Referral request detail</returns>
        /// 

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<ReferralRequestViewModel>), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Enrolle.GetReferralRequestByID)]
        public async Task<IActionResult> GetReferralRequestById([FromRoute] Guid id)
        {

            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object>
                {
                    Data = await _service.Avon.FetchReferralRequestByID(id),
                    Message = "",
                    StatusCode = 200
                });
        }


        private async Task CreateAccount(UserAccountViewModel model)
        {
            try
            {

                //if (model == null)
                //    return;
                //var errorMessages = ExceptionHelper.ModelRequiredFieldValidation<UserAccountViewModel>(model);

                //if (errorMessages.Any())
                //    return;

                if (!model.email.IsEmailAddress())
                    return;

                var existingUser = await _service.AvonAuth.FindUserByEmail(model.email.Trim());
                if (existingUser != null) return;


                var userWithSamePhone = await _service.AvonAuth.FindUserByPhone(model.mobilePhone);
                if (!string.IsNullOrWhiteSpace(model.mobilePhone) && userWithSamePhone != null) return;



                var passwordSalt = StringExtensions.RandomString(50);

                var hashedPassword = model.password.EncryptSha512(passwordSalt);

                var memberNum = await generateTempMemberNumber();

                var userModel = new UserAccountModel
                {
                    firstName = model.firstName,
                    lastName = model.lastName,
                    email = model.email,
                    mobilePhone = model.mobilePhone,
                    password = hashedPassword,
                    passwordSalt = passwordSalt,
                    userName = model.email,
                    companyId = model.companyId,
                    memberNo = memberNum.ToString(),
                    selfCreated = false

                };



                var response = await _service.AvonAuth.CreateUserAccount(userModel);

                if (response)
                {

                    var referalCode = StringExtensions.RandomString(8, true, true, false).ToUpper();


                    var createdUser = await _service.AvonAuth.FindUserByEmail(model.email.Trim());

                    await _service.AvonAuth.GenerateEnrolleeReferalCode(referalCode, createdUser.userId, 0);

                    await _service.AvonAuth.AddUserToRole("Enrollee", createdUser.userId);

                    var templateName = "new_account_welcome";

                    var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                    var templateResult = templateBuilder.BuildTemplate(new NewAccountEmailToken()
                    {
                        firstName = userModel.firstName,
                        email = userModel.email,
                        password = model.password
                    });

                    var sendersEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);

                    var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                    var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);

                    //var notifcation = new NotificationService(_service);

                    //await notifcation.SendNotification("Login Details", userModel.email, templateResult);

                    //var emailSender = new SendGridNotification(sendersEmail, sendersName, apiKey);

                    //var emailResponse = await emailSender.SendEmailMailAsync("Login Details", userModel.email, templateResult);
                    _emailService.Send("Login Details", userModel.email, templateResult);


                }


            }
            catch
            {


            }
        }




    }
}
