using AvonHMO.API.Contracts;
using AvonHMO.API.Controllers;
using AvonHMO.API.Helpers;
using AvonHMO.API.Models;
using AvonHMO.API.Models.EmailTemplateTokens;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.Application.ViewModels.Avon.Communication;
using AvonHMO.Application.ViewModels.Avon.EnrolleFlow;
using AvonHMO.Application.ViewModels.Avon.SelfService;
using AvonHMO.Application.ViewModels.Avon.ViewModels;
using AvonHMO.Application.ViewModels.Toshfa;
using AvonHMO.Common;
using AvonHMO.Communications.Sendgrid;
using AvonHMO.Domain.Interfaces;
using AvonHMO.Domain.Interfaces.Avon;
using BrightStar.Util.Storage.RepoManager;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AvonHMO.Application.ViewModels.Avon.Explore;
using static AvonHMO.Application.ViewModels.Avon.Explore.CompliantViewModel;

namespace AvonHMO.API.Areas.Enrollee.Controllers
{
  
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    public class SelfServiceController : BaseController
    {
        private readonly IRepositoryManager _service;
        //private readonly IAuthenticationRepository _authRepo;
        private readonly IStorageRepoManager _storageService;
        private readonly IConfiguration _config;
        IWebHostEnvironment _env;
        IEmailService _emailService;
        public SelfServiceController(IRepositoryManager service, IStorageRepoManager storageService, IConfiguration config, IWebHostEnvironment env, IEmailService emailService)
        {
            _service = service;
            //_authRepo = authRepo;
            _storageService = storageService;
            _config = config;
            _env = env;
            _emailService = emailService;
        }




        /// <summary>
        /// Add Enrollee request for dependant 
        /// </summary> 
        /// <remarks>
        /// Request body:  FormData => var formData =new FormData(); formData.Append("title","somevalue"); etc
        ///     
        ///     {
        ///         title: string
        ///         firstName:string,
        ///         surname:string,
        ///         gender:string,
        ///         phoneNumber:string,
        ///         email:string,
        ///         maritalStatus:string,
        ///         dateOfBirth:string (dd/MM/yyyy),
        ///         relationshipId:string,
        ///         yourPlan: string, //1 or 0
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns response object</response>
        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Actions.PostDependantRequest)]
        public async Task<IActionResult> AddDependantRequest()
        {

            var model = new DependantRequestPayloadModel();
            var request = await Request.ReadFormAsync();

            string fileUri = string.Empty;


            var userId = loggedInUserId;

            model.userId = Guid.Parse(userId);
            // model.userId = Guid.Parse("2D6E2ED4-ACC6-4675-8EF8-CB35E76891AD");



            var userExist = await _service.Avon.IsEnrolleeExist(model.userId);

            if (!userExist)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = true,
                    Message = "You do not have an active plan/subscription",
                    Data = null
                });
            }







            model.Title = request["Title"].FirstOrDefault();
            model.FirstName = request["FirstName"].FirstOrDefault();
            model.Surname = request["Surname"].FirstOrDefault();
            model.MaritalStatus = request["MaritalStatus"].FirstOrDefault();
            //model.EnrolleeId = request["EnrolleeId"].FirstOrDefault();
            model.Gender = request["Gender"].FirstOrDefault();
            model.Email = request["Email"].FirstOrDefault();
            model.PhoneNumber = request["PhoneNumber"].FirstOrDefault();
            model.RelationshipId = request["RelationshipId"].FirstOrDefault();
            model.DateOfBirth = request["DateOfBirth"].FirstOrDefault();
            //var yourPlan = request["YourPlan"].FirstOrDefault();
            model.YourPlan = 0; // Convert.ToInt32(yourPlan);



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
                    model.PicturePath = fileUri;
                }

            }
            catch
            {

            }


            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<DependantRequestPayloadModel>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });


            var today = DateTime.Today;
            var birthdate = model.DateOfBirth.ToDateTime("dd/MM/yyyy");
            if (birthdate > today)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = true,
                    Message = "Birthdate cannot be in the future",
                    Data = null
                });
            }

            var age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age)) age--;

            string memberNo = "";

            var getUser = await _service.Enrollee.FetchBasicLocalEnrollee(model.userId);
            var curPlanDetail = new CurrentPlanDetail();
            if (getUser != null)
            {
                 memberNo = getUser.MemberNo.ToString() ?? "0";
                //memberNo = "54226";
                curPlanDetail = await _service.Toshfa.GetCurrendEnrollePlan(memberNo);
            }

            if (curPlanDetail != null)
            {

                if (age >= curPlanDetail.MaxSonAgeYear && model.RelationshipId.ToLower() == "son")
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                    {
                        hasError = true,
                        Message = $"Son's Age should be below {curPlanDetail.MaxSonAgeYear}",
                        Data = null
                    });
                }
                if (age >= curPlanDetail.MaxDaughterAgeYear && model.RelationshipId.ToLower() == "daughter")
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                    {
                        hasError = true,
                        Message = $"Daughter's Age should be below {curPlanDetail.MaxDaughterAgeYear}",
                        Data = null
                    });
                }
                if (age >= curPlanDetail.MaxSonAgeYear && model.RelationshipId.ToLower() == "children")
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                    {
                        hasError = true,
                        Message = $"Child's Age should be below {curPlanDetail.MaxSonAgeYear}",
                        Data = null
                    });
                }

                var spouseExist = await _service.Avon.CheckDependantSpouseExist(model.userId);
                if (spouseExist && model.RelationshipId.ToLower() == "spouse")
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                    {
                        hasError = true,
                        Message = $"You can't have more than a Spouse attached to this plan",
                        Data = null
                    });
                }
                if (age >= curPlanDetail.maxAge && model.RelationshipId.ToLower() == "spouse")
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                    {
                        hasError = true,
                        Message = $"Spouse's Age should be below {curPlanDetail.maxAge}",
                        Data = null
                    });
                }

            }

            //var getUser = await _service.Enrollee.FetchLocalEnrollee(model.userId);
            var numberOfDepCovered = curPlanDetail.DependantsCovered ?? 0;
            if (numberOfDepCovered == 0)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = true,
                    Message = "You are not eligible to have Dependant for this plan",
                    Data = null
                });
            }
            var dependantCount = await _service.Avon.GetDependantRequestCount(model.userId);


            if (dependantCount >= numberOfDepCovered)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = true,
                    Message = $"Your Dependant Count cannot be more than {numberOfDepCovered}",
                    Data = null
                });
            }

            var response = await _service.Avon.AddDependantRequest(model);

            if (response)
            {
                var templateName = "dependant_request_avon";
                var emailSubject = "Dependant Request";

                var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                var templateResult = templateBuilder.BuildTemplate(new PDependantRequestEmailToken()
                {
                    firstName = getUser.FirstName,
                    dependantFirstName = model.FirstName,
                    surName = model.Surname,
                    gender = model.Gender,
                    relationship = model.RelationshipId,
                    dateOfBirth = model.DateOfBirth,
                    title = model.Title,
                    memberNo = memberNo
                });

                var avonEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);
                var enrollmentEmail = _service.Settings.GetSetting(AvonConstants.Settings.DEPENDANT_REQUEST);

                //var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                //var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);
                               
                _emailService.Send(emailSubject, enrollmentEmail, templateResult);




                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Dependant Request Added Successfully",
                    Data = null
                });
            }


            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<object>
            {
                hasError = true,
                Message = "There was an error creating Dependant Request",
            });
        }

        /// <summary>
        /// This enpoint returns all DependantRequest pagination as parameter
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>dependant request by enrollee</returns>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchDependantRequest)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<DependantRequestViewModel>), StatusCodes.Status200OK)]
        public IActionResult FetchDependantRequest([FromQuery] PagingParam pagination)
        {

            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<DependantRequestViewModel>
                {
                    Data = _service.Avon.FetchDependantRequest(pagination),
                    hasError = false,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    StatusCode = 200,

                });

        }



        /// <summary>
        /// This enpoint returns DependantRequest By Member taking member_no as parameter
        /// </summary>
        /// <param name="memberNo"></param>
        /// <returns>dependant request by enrollee</returns>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchDependantRequestByMember)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<DependantRequestViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FetchDependantRequestByMemberNo([FromRoute] string memberNo)
        {

            var dependantRequest = await _service.Avon.FetchDependantRequestByMemberNo(memberNo);


            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<DependantRequestViewModel>
                {
                    Data = dependantRequest,
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK
                });

        }


        /// <summary>
        /// This enpoint returns DependantRequest For a Loggedon User
        /// </summary>
        /// <param></param>
        /// <returns>DependantRequest by a loggedon User</returns>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchDependantRequestForLoggedOnUser)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<DependantRequestViewModel>), StatusCodes.Status200OK)]
        public IActionResult FetchDependantRequestForLoggedOnUser([FromQuery] PagingParam pagination)
        {
            var userId = loggedInUserId;
            var enrolleeID = Guid.Parse(userId);

            var dependantRequest = _service.Avon.FetchDependantRequestForLoggedOnUser(pagination, enrolleeID);


            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<DependantRequestViewModel>
                {
                    Data = dependantRequest,
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK
                });

        }

        /// <summary>
        /// Add  request for DrugRefill 
        /// </summary>
        /// <remarks>
        /// Request body:  FormData => var formData =new FormData(); formData.Append("firstname","somevalue"); etc
        ///     
        /// {
        ///   "firstname": string,
        ///   "surname":"string,
        ///   "phoneNumber": string,
        ///   "email":string,
        ///   "deliverAddress": string,
        ///   "dateOfBirth": string //dd/MM/yyyy
        ///   "monthlyRefill": int //0 or 1
        ///  }
        /// </remarks>
        /// <response code="200">Returns response object</response>
        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Actions.PostDrugRefillRequest)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddDrugRefillRequest()
        {

            var model = new DrugRefillRequestViewModel();
            var request = await Request.ReadFormAsync();

            string fileUri = string.Empty;

            var userId = loggedInUserId;
            model.userId = Guid.Parse(userId);
            // model.userId = Guid.Parse("0D4E56D6-4600-44B4-8404-EE52FF7E7323");




            var userExist = await _service.Avon.IsEnrolleeExist(model.userId);

            if (!userExist)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = true,
                    Message = "You do not have an active plan/subscription",
                    Data = null
                });
            }



            model.FirstName = !string.IsNullOrWhiteSpace(request["FirstName"]) ? request["FirstName"].FirstOrDefault() : "";
            model.Surname = request["Surname"].FirstOrDefault();
            //model.MemberNo = request["MemberNo"].FirstOrDefault();
            //model.EnrolleeId = request["EnrolleeId"].FirstOrDefault();
            model.PhoneNumber = request["PhoneNumber"].FirstOrDefault();
            model.Email = request["Email"].FirstOrDefault();
            model.DeliverAddress = request["DeliverAddress"].FirstOrDefault();
            model.DateOfBirth = request["DateOfBirth"].FirstOrDefault();
            var monthlyRefill = request["MonthlyRefill"].FirstOrDefault();
            model.MonthlyRefill = string.IsNullOrWhiteSpace(monthlyRefill) ? 0 : Convert.ToInt32(monthlyRefill);




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
                    model.PrescriptionPath = fileUri;
                }

            }
            catch
            {

            }


            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<DrugRefillRequestViewModel>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });

            bool response;

            if (model.FirstName == "" && model.Email == null && model.Surname == null)
            {
                response = await _service.Avon.AddDrugRefillRequestForWeb(model);
            }
            else
            {
                response = await _service.Avon.AddDrugRefillRequest(model);
            }


            if (response)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Drug Refill Request Added Successfully",
                    Data = null
                });
            }


            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "There was an error creating Drug Refill request",
            });
        }


        /// <summary>
        /// Add  request for DrugRefill for Admin
        /// </summary>
        /// <remarks>
        /// Request body:  FormData => var formData =new FormData(); formData.Append("firstname","somevalue"); etc
        ///     
        /// {
        ///   "EnrolleeID": string,
        ///   "monthlyRefill": int //0 or 1
        ///  }
        /// </remarks>
        /// <response code="200">Returns response object</response>
        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Actions.PostDrugRefillRequestForAdmin)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddDrugRefillRequestForAdmin()
        {

            var model = new DrugRefillRequestViewModel();
            var request = await Request.ReadFormAsync();

            string fileUri = string.Empty;


            var enrolleeId = request["EnrolleeId"].FirstOrDefault();
            model.EnrolleeId = Guid.Parse(enrolleeId);

            var monthlyRefill = request["MonthlyRefill"].FirstOrDefault();
            model.MonthlyRefill = string.IsNullOrWhiteSpace(monthlyRefill) ? 0 : Convert.ToInt32(monthlyRefill);




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
                    model.PrescriptionPath = fileUri;
                }

            }
            catch
            {

            }


            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<DrugRefillRequestViewModel>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });




            var response = await _service.Avon.AddDrugRefillRequestForAdmin(model);

            if (response)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Drug Refill Request Added Successfully",
                    Data = null
                });
            }


            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "There was an error creating Drug Refill request",
            });
        }


        /// <summary>
        /// This enpoint returns DrugRefillRequest By Member taking member_no as parameter
        /// </summary>
        /// <param name="member_no"></param>
        /// <returns>drugRefill request by enrollee</returns>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchDrugRefillRequestByMember)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<DrugRefillRequestViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FetchDrugRefillRequestByMemberNo([FromRoute] string member_no)
        {

            var drugRefillRequest = await _service.Avon.FetchDrugRefillRequestByMemberNo(member_no);


            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<DrugRefillRequestViewModel>
                {
                    Data = drugRefillRequest,
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK
                });

        }

        /// <summary>
        /// This enpoint returns DrugRefillRequest For a Loggedon User
        /// </summary>
        /// <param></param>
        /// <returns>drugRefill request for loggedon User</returns>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchDrugRefillRequestForLoggedOnUser)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<DrugRefillRequestViewModel>), StatusCodes.Status200OK)]
        public IActionResult FetchDrugRefillRequestForLoggedOnUser([FromQuery] PagingParam pagination)
        {
            var userId = loggedInUserId;
            var enrolleeID = Guid.Parse(userId);
            // var enrolleeID = Guid.Parse("7E1FE828-6C14-4A1F-AF3B-6250E36B4C39");
            var drugRefillRequest = _service.Avon.FetchDrugRefillRequestForLoggedOnUser(pagination, enrolleeID).ToList();


            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<DrugRefillRequestViewModel>
                {
                    Data = drugRefillRequest,
                    hasError = false,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    StatusCode = StatusCodes.Status200OK
                });

        }

        /// <summary>
        /// This enpoint returns DrugRefillRequest For a Loggedon User with Status
        /// </summary>
        /// <param></param>
        /// <returns>drugRefill request for loggedon User</returns>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchDrugRefillRequestForLoggedOnUserWithStatus)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<DrugRefillRequestViewModel>), StatusCodes.Status200OK)]
        public IActionResult FetchDrugRefillRequestForLoggedOnUserWithStatus([FromQuery] PagingParam pagination, [FromRoute] string status)
        {
            var userId = loggedInUserId;
            var enrolleeID = Guid.Parse(userId);

            var drugRefillRequest = _service.Avon.FetchDrugRefillRequestForLoggedOnUserWithStatus(pagination, enrolleeID, status).ToList();


            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<DrugRefillRequestViewModel>
                {
                    Data = drugRefillRequest,
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK
                });

        }

        /// <summary>
        /// This enpoint returns DrugRefillRequest For a Loggedon User with State
        /// </summary>
        /// <param></param>
        /// <returns>drugRefill request for loggedon User</returns>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchDrugRefillRequestForLoggedOnUserWithState)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<DrugRefillRequestViewModel>), StatusCodes.Status200OK)]
        public IActionResult FetchDrugRefillRequestForLoggedOnUserWithState([FromQuery] PagingParam pagination, [FromRoute] int reqState)
        {
            var userId = loggedInUserId;
            var enrolleeID = Guid.Parse(userId);
            // enrolleeID = Guid.Parse("F17CB8F7-F286-4BCD-9055-E62C0B9F81AD");
            var _reqState = Convert.ToBoolean(reqState);


            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<DrugRefillRequestViewModel>
                {
                    Data = _service.Avon.FetchDrugRefillRequestForLoggedOnUserWithState(pagination, enrolleeID, _reqState),
                    hasError = false,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    StatusCode = StatusCodes.Status200OK
                });

        }



        /// <summary>
        /// This enpoint returns DrugRefillRequest For a Loggedon User with State
        /// </summary>
        /// <param></param>
        /// <returns>drugRefill request for loggedon User</returns>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchDrugRefillRequestForLoggedOnUserWithStateAndState)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<DrugRefillRequestViewModel>), StatusCodes.Status200OK)]
        public IActionResult FetchDrugRefillRequestForLoggedOnUserWithStateAndStatus([FromQuery] PagingParam pagination, [FromRoute] int reqState, [FromRoute] string status)
        {
            var userId = loggedInUserId;
            var enrolleeID = Guid.Parse(userId);
            var _reqState = Convert.ToBoolean(reqState);

            var drugRefillRequest = _service.Avon.FetchDrugRefillRequestForLoggedOnUserWithStateAndStatus(pagination, enrolleeID, _reqState, status).ToList();


            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<DrugRefillRequestViewModel>
                {
                    Data = drugRefillRequest,
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK
                });

        }

        /// <summary>
        /// This enpoint returns all DrugRefill Request taking pagination as parameter
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>drugRefill request by enrollee</returns>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchDrugRefillRequest)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<DrugRefillRequestViewModel>), StatusCodes.Status200OK)]
        public IActionResult FetchDrugRefillRequest([FromQuery] PagingParam pagination)
        {

            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<DrugRefillRequestViewModel>
                {
                    Data = _service.Avon.FetchDrugRefillRequest(pagination),
                    hasError = false,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    StatusCode = 200,

                });

        }

        /// <summary>
        /// This endpoint update drugrefill status
        /// </summary>
        /// <param name="refillModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Actions.UpdateDrugRefillStatus)]
        public async Task<IActionResult> UpdateDrugRefillStatus([FromBody] DrugRefillUpdateViewModel refillModel)
        {

            if (refillModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<DrugRefillUpdateViewModel>(refillModel);


            if (errorMessage.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessage)
                    });

            var refillExist = await _service.Avon.IsDrugRefillIDExist(refillModel.DrugRefillRequestId);

            if (!refillExist)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = true,
                    Message = "This DrugRefill does not exist",
                    Data = null
                });
            }

            var createResult = await _service.Avon.UpdateDrugRefillStatus(refillModel);

            if (createResult)
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = "Drug Refill status updated successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error updating Drug Refill status"
                    });
            }

        }

        /// <summary>
        /// This endpoint returns DrugRefill detail by supplying refill ID
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<DrugRefillRequestViewModel>), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Actions.GetDrugRefillDetailById)]
        public async Task<IActionResult> GetDrugRefillDetailById([FromRoute] Guid refillID)
        {

            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object>
                {
                    Data = await _service.Avon.GetDrugRefillInfo(refillID),
                    Message = "",
                    StatusCode = 200
                });
        }


        /// <summary>
        /// This endpoint create hospital review
        /// </summary>
        /// <param name="ratingModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Actions.PostProviderRating)]
        public async Task<IActionResult> ProviderRating([FromBody] ProviderRatingRequestModel ratingModel)
        {

            if (ratingModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<ProviderRatingRequestModel>(ratingModel);


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
            //enrolleeID = Guid.Parse("DAABD81B-B340-4CE9-BF72-C6C5E977A6CE");

            var providers = await _service.Toshfa.FetchProviderByProviderCode(ratingModel.ProviderId);
            if (providers == null)
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "Can not find Detail of the Provider"
                   });

            var providerName = providers.Name;
            var createResult = await _service.Avon.CreateProviderRating(ratingModel, enrolleeID, providerName);

            if (createResult)
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = "Hospital Rating saved successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error saving Hospital Rating"
                    });
            }

        }


        [HttpGet]
        [Route(ApiRoutes.Actions.GetProviderRating)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<ProviderRatingViewModel>), StatusCodes.Status200OK)]
        public IActionResult FetchProviderRating([FromQuery] PagingParam pagination, [FromRoute] int providerID)
        {
            var userId = loggedInUserId;
            var enrolleeID = Guid.Parse(userId);
            // enrolleeID = Guid.Parse("F17CB8F7-F286-4BCD-9055-E62C0B9F81AD");
            //var _reqState = Convert.ToBoolean(reqState);


            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<ProviderRatingViewModel>
                {
                    Data = _service.Avon.FetchProviderRatingByProviderID(pagination, providerID),
                    hasError = false,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    StatusCode = StatusCodes.Status200OK
                });

        }


        /// <summary>
        /// This endpoint create hospital review
        /// </summary>
        /// <param name="reviewModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.ExploreAvon.HospitalReview)]
        public async Task<IActionResult> HospitalReviewRequest([FromBody] HospitalReviewRequestModel reviewModel)
        {

            if (reviewModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<HospitalReviewRequestModel>(reviewModel);


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
            //enrolleeID = Guid.Parse("DAABD81B-B340-4CE9-BF72-C6C5E977A6CE");

            var createResult = await _service.Avon.CreateHospitalReview(reviewModel, enrolleeID);

            if (createResult)
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = "Hospital Review saved successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error saving Hospital Review"
                    });
            }

        }


        /// <summary>
        /// This enpoint returns all RequestRefund taking pagination as parameter
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>RequestRefund by enrollee</returns>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchRequestRefund)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<RequestRefundViewModel>), StatusCodes.Status200OK)]
        public IActionResult FetchRequestRefund([FromQuery] PagingParam pagination)
        {
            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<RequestRefundViewModel>
                {
                    Data = _service.Avon.FetchRequestRefund(pagination),
                    hasError = false,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    StatusCode = 200,

                });

        }





        /// <summary>
        /// Add  request for Request Refund 
        /// </summary> 
        /// <remarks>
        /// Request body:  FormData => var formData =new FormData(); formData.Append("title","somevalue"); etc
        ///     
        ///     {
        ///         reason: string
        ///         amount:string,
        ///         hospitalName:string,
        ///         hospitalLocation:string,
        ///         pACode:string,
        ///         encounteredDate:string (dd/MM/yyyy),
        ///         companyName:string,
        ///         beneficiaryName: string, 
        ///         bankName: string, 
        ///         accountNumber: string, 
        ///         medicalReportDoc: string, 
        ///         receiptsDoc: string, 
        ///         invoiceDoc: string, 
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns response object</response>
        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Actions.PostRequestRefund)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostRequestRefund()
        {
            var model = new RequestRefundRequestModel();
            var request = await Request.ReadFormAsync();
            string fileUri = string.Empty;
            string fileUri1 = string.Empty;
            string fileUri2 = string.Empty;

            List<string> fileUris = new List<string>();



            var userId = loggedInUserId;
            var enrolleeID = Guid.Parse(userId);


            //var enrolleeID = Guid.Parse("A0E46C60-6EED-41AE-A9E8-189A760E60C2");

            var userExist = await _service.Avon.IsEnrolleeExist(enrolleeID);

            if (!userExist)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = true,
                    Message = "You do not have an active plan/subscription",
                    Data = null
                });
            }




            model.Reason = request["Reason"].FirstOrDefault();
            model.Amount = request["Amount"].FirstOrDefault();
            model.EncounteredDate = request["EncounteredDate"].FirstOrDefault();
            model.HospitalName = request["HospitalName"].FirstOrDefault();
            model.HospitalLocation = request["HospitalLocation"].FirstOrDefault();
            model.PACode = request["PACode"].FirstOrDefault();
            model.CompanyName = request["CompanyName"].FirstOrDefault();
            model.BeneficiaryName = request["BeneficiaryName"].FirstOrDefault();
            model.BankName = request["BankName"].FirstOrDefault();
            model.AccountNumber = request["AccountNumber"].FirstOrDefault();


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
                            fileUris.Add(fileUri);
                        }
                    }

                    formFile = request.Files[1];
                    if (formFile != null)
                    {
                        var storageContainer = _config.GetSection("Azure:AzureStorageContainer").Value;
                        var uploadResponse = await _storageService.AzureStorage.UploadAsync(formFile, storageContainer);
                        if (uploadResponse != null)
                        {
                            fileUri1 = uploadResponse.fileUri;
                            fileUris.Add(fileUri1);
                        }
                    }

                    formFile = request.Files[2]; 

                    if (formFile != null)
                    {
                        var storageContainer = _config.GetSection("Azure:AzureStorageContainer").Value;
                        var uploadResponse = await _storageService.AzureStorage.UploadAsync(formFile, storageContainer);
                        if (uploadResponse != null)
                        {
                            fileUri2 = uploadResponse.fileUri;
                            fileUris.Add(fileUri2);
                        }
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                    {
                        hasError = true,
                        Message = "Kindly upload required documents",
                        Data = null
                    });
                }

                if (!string.IsNullOrEmpty(fileUri))
                {
                    model.MedicalReportDoc = fileUri;
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                    {
                        hasError = true,
                        Message = "Kindly upload Medical Report",
                        Data = null
                    });
                }


                if (!string.IsNullOrEmpty(fileUri1))
                {
                    model.ReceiptsDoc = fileUri1;
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                    {
                        hasError = true,
                        Message = "Kindly upload Receipt of payment",
                        Data = null
                    });
                }


                if (!string.IsNullOrEmpty(fileUri2))
                {
                    model.InvoiceDoc = fileUri2;
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                    {
                        hasError = true,
                        Message = "Kindly upload Invoice",
                        Data = null
                    });
                }

            }
            catch
            {

            }


            if (model == null) return StatusCode(StatusCodes.Status400BadRequest,
                  new ApiResponse<object> { Data = null, Message = "Bad Request" });


            //var paString = "AVH/";
            //var validPACode = model.PACode.Contains(paString) && model.PACode.Length == 10;
            //if (!validPACode)
            //{
            //    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            //    {
            //        hasError = true,
            //        Message = "Kindly capture a valid PACode",
            //        Data = null
            //    });
            //}

            var today = DateTime.Today;
            var encounterDate = model.EncounteredDate.ToDateTime("dd/MM/yyyy");
            if (encounterDate > today)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = true,
                    Message = "Encounter Date cannot be in the future",
                    Data = null
                });
            }


            var noOfDays = (today - encounterDate).Days;
            if (noOfDays > 30)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = true,
                    Message = "Encounter Date cannot be more than 30 days from today",
                    Data = null
                });
            }


            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<RequestRefundRequestModel>(model);


            if (errorMessage.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessage)
                    });


            var createResult = await _service.Avon.CreateRequestRefund(model, enrolleeID);

            if (createResult)
            {
                var getUser = await _service.Enrollee.FetchBasicLocalEnrollee(enrolleeID);
                //getUser.EMAIL = "osfolaranmi@gmail.com";

                var templateName = "request_refund_enrollee";
                var templateNameClaim = "request_refund_to_claims";
                var emailSubject = "Request Refund";

                var templateBuilder = new EmailTemplateBuilder(_env, templateName);
                var templateBuilderClaim = new EmailTemplateBuilder(_env, templateNameClaim);

                //var encounterDate = model.EncounteredDate.ToDateTime("dd/MM/yyyy");

                var templateResult = templateBuilder.BuildTemplate(new RequestRefundEmailToken()
                {
                    firstName = getUser.FirstName,
                    lastName = getUser.SurName,
                    monthYear = encounterDate.ToString("MMM, yy"),
                    dateReceived = DateTime.Now.ToString("dd/MM/yyyy"),
                    amount = model.Amount //.ToString("0.##")
                });
                var templateResultClaim = templateBuilder.BuildTemplate(new RequestRefundEmailToken()
                {
                    firstName = getUser.FirstName,
                    lastName= getUser.SurName,
                    paCode = model.PACode ?? "",
                    monthYear = encounterDate.ToString("MMM, yy"),
                    dateReceived = DateTime.Now.ToString("dd/MM/yyyy"),
                    amount = model.Amount //.ToString("0.##")
                });

                var avonEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);
                var claimEmail = _service.Settings.GetSetting(AvonConstants.Settings.CLAIM_EMAIL);

                var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                             

                _emailService.Send(emailSubject, getUser.EMAIL, templateResult,null,null, fromEmail: avonEmail); 

                using (MemoryStream ms = new MemoryStream())
                {
                    // Creates the zip.
                    using (ZipArchive archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                    {
                        int count = 0;
                        foreach (string uploadedFile in fileUris)
                        {
                            FileInfo file = new FileInfo(uploadedFile);
                            // Creates empty file and names it inside of zip.
                            ZipArchiveEntry zipItem = archive.CreateEntry(file.Name + file.Extension);
                            // Add file to zipItem.
                            using (var msFile = request.Files[count].OpenReadStream())
                            {
                                using (Stream stream = zipItem.Open())
                                {
                                    msFile.CopyTo(stream);
                                }
                            }
                            count++;
                        }
                    }

                    var attachmentFIleName = $"{getUser.FirstName}_Receipt.zip";

                    _emailService.Send(emailSubject, claimEmail, templateResultClaim, ms, attachmentFIleName, fromEmail: avonEmail);

                    //var attachmentByte = ms.ToArray();

                    //attachment = Convert.ToBase64String(attachmentByte);

                }              

              

                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = "Refund Request created successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error creating Refund Request"
                    });
            }

        }



        /// <summary>
        /// This enpoint returns Refund Request By Member taking member_no as parameter
        /// </summary>
        /// <param name="member_no"></param>
        /// <returns>refund request by enrollee</returns>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchRequestRefundByMember)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<RequestRefundViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FetchRequestRefundByMemberNo([FromRoute] string member_no)
        {

            var refundRequest = await _service.Avon.FetchRequestRefundByMemberNo(member_no);


            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<RequestRefundViewModel>
                {
                    Data = refundRequest,
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK
                });

        }


        /// <summary>
        /// This enpoint returns RequestRefund For a Loggedon User
        /// </summary>
        /// <param></param>
        /// <returns>RequestRefund for loggedon user</returns>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchRequestRefundForLoggedOnUser)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<RequestRefundViewModel>), StatusCodes.Status200OK)]
        public IActionResult FetchRequestRefundForLoggedOnUser([FromQuery] PagingParam pagination)
        {
            var userId = loggedInUserId;
            var enrolleeID = Guid.Parse(userId);

            var refundRequest = _service.Avon.FetchRequestRefundForLoggedOnUser(pagination, enrolleeID);


            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<RequestRefundViewModel>
                {
                    Data = refundRequest,
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK
                });

        }

        /// <summary>
        /// This endpoint is to create enrollee recommendation
        /// </summary>
        /// <param name="recommendModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Actions.PostEnrolleeRecommendation)]
        public async Task<IActionResult> PostEnrolleeRecommendation([FromBody] EnrolleeRecommendationRequestModel recommendModel)
        {

            if (recommendModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<EnrolleeRecommendationRequestModel>(recommendModel);


            if (errorMessage.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessage)
                    });

            var providerID = recommendModel.BeneficairyId;
            var provider = new HmoProvidersViewModel();
            if (!string.IsNullOrWhiteSpace(providerID))
            {
                var _providerID = int.Parse(providerID);
                provider = await _service.Toshfa.FetchProviderByProviderCode(_providerID);
                recommendModel.BeneficairyName = provider.Name ?? "";
            }

            var createResult = await _service.Avon.CreateEnrolleeRecommendation(recommendModel);
            var userId = loggedInUserId;
            var enrolleeID = Guid.Parse(userId);
            var getUser = await _service.Enrollee.FetchBasicLocalEnrollee(enrolleeID);


            if (createResult)
            {
                

                var templateName = "recommendation";
                var emailSubject = "User's Recommendation";

                var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                var templateResult = templateBuilder.BuildTemplate(new RecommendationEmailToken()
                {
                    senderName = getUser.FirstName +" "+getUser.SurName,
                    email = getUser.EMAIL,
                    provider = recommendModel.BeneficairyName ?? "",
                    recommendation = recommendModel.Recommendation
                });

                var avonEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);
                var infoEmail = _service.Settings.GetSetting(AvonConstants.Settings.RECOMMEDATION_EMAIL);

                var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);


                //var emailSender_Avon = new SendGridNotification(avonEmail, sendersName, apiKey);

                //var emailResponse_Avon = await emailSender_Avon.SendEmailMailAsync(emailSubject, infoEmail, templateResult);
                _emailService.Send(emailSubject, infoEmail, templateResult);



                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = "Recommendation created successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error creating Recommendation"
                    });
            }

        }

        /// <summary>
        /// This enpoint returns all Enrollee Recommendation taking pagination as parameter
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>Enrollee recommendation</returns>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchEnrolleeRecommendation)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<EnrolleeRecommendationViewModel>), StatusCodes.Status200OK)]
        public IActionResult FetchEnrolleeRecommendation([FromQuery] PagingParam pagination)
        {

            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<EnrolleeRecommendationViewModel>
                {
                    Data = _service.Avon.FetchEnrolleeRecommendation(pagination),
                    hasError = false,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    StatusCode = 200,

                });

        }


        /// <summary>
        /// The EndPoint to call to make change of provider request 
        /// </summary>
        [HttpPost(ApiRoutes.Actions.ChangePrimaryProviderRequest)]
        public async Task<IActionResult> ChangeProviderRequest([FromBody] ChangeProviderRequestModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });

            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<ChangeProviderRequestModel>(model);

            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });

            var userId = Guid.Parse(loggedInUserId);
            var enrollee = (await _service.Avon.GetEnrollee()).Where(k => k.enrolleeAccountId == userId).FirstOrDefault();

            if (enrollee == null)
                return StatusCode(StatusCodes.Status204NoContent,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "Enrollee Record Not Found"
                   });

            var providerold = await _service.Toshfa.FetchProviderByProviderCode(enrollee.providerId ?? 0);

            var providerNew = await _service.Toshfa.FetchProviderByProviderCode(model.newProviderCode);

            if (providerNew == null)
                return StatusCode(StatusCodes.Status204NoContent,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "Can not find Detail of the new Primary Provider"
                   });


            var data = new ChangeProviderRequestViewModel()
            {
                MemberNo = enrollee.memberNumber ?? 0,
                MemberEmail = enrollee.email,
                CurrentProviderCode = enrollee.providerId ?? 0,
                CurrentProviderName = providerold == null ? "." : providerold.Name,
                NewProviderCode = model.newProviderCode,
                NewProviderName = providerNew.Name,
                EnrolleeId = enrollee.enrolleeId
            };

            var res = await _service.Avon.ChangePrimaryProvider(data);

            if (res)
            {

                var notificationTitle = "Provider Change Request";
                var notificationText = "You requested to change your primary provider on the Avon HMO app. A member of our team will validate the changes with the next 24 hours";
                try
                {

                    await _service.Avon.LogNotification(new NotificationLogVM
                    {
                        body = notificationText,
                        subject = notificationTitle,
                        SentDate = DateTime.Now,
                        ownerId = enrollee.enrolleeAccountId.ToString(),

                    });

                    var templateName = "change_provider_request";

                    var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                    var templateResult = templateBuilder.BuildTemplate(new ChangeProviderEmailTemplatePlaceHolder()
                    {
                        avonIdNo = "100010",
                        enrolleeName = $"{enrollee.firstName} {enrollee.middleName}",
                        healthPlan = "basic Plan",
                        primaryProvider = providerNew.Name
                    });

                    var sendersEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);

                    var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                    var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);

                    //var emailSender = new SendGridNotification(sendersEmail, sendersName, apiKey);
                    _emailService.Send("Provider Change Request", enrollee.email, templateResult);

                    //var emailResponse = await emailSender.SendEmailMailAsync("Provider Change Request", enrollee.email, templateResult);

                }
                catch
                {


                }

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = false,
                    Message = "Enrollee Primary Provider Request Submitted SuccessFully",
                    Data = null,
                });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }

        /// <summary>
        /// The EndPoint to call to get change primary provider request  by member number
        /// </summary>
        [HttpGet(ApiRoutes.Actions.ChangePrimaryProviderRequestBymemberno)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<ChangeProviderRequestViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangePrimaryProviderRequestsByMember([FromRoute] int memberno)
        {
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = await _service.Avon.GetChangePrimaryProviderRequestByMemberNo(memberno),
                      Message = "",
                      StatusCode = 200
                  });
        }

        /// <summary>
        /// The EndPoint to call to get change primary provider request  by enrolleeId
        /// </summary>
        [HttpGet(ApiRoutes.Actions.ChangePrimaryProviderRequestByEnrolleeId)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<ChangeProviderRequestViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangePrimaryProviderRequestsByMember([FromRoute] Guid enrolleeid)
        {
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = await _service.Avon.GetChangePrimaryProviderRequestByEnrolleeId(enrolleeid),
                      Message = "",
                      StatusCode = 200
                  });
        }
        /// <summary>
        /// The EndPoint to call to get change primary provider request  by requestId
        /// </summary>
        [HttpGet(ApiRoutes.Actions.ChangePrimaryProviderRequestByRequestId)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<ChangeProviderRequestViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangePrimaryProviderRequestsByRequestId([FromRoute] Guid requestid)
        {
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = await _service.Avon.GetChangePrimaryProviderRequestByRequestId(requestid),
                      Message = "",
                      StatusCode = 200
                  });
        }



        /// <summary>
        /// This endpoint Create Customer's Compliant
        /// </summary>
        /// <param name="complaintModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Actions.PostCompliant)]

        public async Task<IActionResult> PostCompliant([FromBody] CompliantRequestModel complaintModel)
        {

            if (complaintModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<CompliantRequestModel>(complaintModel);


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
            var createResult = await _service.Avon.CreateCompliant(complaintModel, enrolleeID);


            if (createResult)
            {

                var templateName = "feedback";
                var emailSubject = "User's Complaint";

                var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                var templateResult = templateBuilder.BuildTemplate(new FeedbackEmailToken()
                {
                    senderName = complaintModel.Name,
                    email = complaintModel.Email,
                    message = complaintModel.Message,
                    subject = complaintModel.Subject
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
                    { Data = null, hasError = false, Message = "Your complaint is well appreciated" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error saving your complaint"
                    });
            }

        }



        /// <summary>
        /// This enpoint returns all Complaint 
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.Actions.GetCompliant)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<CompliantViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FetchCompliant([FromQuery] PagingParam pagination)
        {

            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<CompliantViewModel>
                {
                    Data = _service.Avon.FetchComplaint(pagination).ToList(),
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize
                });

        }



        /// <summary>
        /// This enpoint returns Complaint For a Loggedon User with Status
        /// </summary>
        /// <param></param>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchCompliantForLoggedOnUserWithStatus)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<CompliantViewModel>), StatusCodes.Status200OK)]
        public IActionResult FetchCompliantForLoggedOnUserWithStatus([FromQuery] PagingParam pagination, [FromRoute] string status)
        {
            var userId = loggedInUserId;
            var enrolleeID = Guid.Parse(userId);

            var complaint = _service.Avon.FetchUserComplaintByStatus(pagination, enrolleeID, status).ToList();


            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<CompliantViewModel>
                {
                    Data = complaint,
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize
                });

        }
        
        /// <summary>
        /// This enpoint returns Complaint For a Loggedon User 
        /// </summary>
        /// <param></param>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchCompliantForLoggedOnUser)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<CompliantViewModel>), StatusCodes.Status200OK)]
        public IActionResult FetchCompliantForLoggedOnUser([FromQuery] PagingParam pagination)
        {
            var userId = loggedInUserId;
            var enrolleeID = Guid.Parse(userId);

            var complaint = _service.Avon.FetchComplaintByUser(pagination, enrolleeID).ToList();


            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<CompliantViewModel>
                {
                    Data = complaint,
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                });

        }
        
        /// <summary>
        /// This enpoint returns Complaint By Status 
        /// </summary>
        /// <param></param>
        [HttpGet]
        [Route(ApiRoutes.Actions.FetchCompliantWithStatus)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<CompliantViewModel>), StatusCodes.Status200OK)]
        public IActionResult FetchCompliantForLoggedOnUser([FromQuery] PagingParam pagination, [FromRoute] string status)
        {
            var complaint = _service.Avon.FetchComplaintByStatus(pagination, status).ToList();


            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<CompliantViewModel>
                {
                    Data = complaint,
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                });

        }


        /// <summary>
        /// This enpoint returns  complaint detail by complaint Id
        /// </summary>
        /// <returns> Complaint detail</returns>
        /// 

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<CompliantViewModel>), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Actions.GetCompliantDetailById)]
        public async Task<IActionResult> GetComplaintDetailById([FromRoute] Guid complaintID)
        {

            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object>
                {
                    Data = await _service.Avon.GetComplaintInfo(complaintID),
                    Message = "",
                    StatusCode = 200

                });
        }



        /// <summary>
        /// This endpoint Create Admin's response to Customer's Compliant
        /// </summary>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Actions.PostAdminResponseForCompliant)]

        public async Task<IActionResult> PostAdminCompliantResponse([FromBody] CompliantAdminRequestModel responseModel)
        {

            if (responseModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<CompliantAdminRequestModel>(responseModel);


            if (errorMessage.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessage)
                    });

            var complaintExist = await _service.Avon.IsComplaintIDExist(responseModel.enrolleeComplaintId);

            if (!complaintExist)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = true,
                    Message = "This Complaint does not exist",
                    Data = null
                });
            }
            var createResult = await _service.Avon.CreateCompliantAdminResponse(responseModel);
            var getComplaint = await _service.Avon.GetComplaintInfo(responseModel.enrolleeComplaintId);

            if (createResult)
            {

                var templateName = "admin_response";
                var emailSubject = "Response to Complaint";

                var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                var templateResult = templateBuilder.BuildTemplate(new AdminResponseToComplaintEmailToken()
                {
                    firstName = getComplaint.Name,
                    message = responseModel.adminResponse,
                });

                _emailService.Send(emailSubject, getComplaint.Email, templateResult);


                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = "Your response is saved successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error saving your response"
                    });
            }

        }
        /// <summary>
        /// This enpoint returns all Admin response to Complaint 
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.Actions.GetAdminCompliantResponse)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<CompliantAdminViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FetchAdminCompliantResponse([FromQuery] PagingParam pagination)
        {

            return StatusCode(StatusCodes.Status200OK,
                new PagedResponse<CompliantAdminViewModel>
                {
                    Data = _service.Avon.FetchAdminComplaintResponse(pagination).ToList(),
                    hasError = false,
                    StatusCode = StatusCodes.Status200OK,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize
                });

        }


        /// <summary>
        /// This enpoint returns  Admin complaint detail by complaint Id
        /// </summary>
        /// <returns> Complaint detail</returns>
        /// 

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<CompliantAdminViewModel>), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Actions.GetCompliantAdminResponseDetailById)]
        public IActionResult GetAdminComplaintDetailById([FromRoute] Guid complaintID)
        {

            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object>
                {
                    Data = _service.Avon.FetchAdminComplaintResponseByComplaintID(complaintID).ToList(),
                    Message = "",
                    StatusCode = 200

                });
        }


        /// <summary>
        /// This endpoint update complaint status
        /// </summary>
        /// <param name="complaintModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Actions.UpdateCompliantStatus)]
        public async Task<IActionResult> UpdateComplaintStatus([FromBody] CompliantUpdateViewModel complaintModel)
        {

            if (complaintModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<CompliantUpdateViewModel>(complaintModel);


            if (errorMessage.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessage)
                    });

            var claimExist = await _service.Avon.IsComplaintIDExist(complaintModel.EnrolleeComplaintId);

            if (!claimExist)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = true,
                    Message = "This Complaint does not exist",
                    Data = null
                });
            }

            var createResult = await _service.Avon.UpdateComplaintStatus(complaintModel);

            if (createResult)
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = "Complaint status updated successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error updating Complaint status"
                    });
            }

        }



    }
}