using AvonHMO.API.Contracts;
using AvonHMO.API.Controllers;
using AvonHMO.API.Extensions;
using AvonHMO.API.Models;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Enrollee;
using AvonHMO.Application.ViewModels.Avon.Plan;
using AvonHMO.Application.ViewModels.Toshfa;
using AvonHMO.Domain.Interfaces;
using BrightStar.Util.Storage;
using BrightStar.Util.Storage.RepoManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AvonHMO.API.Areas.Enrollee.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    public class MembersController : BaseController
    {
        private readonly IRepositoryManager _service;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IStorageRepoManager _storageService;
        private readonly IConfiguration _config;
        public MembersController(IRepositoryManager service, IHttpClientFactory httpClientFactory)
        {
            _service = service;
            _httpClientFactory = httpClientFactory;
        }



        /// <summary>
        /// This enpoint returns Enrollee Current plan information
        /// </summary>
        /// <returns>Enrollee Current plan information</returns>
        [HttpGet(ApiRoutes.Enrolle.EnrolleecurrentPlan)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(CurrentPlanDetail), StatusCodes.Status200OK)]
        public async Task<IActionResult> EnrolleePlans()
        {

            var currPlanDetail = await _service.Toshfa.GetCurrendEnrollePlan(HttpContext.MemberNumber());

            return StatusCode(StatusCodes.Status200OK, currPlanDetail);
        }


        /// <summary>
        /// This enpoint returns Enrollee plan information
        /// </summary>
        /// <param name="enrolleeNo">member No</param>
        /// <returns>Enrollee plan information</returns>
        [HttpGet(ApiRoutes.Enrolle.EnrolleeePlan)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(HmoMemberMasterViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> EnrolleePlans([FromRoute] int enrolleeNo)
        {

            if (enrolleeNo == 0) return StatusCode(StatusCodes.Status400BadRequest,
                     new ApiResponse<object> { Data = null, Message = "Bad Request", hasError = true, });

            var memberInformation = await _service.Toshfa.GetEnrollePlan(enrolleeNo);
            return StatusCode(StatusCodes.Status200OK, memberInformation);

        }



        /// <summary>
        /// This enpoint returns a list of all enrollee dependants
        /// </summary>
        /// <returns>List of  all enrollee dependants</returns>
        [ProducesResponseType(200)]
        [HttpGet(ApiRoutes.Enrolle.EnrolleeeDependants)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberMasterViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberMaster([FromQuery] PagingParam objModel, [FromRoute] int enrolleeNo)
        {
            if (enrolleeNo == 0) return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object> { Data = null, Message = "Bad Request", hasError = true });

            if (objModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                     new ApiResponse<object> { Data = null, Message = "Bad Request", hasError = true });

            if (objModel.PageSize == 0 || objModel.PageNumber == 0) return StatusCode(StatusCodes.Status400BadRequest,
                     new ApiResponse<object> { Data = null, Message = "Bad Request", hasError = true });


            var memberMaster = await _service.Toshfa.FetchAllEnrolleeDependants(objModel, enrolleeNo);
            return StatusCode(StatusCodes.Status200OK, memberMaster);

        }



        /// <summary>
        /// This enpoint returns  enrollee infomation 
        /// </summary>
        /// <param name="email"></param>
        /// <returns> enrollee info</returns>
        [HttpGet]
        [Route(ApiRoutes.Enrolle.EnrolleeeByEmail)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<HmoMemberMasterViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> EnrolleeByEmail([FromQuery] string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object> { Data = null, Message = "Bad Request", hasError = true });

            

            var memberNo = int.Parse(this.memberNumber);

            var searchParam = string.Empty;

            if (email == "N/A")
            {
                searchParam = memberNo.ToString();
            }
            else
            {
                searchParam = email;
            }

            //var currUser = await _service.AvonAuth.FindUserByName(searchParam);

            var newEnrollee = await _service.Enrollee.FetchLocalEnrollee(email);

            if(newEnrollee==null){
                newEnrollee = await _service.Enrollee.FetchLocalEnrolleeWithmemberNumber(memberNo);
            }

            if (newEnrollee != null)
            {

                return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object> { Data = newEnrollee, hasError = false, StatusCode = 200 });

            }
            else
            {
                

               

                var enrollee = await _service.Enrollee.FetchMemberInformationByNumber(memberNo);

                HmoMemberMasterViewModel result = null;

                if (enrollee.Any())
                {

                    var localEnrollee = await _service.Enrollee.
                        FetchLocalEnrollee(Guid.Parse(this.loggedInUserId));

                    result = enrollee.First();

                    var gender = result.Gender.ToLower() == "female" ? "f" : "m";

                    if (localEnrollee != null)
                    {
                        result.weight = localEnrollee.weight;
                        result.height = localEnrollee.height;
                        result.bloodType = localEnrollee.bloodType;
                        result.Gender = gender;
                        result.imageUrl = localEnrollee.imageUrl;

                    }

                }


                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object> { Data = result, hasError = false, StatusCode = 200 });
            }

            //return StatusCode(StatusCodes.Status404NotFound);


        }

        /// <summary>
        /// This enpoint returns  enrollee dependants 
        /// </summary>
        /// <param name="enrolleeId"></param>
        /// <returns> enrollee dependant info</returns>
        [HttpGet]
        [Route(ApiRoutes.Enrolle.EnrolleeeDepenById)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<TempEnrolleeDependantViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> EnrolleeDependantByenrolleeId([FromRoute] Guid enrolleeId)
        {
            var user = await _service.AvonAuth.FindUserById(Guid.Parse(loggedInUserId));

            var localDependants = await _service.Enrollee.FetchuserLocalEnrolleeDependants(enrolleeId, loggedInUserId);

            if (localDependants != null)
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object> { Data = localDependants, hasError = false, StatusCode = 200 });

            IEnumerable<TempEnrolleeDependantViewModel> dependants = Enumerable.Empty<TempEnrolleeDependantViewModel>();

            if (!string.IsNullOrWhiteSpace(user.memberNo))
            {
                var enrollee = await _service.Enrollee.FetchEnrolleeDependatntsByMemberNumber(int.Parse(user.memberNo));


                var edependant = enrollee.FirstOrDefault();

                if (edependant != null)
                {

                    var gender = edependant.Gender.ToLower() == "male" ? "m" : "f";

                    dependants = enrollee.Select(x => new TempEnrolleeDependantViewModel
                    {
                        enrolleeId = enrolleeId,
                        email = x.EMAIL,
                        FirstName = x.FirstName,
                        Gender = gender,
                        imageUrl = x.imageUrl,
                        MaritalStatus = x.MaritalStatus,
                        MemberNo = x.MemberNo,
                        MiddleName = x.MiddleName,
                        PlanName = x.PlanType,
                        PlanType = x.PlanType,
                        PrimaryProviderNo = x.PrimaryProviderNo,
                        SurName = x.SurName,
                        Relation = x.Relation,
                        DOB = x.DOB,
                        MemberExpirydate = x.PolicyExpiry,
                        policyExpiry = x.PolicyExpiry,
                        PlanCode = x.planCode

                    });

                }



            }


            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object> { Data = dependants, hasError = false, StatusCode = 200 });
        }



        [HttpGet("dependant/details")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(EnrolleeViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> EnrolleeDependantDetails([FromQuery] Guid dependantId = new Guid(), [FromQuery] string memberNo = "")
        {

            EnrolleeViewModel data = null;

            if (Guid.Empty == dependantId && string.IsNullOrWhiteSpace(memberNo))
            {
                return BadRequest();
            }

            if (Guid.Empty != dependantId)
            {
                var enrollee = _service.Enrollee.FetchLocalAllEnrollee().Where(x => x.dependantId == dependantId).FirstOrDefault();

                var principalData = await _service.Avon.GetEnrolleeInfoByEnrolleeId(enrollee.enrolleeId);

                if (enrollee == null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new ApiResponse<object>
                        {
                            Data = data,
                            Message = "",
                            StatusCode = 200
                        });
                }

                var rawGender = enrollee.Gender;
                var gender = string.Empty;
                switch (rawGender.ToLower())
                {
                    case "female":
                        gender = "f";
                        break;
                    case "male":
                        gender = "m";
                        break;
                    default:
                        gender = rawGender.ToLower();
                        break;
                }

                data = new EnrolleeViewModel
                {
                    enrolleeId = enrollee.dependantId,
                    memberNumber = enrollee.MemberNo,
                    isActive = true,

                    //clientName = record.ClientName,
                    personalDetail = new PersonalDetailViewModel
                    {
                        surname = enrollee.SurName,
                        firstName = enrollee.FirstName,
                        dateOfBirth = enrollee.DOB,
                        maritalStatus = enrollee.MaritalStatus,
                        gender = gender,
                        title = "",
                        imageUrl = enrollee.imageUrl,
                        relation = enrollee.Relation

                    },
                    contactDetail = new ContactDetailView
                    {
                        address = principalData.contactDetail.address,
                        country = principalData.contactDetail.country,
                        email = enrollee.email,
                        lga = "",
                        mailingAddress = "",
                        //phoneNumber = record.MobileNo
                    },
                    providerInfo = new ProviderInfo
                    {
                        providerAddress = "",
                        providerName = principalData.providerInfo.providerName,
                        providerCountry = "Nigeria",
                        providerId = principalData.providerInfo.providerId,

                    },
                    planDetail = new PlanDetail
                    {
                        PlanName = enrollee.PlanType,
                        PlanCode = principalData.planDetail.PlanCode,

                    }
                };

            }
            else if (!string.IsNullOrWhiteSpace(memberNo))
            {

                int memberNumber = int.Parse(memberNo);

                if (memberNumber <= 0) return StatusCode(StatusCodes.Status400BadRequest);

                var enrolleeDependants = await _service.Enrollee.FetchMemberInformationByNumber(int.Parse(memberNo));


                if (enrolleeDependants.Any())
                {
                    var record = enrolleeDependants.FirstOrDefault();

                    var rawGender = record.Gender;
                    var gender = string.Empty;
                    switch (rawGender.ToLower())
                    {
                        case "female":
                            gender = "f";
                            break;
                        case "male":
                            gender = "m";
                            break;
                        default:
                            gender = rawGender.ToLower();
                            break;
                    }


                    data = new EnrolleeViewModel
                    {

                        memberNumber = record.MemberNo,
                        isActive = true,
                        clientName = record.ClientName,
                        personalDetail = new PersonalDetailViewModel
                        {
                            surname = record.SurName,
                            firstName = record.FirstName,
                            dateOfBirth = record.DOB,
                            maritalStatus = record.MaritalStatus,
                            gender = gender,
                            title = "",
                            imageUrl = record.imageUrl
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
        /// This enpoint returns  enrollee sponsors 
        /// </summary>
        /// <param name="enrolleeId"></param>
        /// <returns> enrollee sponsors info</returns>
        [HttpGet]
        [Route(ApiRoutes.Enrolle.EnrolleeSponsor)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<TempEnrolleeViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> EnrolleeSponsorByenrolleeId([FromRoute] Guid enrolleeId)
        {
            var enrollee = await _service.Enrollee.FetchLocalEnrolleeSponsor(enrolleeId);

            //if(enrollee.Count() == 0)
            //{

            //}

            //var enrollee = new List<TempEnrolleeViewModel>();

            //var enrollee = await _service.Enrollee.FetchMemberInformationByNumber(int.Parse(this.memberNumber));

            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object> { Data = enrollee, hasError = false, StatusCode = 200 });
        }



        [HttpGet]
        [Route(ApiRoutes.Enrolle.EnrolleeeById)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(TempEnrolleeViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> EnrolleeById([FromRoute] Guid id)
        {

            if (Guid.Empty == id)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object> { Data = null, Message = "Bad Request", hasError = true });

            var enrollee = await _service.Enrollee.FetchLocalEnrollee(id);

            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object> { Data = enrollee, hasError = false, StatusCode = 200 });
        }


        [HttpGet]
        [Route(ApiRoutes.Enrolle.EnrolleeeDependantList)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<TempEnrolleeViewModel>>), StatusCodes.Status200OK)]
        public IActionResult EnrolleeDependant([FromQuery] string email)
        {
            var enrollee = _service.Enrollee.FetchLocalEnrolleeDependents(email);

            return StatusCode(StatusCodes.Status200OK,
            new ApiResponse<List<TempEnrolleeViewModel>>
            {
                Data = enrollee,
                hasError = false,
                StatusCode = 200,

            });

        }


        /// <summary>
        /// This endpoint allows you to upload enrollee photo
        /// </summary>
        /// <remarks>
        /// Request body:  FormData => var formData =new FormData(); formData.Append("title","somevalue"); etc
        ///     
        ///     {
        ///         memberNumber:string,
        ///         file:file,
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns response object</response>

        [HttpPost(ApiRoutes.Enrolle.UploadEnrolleeePhoto)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<DefaultResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UploadEnrolleePhoto()
        {

            var request = await HttpContext.Request.ReadFormAsync();

            if (!request.Files.Any()) return BadRequest("Please upload a file");

            var memberNumber = request["memberNumber"].FirstOrDefault();

            if (memberNumber == null) return BadRequest("Member number is required");

            if (int.TryParse(memberNumber.Trim(), out int memberNo))
            {
                if (memberNo <= 0) return BadRequest("Member number is invalid");
            }
            else
            {
                return BadRequest("Member number is invalid");
            }

            var file = request.Files[0];

            if (file == null) return BadRequest("Please upload a file");

            var isValidImageFile = file.FileName.IsImage();

            if (!isValidImageFile)
            {
                return StatusCode(StatusCodes.Status200OK,
                        new ApiResponse<DefaultResponse>
                        {
                            Data = null,
                            hasError = true,
                            StatusCode = 200,
                            Message = "Invalid image file selected"
                        });
            }


            var storageContainer = _config.GetSection("Azure:AzureStorageContainer").Value;


            var uploadResponse = await _storageService.AzureStorage.UploadAsync(file, storageContainer);

            await _service.Enrollee.UpdateEnrolleePhoto(memberNo, uploadResponse.fileUri);


            var _client = _httpClientFactory.CreateClient("toshfaClient");


            var formData = new MultipartFormDataContent();


            await using var stream = file.OpenReadStream();

            var streamContent = new StreamContent(stream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            formData.Add(streamContent, name: "file", fileName: file.FileName);

            using var response = await _client.PostAsync($"EnrolleePhotoUpload?memberno={memberNumber}", formData);


            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<EnrolleePhotoUploadResponseModel>();

                if (result.lstEnroleePhotoUploadStatusModel.Success.ToLower().Equals("true"))
                {
                    return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<DefaultResponse>
                       {
                           Data = null,
                           hasError = false,
                           StatusCode = 200,
                           Message = result.lstEnroleePhotoUploadStatusModel.Message
                       });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK,
                      new ApiResponse<DefaultResponse>
                      {
                          Data = null,
                          hasError = true,
                          StatusCode = 200,
                          Message = result.lstEnroleePhotoUploadStatusModel.Message
                      });
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError,
            new ApiResponse<DefaultResponse>
            {
                Data = null,
                hasError = false,
                StatusCode = 200,

            });

        }


        #region Record from Toshfa


        [HttpGet]
        [Route(ApiRoutes.Enrolle.EnrolleeeByMemberNo)]
        public async Task<IActionResult> EnrolleeByMemberNo([FromRoute] int memberNo)
        {

            if (memberNo == 0)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object> { Data = null, Message = "Bad Request", hasError = true });

            var enrollee = await _service.Enrollee.FetchMemberInformationByNumber(memberNo);

            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object> { Data = enrollee.FirstOrDefault(), hasError = false, StatusCode = 200 });
        }


        [HttpGet]
        [Route(ApiRoutes.Enrolle.EnrolleeeDependantListByNumber)]
        public async Task<IActionResult> EnrolleeDependantByMemberNumber([FromRoute] int memberNo)
        {
            var enrollee = await _service.Enrollee.FetchEnrolleeDependatntsByMemberNumber(memberNo);

            return StatusCode(StatusCodes.Status200OK,
            new ApiResponse<List<HmoMemberMasterViewModel>>
            {
                Data = enrollee,
                hasError = false,
                StatusCode = 200,

            });

        }


        /// <summary>
        /// This enpoint returns all enrollee infomation search date format::dd/MM/yyyy
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.Enrolle.AllEnrollee)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberMasterViewModel>), StatusCodes.Status200OK)]

        public async Task<IActionResult> AllEnrollees([FromQuery] EnrolleeSearchParam model)
        {
            if (model.PageSize <= 0) model.PageSize = 10;

            if (model.PageNumber <= 0) model.PageNumber = 1;

            if (!string.IsNullOrWhiteSpace(model.startDate) && !string.IsNullOrWhiteSpace(model.endDate))
            {
                var startDate = parseLocalDate(model.startDate);
                var endDate = parseLocalDate(model.endDate);

                if (startDate > endDate)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object> { Data = null, Message = "Start date cannot be greater than end date", hasError = true });
                }

                model.startDate = startDate.ToString("yyyy-MM-dd");
                model.endDate = endDate.ToString("yyyy-MM-dd");
            }

            

            var allEnrollees = await _service.Enrollee.FetchAllMemberMaster(model);


            return StatusCode(StatusCodes.Status200OK, allEnrollees);
        }

       

        [HttpGet]
        [Route(ApiRoutes.Enrolle.EnrolleeeInfoByMemberNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberMasterViewModel>), StatusCodes.Status200OK)]

        public async Task<IActionResult> EnrolleeByMemberNumber([FromQuery] int memberNo)
        {
            
            var enrollee = await _service.Enrollee.FetchMemberInformationByNumber(memberNo);

            HmoMemberMasterViewModel result = null;

            if (enrollee.Any())
            {
                result = enrollee.First();

                var localEnrollee = await _service.Enrollee.
                    FetchLocalEnrolleeByMemberNo(result.MemberNo);

                

                var gender = result.Gender.ToLower() == "female" ? "f" : "m";

                if (localEnrollee != null)
                {
                    result.weight = localEnrollee.weight;
                    result.height = localEnrollee.height;
                    result.bloodType = localEnrollee.bloodType;
                    result.Gender = gender;
                    result.imageUrl = localEnrollee.imageUrl;

                }

            }


            return StatusCode(StatusCodes.Status200OK, result);
        }

        #endregion


        private DateTime parseLocalDate(string date)
        {
            var dateParts = date.Split('/');

            var year = int.Parse(dateParts[2]);
            var month = int.Parse(dateParts[1]);
            var day = int.Parse(dateParts[0]);

            return new DateTime(year, month, day);
        }


    }
}
