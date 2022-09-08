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
using AvonHMO.Application.ViewModels.Avon.Plan;
using AvonHMO.Application.ViewModels.Avon.ViewModels;
using AvonHMO.Common;
using AvonHMO.Communications.Sendgrid;
using AvonHMO.Domain.Interfaces;
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
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AvonHMO.API.Areas.Plan.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    [APIKeyAuth]
    public class PlanSubscriptionController : ControllerBase
    {
        private readonly IRepositoryManager _service;
        private readonly IStorageRepoManager _storageService;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;
        IEmailService _emailService;

        public PlanSubscriptionController(IRepositoryManager service,
            IStorageRepoManager storageService,
            IConfiguration config, IWebHostEnvironment env, IEmailService emailService)
        {
            _service = service;
            _storageService = storageService;
            _config = config;
            _env = env;
            _emailService = emailService;
        }


        /// <summary>
        /// This endpoint returns all plan categories
        /// </summary>
        /// <returns></returns>
        [HttpGet(ApiRoutes.Plans.PlanCategories)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<PlanCategoryViewModel>>), StatusCodes.Status200OK)]
        public IActionResult PlanCategories()
        {


            var allPlans = _service.Plans.PlanCategories().ToList();

            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<List<PlanCategoryViewModel>>
                  {
                      Data = allPlans,
                      Message = "",
                      StatusCode = 200
                  });
        }

        [HttpGet(ApiRoutes.Plans.AllPlanTypes)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<PlanTypeViewModel>>), StatusCodes.Status200OK)]
        public IActionResult PlanTypes()
        {

            var normalPlans = _service.Plans.AllPlanTypes().ToList();
            var otherPlans = _service.Plans.AllOtherPlans().ToList();

            var allPlans = normalPlans.Concat(otherPlans).ToList();

            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<List<PlanTypeViewModel>>
                  {
                      Data = allPlans,
                      Message = "",
                      StatusCode = 200
                  });
        }

        [HttpGet(ApiRoutes.Plans.PlanByCategory)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<PlanViewModel>>), StatusCodes.Status200OK)]
        public IActionResult PlanTypes([FromRoute] Guid categoryId)
        {
            var normalPlans = _service.Plans.AllPlans().Where(x => x.planTypeId == categoryId)
                .OrderByDescending(x => x.premium).ToList();
          
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<List<PlanViewModel>>
                  {
                      Data = normalPlans,
                      Message = "",
                      StatusCode = 200
                  });
        }


        [HttpGet(ApiRoutes.Plans.OtherPlanForEnrollee)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<PlanViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PlanGreaterThanEnrolleePlan([FromQuery] int memberNo)
        {

          
            var memberInfo = await _service.Toshfa.FetchMemberByNumber(memberNo);

            if (memberInfo==null)
                return StatusCode(StatusCodes.Status200OK,
                 new ApiResponse<List<PlanViewModel>>
                 {
                     hasError = true,
                     Data = null,
                     Message = "",
                     StatusCode = 200
                 });



            var memberCurrPlan = memberInfo.PlanTypeCategory; ;



            var normalPlans = _service.Plans.AllPlans().Where(x => x.planClass == memberCurrPlan).FirstOrDefault();


            var otherPlans = _service.Plans.AllPlans()
                .Where(x => x.planCategoryCode <= normalPlans.planCategoryCode && x.planCategoryCode > 0).ToList();

            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<List<PlanViewModel>>
                  {
                      Data = otherPlans,
                      Message = "",
                      StatusCode = 200
                  });
        }


        /// <summary>
        /// Add Principal Details while initialize buying of plan
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
        ///         address:string,
        ///         state:string,
        ///         country:string,
        ///         phoneNumber:string,
        ///         email:string,
        ///         city:string,
        ///         productId:string,
        ///         isSponsor:int,
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns response object</response>

        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Plans.PlanInitialize)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddPrincipalDetail()
        {

            var model = new PrincipalDetailViewModel();
            var request = await Request.ReadFormAsync();
            string fileUri = string.Empty;


            _ = int.TryParse(request["productId"].FirstOrDefault(), out int productId);
            _ = int.TryParse(request["isSponsor"].FirstOrDefault(), out int isSponsor);

            model.firstName = request["firstName"].FirstOrDefault();
            model.middleName = request["middleName"].FirstOrDefault();
            model.surname = request["surname"].FirstOrDefault();
            model.title = request["title"].FirstOrDefault();
            model.gender = request["gender"].FirstOrDefault();
            model.email = request["email"].FirstOrDefault();
            model.address = request["address"].FirstOrDefault();
            model.dateOfBirth = request["dateOfBirth"].FirstOrDefault();
            model.city = request["city"].FirstOrDefault();
            model.state = request["state"].FirstOrDefault();
            model.country = request["country"].FirstOrDefault();
            model.phoneNumber = request["phoneNumber"].FirstOrDefault();
            model.maritalStatus = request["maritalStatus"].FirstOrDefault();
            model.createdBy = request["createdBy"].FirstOrDefault();
            /*  model.sponsorEmail = request["sponsorEmail"].FirstOrDefault()*/
            ;
            model.isSponsor = isSponsor;
            model.productId = productId;


            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<PrincipalDetailViewModel>(model);
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
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = "A valid email address is required"
                       });
            }

            if (!string.IsNullOrWhiteSpace(model.email))
            {
                if (await _service.Avon.HasActiveSubscription(model.email))
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = $"You have an active Subcription/Plan already"
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

            try
            {
                var temlog = new TempLogModel()
                {
                    PayLoad = System.Text.Json.JsonSerializer.Serialize(model),
                    Action = "AddPrincipalDetail",
                    Controller = "PlanSubscription",
                    Message = $"Loging User: {HttpContext.LoggedInUserId()}"
                };
                await _service.Avon.AddToTempLog(temlog);
            }
            catch
            {


            }

            var response = await _service.Avon.AddPrincipalDetail(model, HttpContext.LoggedInUserId());

            if (!response.HasError)

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
                        model.profilePictureUri = fileUri;
                        await _service.Avon.UpdatePrinciDetailProfilePix(fileUri, response.OrderId);
                    }

                }
                catch
                {

                }

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Principal Detail Added Successfully",
                    Data = new
                    {
                        OrderId = response.OrderId,
                        OrderReference = response.OrderReference,
                        ProductId = response.ProductId,
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
        /// Use this end point to Add Principal Details for other sponsors while buying multiple plans 
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
        ///         address:string,
        ///         state:string,
        ///         country:string,
        ///         phoneNumber:string,
        ///         email:string,
        ///         city:string,
        ///         productId:string,
        ///         isSponsor:int,
        ///         orderReference:string
        ///         
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns response object</response>

        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Plans.PlanInitializeOthers)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<PrincResDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddOtherPrincipalDetail()
        {

            var model = new PrincipalDetailViewModelDTO();
            var request = await Request.ReadFormAsync();
            string fileUri = string.Empty;


            _ = int.TryParse(request["productId"].FirstOrDefault(), out int productId);
            _ = int.TryParse(request["isSponsor"].FirstOrDefault(), out int isSponsor);

            model.firstName = request["firstName"].FirstOrDefault();
            model.middleName = request["middleName"].FirstOrDefault();
            model.surname = request["surname"].FirstOrDefault();
            model.title = request["title"].FirstOrDefault();
            model.gender = request["gender"].FirstOrDefault();
            model.email = request["email"].FirstOrDefault();
            model.address = request["address"].FirstOrDefault();
            model.dateOfBirth = request["dateOfBirth"].FirstOrDefault();
            model.city = request["city"].FirstOrDefault();
            model.state = request["state"].FirstOrDefault();
            model.country = request["country"].FirstOrDefault();
            model.phoneNumber = request["phoneNumber"].FirstOrDefault();
            model.maritalStatus = request["maritalStatus"].FirstOrDefault();
            model.createdBy = request["createdBy"].FirstOrDefault();
            model.isSponsor = isSponsor;
            model.productId = productId;


            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<PrincipalDetailViewModelDTO>(model);
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
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = "A valid email address is required"
                       });
            }

            if (!string.IsNullOrWhiteSpace(model.email))
            {
                if (await _service.Avon.HasActiveSubscription(model.email))
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = $"Active Subcription/Plan already Exist for: {model.email}"
                       });
            }

            //if (await _service.Avon.HasActiveSubscription(model.email))
            //    return StatusCode(StatusCodes.Status200OK,
            //       new ApiResponse<object>
            //       {
            //           Data = null,
            //           hasError = true,
            //           Message = $"You have an active Subcription/Plan already"
            //       });


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
            try
            {
                var temlog = new TempLogModel()
                {
                    PayLoad = System.Text.Json.JsonSerializer.Serialize(model),
                    Action = "AddOtherPrincipalDetail",
                    Controller = "PlanSubscription",
                    Message = $"Loging User: {HttpContext.LoggedInUserId()}"
                };
                await _service.Avon.AddToTempLog(temlog);
            }
            catch
            {


            }

            var response = await _service.Avon.AddOtherPrincipalDetail(model, HttpContext.LoggedInUserId());

            if (!response.HasError)

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
                        model.profilePictureUri = fileUri;
                        await _service.Avon.UpdatePrinciDetailOthersProfilePix(fileUri, response.enrolleeId);
                    }

                }
                catch
                {

                }
                if (model.isSponsor == 1)
                {
                    //create account for sponsored enrollee
                    var acctmodel = new UserAccountViewModel()
                    {
                        email = model.email,
                        mobilePhone = model.phoneNumber,
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
                    Message = "Principal Detail Added Successfully",
                    Data = new PrincResDTO()
                    {
                        enrolleeId = response.enrolleeId,
                        OrderReference = response.OrderReference,
                        ProductId = response.ProductId,
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
        /// The EndPoint to call after succesful Plan Payment 
        /// </summary>
        [HttpPost(ApiRoutes.Plans.PlanComplete)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CompleteSubscription([FromBody] CompletePlanSubscriptionDto model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });

            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<CompletePlanSubscriptionDto>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });

            var orderExist = await _service.Avon.IsOrderWithRefExist(model.OrderReference);

            if (!orderExist)
                return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = $"Plan Payment Order with Reference:{model.OrderReference} does not exist"
                       });

            var plan = _service.Plans.AllPlans().FirstOrDefault(x => x.code == model.ProductId);

            if (model.ProductId <= 0 || plan == null)
            {
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Invalid Plan (ProductId): plan with code {model.ProductId} does not exist"
                   });
            }

            if (model.Amount < plan.premium)
            {
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Amount ({model.Amount.ToString("#,##0.00")}) Specified cannot be less than the Premium Amount ({plan.premium.ToString("#,##0.00")}) for the plan you want to buy"
                   });
            }

            if ((model.Amount + model.NHISAmount) != model.TotalAmount)
            {
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Sum of Amount and NHIS Amount does not tally with the Total Amount"
                   });
            }


            var res = await _service.Avon.CompletePlanPurchase(model, HttpContext.User.Identity.Name);

            if (!res.hasError)
            {
                //send mail notice
                try
                {
                    var templateName = "Plan_Payment";

                    var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                    var templateResult = templateBuilder.BuildTemplate(new PlanPaymentEmailModel()
                    {
                        PlanName = plan.planName,
                        _Premium=model.Amount,
                        _nhis=model.NHISAmount,
                        FirstName=res.firstName,
                        LastName=res.lastName,
                        Email=res.email,
                       // Hospital=
                        
                    });

                    _emailService.Send("Thank you for getting the Avon Cover", res.email, templateResult);


                    //var sendersEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);

                    //var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                    //var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);

                    //var emailSender = new SendGridNotification(sendersEmail, sendersName, apiKey);

                   // var emailResponse = await emailSender.SendEmailMailAsync("Thank you for getting the Avon Cover", res.email, templateResult);

                }
                catch
                {

                }

                if (res.createAcct)
                {
                    var acctmodel = new UserAccountViewModel()
                    {
                        email = res.email,
                        firstName = res.firstName,
                        lastName = res.lastName,
                        userName = res.email,
                        password = GenerateToken(8),
                    };

                    await CreateAccount(acctmodel);
                }

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Plan Purchase Completed SuccessFully",
                    Data = new
                    {
                        orderId = res.orderId,
                        orderReference = res.orderReference,
                        enrolleeId = res.enrolleeId,
                        paymentReference = res.paymentReference,
                        productId = res.productId,
                    },
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }




        /// <summary>
        /// The EndPoint to call to update enrollee contact detail after  succesful Plan Payment 
        /// </summary>
        [HttpPost(ApiRoutes.Plans.PlanUpdateContactDetail)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> ContactDetail([FromBody] EnrolleeContactDetailViewModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });

            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<EnrolleeContactDetailViewModel>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });

            if (!string.IsNullOrEmpty(model.email))
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

            var res = await _service.Avon.UpdateEnrolleeContactDetail(model);

            if (!res)
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Enrollee Contact Detail Updated SuccessFully",
                    Data = new
                    {
                        enrolleeId = model.enrolleeId
                    },
                });


            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }


        /// <summary>
        /// The EndPoint to call to update enrollee provider after  succesful Plan Payment 
        /// </summary>
        [HttpPost(ApiRoutes.Plans.PlanUpdateprovider)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> EnrolleeProviderUpdate([FromBody] EnrolleeProviderViewModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });

            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<EnrolleeProviderViewModel>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });

            var res = await _service.Avon.UpdateEnrolleeProviderDetail(model);

            if (!res)
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Enrollee Provider Updated SuccessFully",
                    Data = null,
                });


            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }


        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Plans.bulkPlan)]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> BulkPlanPurchase([FromBody] BuyPlanModel model)
        {
            var request = await Request.ReadFormAsync();
            string fileUri = string.Empty;

            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });

            //validate inputs
            var providers = new List<providerDetailDTO>();

            foreach (var item in model.subscriptions)
            {
                var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<SubscriptionModel>(item);
                if (validationErrors.Any())
                    return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });

                if (!string.IsNullOrWhiteSpace(item.email))
                {
                    if (!item.email.IsEmailAddress())
                        return StatusCode(StatusCodes.Status200OK,
                           new ApiResponse<object>
                           {
                               Data = null,
                               hasError = true,
                               Message = "A valid email address is required"
                           });
                }

                if (!string.IsNullOrWhiteSpace(item.sponsorEmail))
                {
                    if (!item.sponsorEmail.IsEmailAddress())
                        return StatusCode(StatusCodes.Status200OK,
                           new ApiResponse<object>
                           {
                               Data = null,
                               hasError = true,
                               Message = "A valid Sponsored email address is required"
                           });
                }
                if (!string.IsNullOrWhiteSpace(item.contactEmail))
                {
                    if (!item.contactEmail.IsEmailAddress())
                        return StatusCode(StatusCodes.Status200OK,
                           new ApiResponse<object>
                           {
                               Data = null,
                               hasError = true,
                               Message = "A valid Contact email address is required"
                           });
                }

                //validate provider
                var provider = await _service.Toshfa.FetchProviderByProviderCode(item.providerId);

                if (provider == null)
                    return StatusCode(StatusCodes.Status200OK,
                         new ApiResponse<object>
                         {
                             Data = null,
                             hasError = true,
                             Message = $"Provider With ID:{item.providerId} does not exist"
                         });

                var _provider = new providerDetailDTO()
                {
                    ProviderState = provider.State,
                    ProviderLGA = provider.LGA,
                    ProviderName = provider.Name,
                    ProviderId = provider.Code
                };

                providers.Add(_provider);


                //validate plans
                if (item.productId <= 0 || !_service.Plans.AllPlans().Any(x => x.code == item.productId))
                {
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = $"Invalid Plan (ProductId): plan with code {item.productId} does not exist"
                       });
                }


                //check if you already have an active plan and plan not sponsored
                if (await _service.Avon.HasActiveSubscription(item.email))
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = $"An active Subcription/Plan already exist for this email: {item.email}"
                       });



            }

            //check for duplicates 
            if (model.subscriptions.Count() != model.subscriptions.Select(m => m.email).Distinct().Count())
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Subcription/Plan can only be associated with one unique email address"
                   });

            var response = await _service.Avon.AddBulkPlan(model, providers);
            if (response)
            {
                //send mail notice
                try
                {
                    foreach (var item in model.subscriptions)
                    {
                        var plan = _service.Plans.AllPlans().FirstOrDefault(x => x.code == item.productId);
                        if (plan != null)
                        {
                            var templateName = "new_plan_subscription";

                            var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                            var templateResult = templateBuilder.BuildTemplate(new PlanSubscriptionEmailModel()
                            {
                                PlanName = plan.planName,
                            });
                            _emailService.Send("Thank you for getting the Avon Cover", item.email, templateResult);

                            //var sendersEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);

                            //var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                            //var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);

                            //var emailSender = new SendGridNotification(sendersEmail, sendersName, apiKey);

                            //var emailResponse = await emailSender.SendEmailMailAsync("Plan Subscription", item.email, templateResult);
                        }
                    }
                }
                catch
                {

                }

                return StatusCode(StatusCodes.Status200OK,
                 new ApiResponse<object>
                 {
                     Data = null,
                     hasError = true,
                     Message = $"Plan Subcription Succesful"
                 });

            }

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }



        /// <summary>
        /// This endpoint initiate buy plan from avon site
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
        ///         providerId:int,
        ///         dateOfBirth:string (dd/MM/yyyy),
        ///         bloodType:string,
        ///         weight:string,
        ///         height:string,
        ///         enrolleeType:string,
        ///         email:string,
        ///         address:string,
        ///         lga :string,
        ///         state:string,
        ///         country:string,
        ///         phoneNumber:string,
        ///         profilePicture:file,
        ///         mailingAddress:string,
        ///         mailingState:string,
        ///         mailingLga :string,
        ///         productId :string,
        ///         isSponsored:boolean,
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns response object</response>
        [HttpPost, DisableRequestSizeLimit]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [Route(ApiRoutes.Plans.PlanTempInitialize)]
        [AllowAnonymous]
        public async Task<IActionResult> AddOrder()
        {
            var model = new TempEnrolleePayloadModel();
            var request = await Request.ReadFormAsync();

            string fileUri = string.Empty;

            _ = int.TryParse(request["providerId"].FirstOrDefault(), out int providerId);
            _ = int.TryParse(request["productId"].FirstOrDefault(), out int productId);
            _ = decimal.TryParse(request["weight"].FirstOrDefault(), out decimal weight);
            _ = int.TryParse(request["isSponsored"].FirstOrDefault(), out int isSponsored);
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
           

            model.providerId = providerId;
            model.totalAmount = totalAmount;
            model.planRate = planRate;



            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<TempEnrolleePayloadModel>(model);
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

                if (await _service.Avon.HasActiveSubscription(model.email))
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = $"Active Subcription/Plan is already associated with this email: {model.email} "
                       });
            }

            
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


            var response = new Temp_ResData();

            response = await _service.Avon.AddTempEnrollee(model);


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
                        await _service.Avon.UpdateTempEnrolleeProfilePix(fileUri, response.Temp_EnrolleeId);
                    }



                }
                catch
                {

                }



                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Enrollee Added Successfully",
                    Data = new
                    {
                        OrderPaymentRefrence = response.OrderPaymentRefrence,
                        email = response.email,
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
        /// The EndPoint to call after succesful Plan Payment from avon website
        /// </summary>
        [HttpPost(ApiRoutes.Plans.PlanCompletePayment)]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CompletePayment([FromBody] CompletePlanPayment model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });

            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<CompletePlanPayment>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });

            var orderExist = await _service.Avon.IsPaymentOrderWithRefExist(model.OrderPaymentRefrence);

            if (!orderExist)
                return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = $"Plan Payment Order with Reference:{model.OrderPaymentRefrence} does not exist"
                       });

            var plan = _service.Plans.AllPlans().FirstOrDefault(x => x.code == model.ProductId);

            if (model.ProductId <= 0 || plan == null)
            {
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Invalid Plan (ProductId): plan with code {model.ProductId} does not exist"
                   });
            }

            if (model.Amount < plan.premium)
            {
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Amount ({model.Amount.ToString("#,##0.00")}) Specified cannot be less than the Premium Amount ({plan.premium.ToString("#,##0.00")}) for the plan you want to buy"
                   });
            }

            if ((model.Amount + model.NHISAmount) <= 0)
            {
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Invalid Amount"
                   });
            }


            var res = await _service.Avon.CompletePlanPay(model);

            if (!res.hasError)
            {
                //send mail notice
                try
                {
                    var templateName = "new_plan_subscription";

                    var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                    var templateResult = templateBuilder.BuildTemplate(new PlanSubscriptionEmailModel()
                    {
                        PlanName = plan.planName,
                    });
                    _emailService.Send("Thank you for getting the Avon Cover", res.email, templateResult);

                    //var sendersEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);

                    //var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                    //var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);

                    //var emailSender = new SendGridNotification(sendersEmail, sendersName, apiKey);

                    //var emailResponse = await emailSender.SendEmailMailAsync("Plan Subscription", res.email, templateResult);
                }
                catch
                {

                }

                    var acctmodel = new UserAccountViewModel()
                    {
                        email = res.email,
                        firstName = res.firstName,
                        lastName = res.lastName,
                        userName = res.email,
                        password = GenerateToken(8),
                    };

                    await CreateAccount(acctmodel);
                

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Plan Purchase Completed SuccessFully",
                    Data = new
                    {
                        orderReference = res.orderReference,
                        enrolleeId = res.enrolleeId,
                        paymentReference = res.paymentReference,
                        productId = res.productId,
                    },
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }



        /// <summary>
        /// Use this end point to Add Principal Details for other sponsors while buying multiple plans on avon website
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
        ///         address:string,
        ///         state:string,
        ///         country:string,
        ///         phoneNumber:string,
        ///         email:string,
        ///         city:string,
        ///         productId:string,
        ///         isSponsor:int,
        ///         OrderPaymentRefrence:string
        ///         sponsorEmail:string
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns response object</response>

        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Plans.PlanInitializeSiteOthers)]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<PrincResDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddSponsorPrincipalDetail()
        {

            var model = new PrincipalSponsorDetailModel();
            var request = await Request.ReadFormAsync();
            string fileUri = string.Empty;


            _ = int.TryParse(request["productId"].FirstOrDefault(), out int productId);
            _ = int.TryParse(request["isSponsor"].FirstOrDefault(), out int isSponsor);

            model.firstName = request["firstName"].FirstOrDefault();
            model.middleName = request["middleName"].FirstOrDefault();
            model.surname = request["surname"].FirstOrDefault();
            model.title = request["title"].FirstOrDefault();
            model.gender = request["gender"].FirstOrDefault();
            model.email = request["email"].FirstOrDefault();
            model.address = request["address"].FirstOrDefault();
            model.dateOfBirth = request["dateOfBirth"].FirstOrDefault();
            model.city = request["city"].FirstOrDefault();
            model.state = request["state"].FirstOrDefault();
            model.country = request["country"].FirstOrDefault();
            model.phoneNumber = request["phoneNumber"].FirstOrDefault();
            model.maritalStatus = request["maritalStatus"].FirstOrDefault();
            model.sponsorEmail = request["sponsorEmail"].FirstOrDefault();
            model.OrderPaymentRefrence = request["OrderPaymentRefrence"].FirstOrDefault();
            model.isSponsor = isSponsor;
            model.productId = productId;


            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<PrincipalSponsorDetailModel>(model);
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
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = "A valid email address is required"
                       });
            }
            if (!string.IsNullOrWhiteSpace(model.sponsorEmail))
            {
                if (!model.sponsorEmail.IsEmailAddress())
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = "A valid sponsor email address is required"
                       });
            }
            var orderExist = await _service.Avon.IsPaymentOrderWithRefExist(model.OrderPaymentRefrence);

            if (!orderExist)
                return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = $"Order with Reference:{model.OrderPaymentRefrence} does not exist"
                       });

            if (!string.IsNullOrWhiteSpace(model.email))
            {
                if (await _service.Avon.HasActiveSubscription(model.email))
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = $"Active Subcription/Plan already Exist for: {model.email}"
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
            try
            {
                var temlog = new TempLogModel()
                {
                    PayLoad = System.Text.Json.JsonSerializer.Serialize(model),
                    Action = "AddOtherPrincipalDetail",
                    Controller = "PlanSubscription",
                    Message = $"Loging User: {HttpContext.LoggedInUserId()}"
                };
                await _service.Avon.AddToTempLog(temlog);
            }
            catch
            {


            }

            var response = await _service.Avon.AddSponsorPrincipalDetail(model);

            if (!response.HasError)

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
                        await _service.Avon.UpdatePrinciDetailOthersProfilePix(fileUri, response.enrolleeId);
                    }

                }
                catch
                {

                }
                if (model.isSponsor == 1)
                {
                    //create account for sponsored enrollee
                    var acctmodel = new UserAccountViewModel()
                    {
                        email = model.email,
                        mobilePhone = model.phoneNumber,
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
                    Message = "Principal Detail Added Successfully",
                    Data = new PrincResDTO()
                    {
                        enrolleeId = response.enrolleeId,
                        OrderReference = response.OrderReference,
                        ProductId = response.ProductId,
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
        /// Add Item to Cart
        /// </summary>
        /// <remarks>
        /// UniqueReference to uniquely identify cart user: value can be: username, userEmail, enrolleeId, memberNo or any uniqueRef
        /// </remarks>
        /// <response code="200">Returns response object</response>

        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Cart.addtocart)]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddToCart([FromBody] CartDTO model)
        {


            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<CartDTO>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });


            if (model.quantity < 0)
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Invalid Quantity"
                   });





            var response = await _service.Avon.AddToCart(model);

            if (response)
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Item Added To Cart",
                    Data = null

                });


            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }


        /// <summary>
        /// update cart Item
        /// </summary>
        /// <remarks>
        /// UniqueReference to uniquely identify cart user: value can be: username, userEmail, enrolleeId, memberNo or any uniqueRef
        /// </remarks>
        /// <response code="200">Returns response object</response>
        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Cart.updatecart)]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> updateToCart([FromBody] CartPayLoadDTO model)
        {


            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<CartDTO>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });


            if (model.quantity < 0)
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Invalid Quantity"
                   });





            var response = await _service.Avon.UpdateAddToCart(model);

            if (response)
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Cart Item Updated",
                    Data = null

                });


            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }


        /// <summary>
        /// Remove cart Item
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Returns response object</response>

        [HttpGet(ApiRoutes.Cart.remove)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public IActionResult RemoveCartItem([FromRoute] Guid cartId)
        {
            try
            {
                _service.Avon.RemoveCartItem(cartId);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                 new ApiResponse<object>
                 {
                     hasError = true,
                     Data = "",
                     Message = "Unable to remove cart Item ",
                 });
            }
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      hasError = false,
                      Data = "",
                      Message = "cart Item Removed SuccessFully",
                  });
        }

        /// <summary>
        /// Clear All Cart for a user (with a UniqueReference)
        /// </summary>
        /// <remarks>
        /// UniqueReference that uniquely identify cart user: 
        /// </remarks>
        /// <response code="200">Returns response object</response>
        [HttpGet(ApiRoutes.Cart.clearItems)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public IActionResult ClearCartItem([FromRoute] string UniqueReference)
        {
            try
            {
                _service.Avon.ClearCartItem(UniqueReference);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                 new ApiResponse<object>
                 {
                     hasError = true,
                     Data = "",
                     Message = "Unable to remove cart Item ",
                 });
            }
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      hasError = false,
                      Data = "",
                      Message = "cart Item Removed SuccessFully",
                  });
        }

        /// <summary>
        /// Utility to upload a file to get fileUrl
        /// </summary>
        /// <remarks>
        /// Request body:  FormData => var formData =new FormData(); file; etc
        /// </remarks>
        /// <response code="200">Returns response object</response>
        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Plans.uploadUtils)]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> uploadUtility()
        {
            var request = await Request.ReadFormAsync();
            string fileUri = string.Empty;

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
                          Message = $"Invalid Image, image must be any of- {string.Join(";", ImageHelper.AcceptImageExtention)}"
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
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    Data = new
                    {
                        fileUrl = fileUri
                    },
                    hasError = true,
                });
            }
            catch
            {

            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
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

                    _emailService.Send("Login Details", userModel.email, templateResult);

                    //var sendersEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);

                    //var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                    //var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);

                    ////var notifcation = new NotificationService(_service);

                    ////await notifcation.SendNotification("Login Details", userModel.email, templateResult);

                    //var emailSender = new SendGridNotification(sendersEmail, sendersName, apiKey);

                    //var emailResponse = await emailSender.SendEmailMailAsync("Login Details", userModel.email, templateResult);

                }


            }
            catch
            {


            }
        }

       
        /*buy plan from explore*/

        /// <summary>
        /// Add Principal Details while initialize buying of plan from Explore
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
        ///         address:string,
        ///         state:string,
        ///         country:string,
        ///         phoneNumber:string,
        ///         email:string,
        ///         city:string,
        ///         productId:string,
        ///         isSponsor:int,
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns response object</response>

        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Plans.PlanInitializeExplore)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> AddPrincipalExploreDetail()
        {

            var model = new PrincipalDetailExploreModel();
            var request = await Request.ReadFormAsync();
            string fileUri = string.Empty;


            _ = int.TryParse(request["productId"].FirstOrDefault(), out int productId);
            _ = int.TryParse(request["isSponsor"].FirstOrDefault(), out int isSponsor);

            model.firstName = request["firstName"].FirstOrDefault();
            model.middleName = request["middleName"].FirstOrDefault();
            model.surname = request["surname"].FirstOrDefault();
            model.title = request["title"].FirstOrDefault();
            model.gender = request["gender"].FirstOrDefault();
            model.email = request["email"].FirstOrDefault();
            model.address = request["address"].FirstOrDefault();
            model.dateOfBirth = request["dateOfBirth"].FirstOrDefault();
            model.city = request["city"].FirstOrDefault();
            model.state = request["state"].FirstOrDefault();
            model.country = request["country"].FirstOrDefault();
            model.phoneNumber = request["phoneNumber"].FirstOrDefault();
            model.maritalStatus = request["maritalStatus"].FirstOrDefault();

           
            model.isSponsor = isSponsor;
            model.productId = productId;


            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<PrincipalDetailExploreModel>(model);
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
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = "A valid email address is required"
                       });
            }

            if (!string.IsNullOrWhiteSpace(model.email))
            {
                if (await _service.Avon.HasActiveSubscription(model.email))
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = $"An active Subcription is already linked to this email: {model.email}"
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

            try
            {
                var temlog = new TempLogModel()
                {
                    PayLoad = System.Text.Json.JsonSerializer.Serialize(model),
                    Action = "AddPrincipalDetail",
                    Controller = "PlanSubscription",
                    Message = $"Loging User: {HttpContext.LoggedInUserId()}"
                };
                await _service.Avon.AddToTempLog(temlog);
            }
            catch
            {


            }

            var response = await _service.Avon.AddPrincipalDetailExplore(model);

            if (!response.HasError)

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
                        model.profilePictureUri = fileUri;
                        await _service.Avon.UpdatePrinciDetailProfilePix(fileUri, response.OrderId);
                    }

                }
                catch
                {

                }

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Principal Detail Added Successfully",
                    Data = new
                    {
                        OrderId = response.OrderId,
                        OrderReference = response.OrderReference,
                        ProductId = response.ProductId,
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
        /// The EndPoint to call after succesful Plan Payment from Explore
        /// </summary>
        [HttpPost(ApiRoutes.Plans.PlanCompleteExplore)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> CompleteSubscriptionExplore([FromBody] CompletePlanSubscriptionDto model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });

            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<CompletePlanSubscriptionDto>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });

            var orderExist = await _service.Avon.IsOrderWithRefExist(model.OrderReference);

            if (!orderExist)
                return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = $"Plan Payment Order with Reference:{model.OrderReference} does not exist"
                       });

            var plan = _service.Plans.AllPlans().FirstOrDefault(x => x.code == model.ProductId);

            if (model.ProductId <= 0 || plan == null)
            {
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Invalid Plan (ProductId): plan with code {model.ProductId} does not exist"
                   });
            }

            if (model.Amount < plan.premium)
            {
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Amount ({model.Amount.ToString("#,##0.00")}) Specified cannot be less than the Premium Amount ({plan.premium.ToString("#,##0.00")}) for the plan you want to buy"
                   });
            }

            if ((model.Amount + model.NHISAmount) != model.TotalAmount)
            {
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Sum of Amount and NHIS Amount does not tally with the Total Amount"
                   });
            }


            var res = await _service.Avon.CompletePlanPurchaseExplore(model);

            if (!res.hasError)
            {
                //send mail notice
                try
                {
                    var templateName = "Plan_Payment";

                    var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                    var templateResult = templateBuilder.BuildTemplate(new PlanPaymentEmailModel()
                    {
                        PlanName = plan.planName,
                        _Premium = model.Amount,
                        _nhis = model.NHISAmount,
                        FirstName = res.firstName,
                        LastName = res.lastName,
                        Email = res.email,
                        // Hospital=

                    });

                    _emailService.Send("Thank you for getting the Avon Cover", res.email, templateResult);




                }
                catch
                {

                }


                var acctmodel = new UserAccountViewModel()
                {
                    email = res.email,
                    firstName = res.firstName,
                    lastName = res.lastName,
                    userName = res.email,
                    password = GenerateToken(8),
                };

                await CreateAccount(acctmodel);


                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Plan Purchase Completed SuccessFully",
                    Data = new
                    {
                        orderId = res.orderId,
                        orderReference = res.orderReference,
                        enrolleeId = res.enrolleeId,
                        paymentReference = res.paymentReference,
                        productId = res.productId,
                    },
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }


        /// <summary>
        /// The EndPoint to call to update enrollee contact detail after  succesful Plan Payment from Explore
        /// </summary>
        [HttpPost(ApiRoutes.Plans.PlanUpdateContactDetailExplore)]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> ContactDetailExploreExplore([FromBody] EnrolleeContactDetailViewModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });

            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<EnrolleeContactDetailViewModel>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });

            if (!string.IsNullOrEmpty(model.email))
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

            var res = await _service.Avon.UpdateEnrolleeContactDetail(model);

            if (!res)
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Enrollee Contact Detail Updated SuccessFully",
                    Data = new
                    {
                        enrolleeId = model.enrolleeId
                    },
                });


            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }


        /// <summary>
        /// The EndPoint to call to update enrollee provider after  succesful Plan Payment from Explore
        /// </summary>
        [HttpPost(ApiRoutes.Plans.PlanUpdateproviderExplore)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> EnrolleeProviderUpdateExplore([FromBody] EnrolleeProviderViewModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });

            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<EnrolleeProviderViewModel>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });

            var res = await _service.Avon.UpdateEnrolleeProviderDetail(model);

            if (!res)
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Enrollee Provider Updated SuccessFully",
                    Data = null,
                });


            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }


        /// <summary>
        /// Use this end point to Add Principal Details for other sponsors while buying multiple plans from Explor
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
        ///         address:string,
        ///         state:string,
        ///         country:string,
        ///         phoneNumber:string,
        ///         email:string,
        ///         city:string,
        ///         productId:string,
        ///         isSponsor:int,
        ///         orderReference:string
        ///         sponsorEmail:string
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns response object</response>

        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Plans.PlanInitializeOthersExplore)]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<PrincResDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddOtherPrincipalDetailExplore()
        {

            var model = new PrincipalDetailModelExplore();
            var request = await Request.ReadFormAsync();
            string fileUri = string.Empty;


            _ = int.TryParse(request["productId"].FirstOrDefault(), out int productId);
            _ = int.TryParse(request["isSponsor"].FirstOrDefault(), out int isSponsor);

            model.firstName = request["firstName"].FirstOrDefault();
            model.middleName = request["middleName"].FirstOrDefault();
            model.surname = request["surname"].FirstOrDefault();
            model.title = request["title"].FirstOrDefault();
            model.gender = request["gender"].FirstOrDefault();
            model.email = request["email"].FirstOrDefault();
            model.address = request["address"].FirstOrDefault();
            model.dateOfBirth = request["dateOfBirth"].FirstOrDefault();
            model.city = request["city"].FirstOrDefault();
            model.state = request["state"].FirstOrDefault();
            model.country = request["country"].FirstOrDefault();
            model.phoneNumber = request["phoneNumber"].FirstOrDefault();
            model.maritalStatus = request["maritalStatus"].FirstOrDefault();
            model.sponsorEmail = request["sponsorEmail"].FirstOrDefault();
            model.orderReference = request["orderReference"].FirstOrDefault();
            model.isSponsor = isSponsor;
            model.productId = productId;


            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<PrincipalDetailModelExplore>(model);
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
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = "A valid email address is required"
                       });
            }

            if (!string.IsNullOrWhiteSpace(model.email))
            {
                if (await _service.Avon.HasActiveSubscription(model.email))
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = $"Active Subcription already linked to Email: {model.email}"
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
            try
            {
                var temlog = new TempLogModel()
                {
                    PayLoad = System.Text.Json.JsonSerializer.Serialize(model),
                    Action = "AddOtherPrincipalDetail",
                    Controller = "PlanSubscription",
                    Message = $"Loging User: {HttpContext.LoggedInUserId()}"
                };
                await _service.Avon.AddToTempLog(temlog);
            }
            catch
            {


            }

            var response = await _service.Avon.AddOtherPrincipalDetailExplore(model);

            if (!response.HasError)

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
                        model.profilePictureUri = fileUri;
                        await _service.Avon.UpdatePrinciDetailOthersProfilePix(fileUri, response.enrolleeId);
                    }

                }
                catch
                {

                }
                if (model.isSponsor == 1)
                {
                    //create account for sponsored enrollee
                    var acctmodel = new UserAccountViewModel()
                    {
                        email = model.email,
                        mobilePhone = model.phoneNumber,
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
                    Message = "Principal Detail Added Successfully",
                    Data = new PrincResDTO()
                    {
                        enrolleeId = response.enrolleeId,
                        OrderReference = response.OrderReference,
                        ProductId = response.ProductId,
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
        /// The EndPoint to call after succesful Plan Payment While Renewing Plan
        /// </summary>
        [HttpPost(ApiRoutes.Plans.PlanRenew)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> RenewPlan([FromBody] CompletePlanRenewal model)
        {

            var plan = _service.Plans.AllPlans().FirstOrDefault(x => x.code == model.NewPlanId);

            if (model.NewPlanId <= 0 || plan == null)
            {
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Invalid Plan (ProductId): plan with code {model.NewPlanId} does not exist"
                   });
            }

            if (model.Amount < plan.premium)
            {
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = $"Amount ({model.Amount.ToString("#,##0.00")}) Specified cannot be less than the Premium Amount ({plan.premium.ToString("#,##0.00")}) for the plan you want to buy"
                   });
            }

            var res = await _service.Avon.RenewPlan(model, HttpContext.User.Identity.Name);

            if (!res.hasError)
            {
                //send mail notice
                try
                {
                    var templateName = "Plan_Payment_Renewal";

                    var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                    var templateResult = templateBuilder.BuildTemplate(new PlanPaymentEmailModel()
                    {
                        PlanName = plan.planName,
                        _Premium = model.Amount,
                        _nhis = model.NHISAmount,
                        FirstName = res.firstName,
                        LastName = res.lastName,
                        Email = res.email,

                    });

                    _emailService.Send("Thank you for getting the Avon Cover", res.email, templateResult);

                }
                catch
                {

                }

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Plan Renewal Completed SuccessFully",
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }
    }
}
