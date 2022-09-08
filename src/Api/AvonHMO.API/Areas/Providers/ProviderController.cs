using AvonHMO.API.Areas.Setup.Controllers;
using AvonHMO.API.Contracts;
using AvonHMO.API.Controllers;
using AvonHMO.API.Extensions;
using AvonHMO.API.Filters;
using AvonHMO.API.Helpers;
using AvonHMO.API.Models;
using AvonHMO.API.Models.Providers;
using AvonHMO.API.Models.SeerBitPay;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.Application.ViewModels.Avon.Communication;
using AvonHMO.Application.ViewModels.Avon.Enrollee;
using AvonHMO.Application.ViewModels.Avon.EnrolleFlow;
using AvonHMO.Application.ViewModels.Avon.Plan;
using AvonHMO.Application.ViewModels.Avon.Provider;
using AvonHMO.Application.ViewModels.Avon.SelfService;
//using AvonHMO.Application.ViewModels.Avon.Provider;
using AvonHMO.Application.ViewModels.Toshfa;
using AvonHMO.Common;
using AvonHMO.Communications.Sendgrid;
using AvonHMO.Domain.Interfaces;
using Azure.Core;
using BrightStar.Util.Storage.RepoManager;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AvonHMO.API.Areas.Providers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    //[APIKeyAuth]
    public class ProviderController : ControllerBase
    {
        private readonly IRepositoryManager _service;
        private readonly IStorageRepoManager _storageService;
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IEmailService _emailService;
        IWebHostEnvironment _env;
        public ProviderController(IRepositoryManager service, IStorageRepoManager storageService, IConfiguration config, IHttpClientFactory httpClientFactory, IWebHostEnvironment env, IEmailService emailService)
        {
            _service = service;
            _storageService = storageService;
            _config = config;
            _httpClientFactory = httpClientFactory;
            _env = env;
            _emailService = emailService;
        }


        /// <summary>
        /// This enpoint returns list of providers filter by category or/and search key. Search key: can be Name, address, service type or City
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of filtered HMO providers</returns>

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoProvidersViewModel>), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Providers.AllSearchProviders)]
        public async Task<IActionResult> SearchHmoProviders([FromQuery] ProviderSearchFilterParam model)
        {
            var providers = await _service.Toshfa.FetchProviderFilterByCategoryAndSearchKey(model);
            return StatusCode(StatusCodes.Status200OK, providers);
        }

        /// <summary>
        /// This enpoint returns list of providers
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of HMO providers</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoProvidersViewModel>), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Providers.AllProviders)]

        public async Task<IActionResult> HmoProviders([FromQuery] PagingParam model)
        {

            var providers = await _service.Toshfa.FetchAllProviders(model);
            return StatusCode(StatusCodes.Status200OK, providers);
        }


        /// <summary>
        ///  This enpoint returns list of providers categories
        /// </summary>
        /// <returns> provider categories</returns>
        [HttpGet(ApiRoutes.Providers.ProviderCategory)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ProviderCategories([FromQuery] PagingParam model)
        {

            var providers = await _service.Toshfa.FetchProviderCategory(model);
            return StatusCode(StatusCodes.Status200OK, providers);
        }



        /// <summary>
        /// This enpoint returns  provider by provider code
        /// </summary>
        /// <param name="code">Provider Code</param>
        /// <param name="model">Paging Model Prameter</param>
        /// <returns>List of HMO providers</returns>
        [HttpGet(ApiRoutes.Providers.ProviderByCode)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoProvidersViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> HmoProvidersByCity([FromQuery] PagingParam model, [FromRoute] string code)
        {
            var providers = await _service.Toshfa.FetchProviderByProviderCode(model, code);
            return StatusCode(StatusCodes.Status200OK, providers);
        }

        /// <summary>
        /// This enpoint returns  providers by filtering parameters code
        /// </summary>
        /// <param name="model">Paging and filter Model Prameter</param>
        /// <returns>List of HMO providers</returns>
        [HttpGet(ApiRoutes.Providers.ProviderByfilter)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoProvidersViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> HmoProviders([FromQuery] ProviderFilterParam model)
        {

            if (model.PageNumber <= 0) model.PageNumber = 1;

            if (model.PageSize <= 0) model.PageSize = 10;

            var providers = await _service.Toshfa.FetchProviderByFilter(model);
            return StatusCode(StatusCodes.Status200OK,
                providers

                );
        }

        #region HCP

        /// <summary>
        /// Add New Provider 
        /// </summary>
        /// <response code="200">Returns response object</response>
        [HttpPost]
        [Route(ApiRoutes.Providers.AddNewProvider)]
        // [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<DefaultResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddNewProvider([FromBody] ProviderViewModels model) //

        {
            if (model == null) return BadRequest("No data found");

            //

            //var model = new ProviderViewModel();
            //var request = await Request.ReadFormAsync();

            //if (request == null) return BadRequest("No data found");

            //var otherContacts = request["otherContacts"];

            //List<ProviderOtherContactsVM> deserializedContacts = null;

            //if (otherContacts.Count > 0)
            //{
            //    deserializedContacts = JsonConvert.DeserializeObject<List<ProviderOtherContactsVM>>(otherContacts);
            //}


            //var model = new ProviderViewModels()
            //{

            //    providerName = request.TryGetValue("providerName", out var providerName) ? providerName.ToString() : null,
            //    providerAddress = request.TryGetValue("providerAddress", out var providerAddress) ? providerAddress.ToString() : null,
            //    mdName = request.TryGetValue("mdName", out var mdName) ? mdName.ToString() : null,
            //    mdPhoneNo = request.TryGetValue("mdPhoneNo", out var mdPhoneNo) ? mdPhoneNo.ToString() : null,
            //    mdEmail = request.TryGetValue("mdEmail", out var mdEmail) ? mdEmail.ToString() : null,
            //    mdDirectLine = request.TryGetValue("mdDirectLine", out var mdDirectLine) ? mdDirectLine.ToString() : null,

            //    hmoContactDetailsEmail = request.TryGetValue("hmoContactDetailsEmail", out var hmoContactDetailsEmail) ? hmoContactDetailsEmail.ToString() : null,
            //    hmoDeskPhoneNo = request.TryGetValue("hmoDeskPhoneNo", out var hmoDeskPhoneNo) ? hmoDeskPhoneNo.ToString() : null,
            //    hmoOfficerName = request.TryGetValue("hmoOfficerName", out var hmoOfficerName) ? hmoOfficerName.ToString() : null,
            //    hmoOfficerGSM = request.TryGetValue("hmoOfficerGSM", out var hmoOfficerGSM) ? hmoOfficerGSM.ToString() : null,
            //    providerServiceType = request.TryGetValue("providerServiceType", out var providerServiceType) ? providerServiceType.ToString() : null,
            //    providerOperationHour = request.TryGetValue("providerOperationHour", out var providerOperationHour) ? providerOperationHour.ToString() : null,
            //    providerOperationDay = request.TryGetValue("providerOperationDay", out var providerOperationDay) ? providerOperationDay.ToString() : null,
            //    doctorCoverageHour = request.TryGetValue("doctorCoverageHour", out var doctorCoverageHour) ? doctorCoverageHour.ToString() : null,

            //    lga = request.TryGetValue("lga", out var lga) ? lga.ToString() : null,
            //    state = request.TryGetValue("state", out var state) ? state.ToString() : null,
            //    city = request.TryGetValue("city", out var city) ? city.ToString() : null,
            //    bankname = request.TryGetValue("bankname", out var bankname) ? bankname.ToString() : null,
            //    accountNo = request.TryGetValue("accountNo", out var accountNo) ? accountNo.ToString() : null,
            //    accountName = request.TryGetValue("accountName", out var accountName) ? accountName.ToString() : null,
            //    sortCode = request.TryGetValue("sortCode", out var sortCode) ? sortCode.ToString() : null,
            //    otherContacts = deserializedContacts

            //};

            var providerId = await _service.Avon.AddNewProvider(model);


            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = false,
                Message = "Provider Added Successfully",
                Data = new
                {
                    providerId = providerId
                },
                StatusCode = 200
            });

        }





        /// <summary>
        /// Upload provider documents - types are facility-img and contractual-docs
        /// </summary>
        /// <remarks>
        /// Request body:  FormData => var formData =new FormData(); formData.Append("contractual-docs",file) or formData.Append("facility-img",file) ; etc
        /// </remarks>
        /// <response code="200">Returns response object</response>
        [HttpPost, DisableRequestSizeLimit]
        [Route(ApiRoutes.Providers.UploadProviderDocs)]
        // [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<DefaultResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadProviderDocuments([FromRoute] string providerId)
        {
            //if (Guid.Empty == providerId) return BadRequest();

          

            var request = await Request.ReadFormAsync();

            if (request == null) return BadRequest("No data found");


            if (request.Files.Count == 0) return BadRequest("No files found");

            var hospitalImgFiles = request.Files.GetFiles("facility-img");
            var contractualFiles = request.Files.GetFiles("contractual-docs");

            if (hospitalImgFiles.Count == 0 && contractualFiles.Count == 0) return BadRequest("No files found");

            var storageContainer = _config.GetSection("Azure:AzureStorageContainer").Value;


            if(hospitalImgFiles.Count > 0)
            {
                var facilityImages = hospitalImgFiles.ToList();

                var uploadResponse = await _storageService.AzureStorage.UploadAsync(facilityImages, storageContainer);


                List<HospitalImageRequestModel> imgs = new();
                
                if (uploadResponse != null)
                {

                    foreach (var item in uploadResponse)
                    {
                        imgs.Add(new HospitalImageRequestModel
                        {
                            HospitalCode = providerId.ToString(),
                            Image = item.fileUri

                        });
                    }

                    var response = await _service.Avon.UploadHospitalImages(imgs);
                }

            }

            if (contractualFiles.Count > 0)
            {
                var contractualDocs = contractualFiles.ToList();

                var uploadResponse = await _storageService.AzureStorage.UploadAsync(contractualDocs, storageContainer);

                List<HospitalImageRequestModel> docs = new();

                if (uploadResponse != null)
                {

                    foreach (var item in uploadResponse)
                    {
                        docs.Add(new HospitalImageRequestModel
                        {
                            HospitalCode = providerId.ToString(),
                            Image = item.fileUri

                        });
                    }

                    var response = await _service.Avon.UploadContractualDocs(docs);
                }
            }

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = false,
                Message = "Provider Document uploaded Successfully",
                Data = new
                {
                    providerId = providerId
                },
                StatusCode = 200
            });


        }


        #endregion

        /// <summary>
        /// This endpoint returns all provider types
        /// </summary>
        /// <returns></returns>

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<ProviderTypeViewModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(ApiRoutes.Providers.ProviderTypes)]
        public async Task<IActionResult> ProviderTypes()
        {
            var _client = _httpClientFactory.CreateClient("toshfaClient");

            var request = new HttpRequestMessage(HttpMethod.Get, $"providers/GetProviderType");

            var response = await _client.SendAsync(request);

            List<ProviderTypeViewModel> providerCats = null;

            if (response.IsSuccessStatusCode)
            {
                providerCats = await response.Content.ReadFromJsonAsync<List<ProviderTypeViewModel>>();
            }

            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<List<ProviderTypeViewModel>>
                  { Data = providerCats, hasError = false, });
        }


        /// <summary>
        /// this endpoint returns provider managers
        /// </summary>
        /// <returns></returns>

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<LookUpViewModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(ApiRoutes.Providers.ProviderManagers)]
        public async Task<IActionResult> ProviderManagers()
        {
            var _client = _httpClientFactory.CreateClient("toshfaClient");

            var request = new HttpRequestMessage(HttpMethod.Get, $"providers/GetProviderManager");

            var response = await _client.SendAsync(request);

            List<ProviderManagerViewModel> providerMgrs = null;

            if (response.IsSuccessStatusCode)
            {
                providerMgrs = await response.Content.ReadFromJsonAsync<List<ProviderManagerViewModel>>();
            }


            List<LookUpViewModel> lookUp = new();

            if (providerMgrs.Any())
            {

                foreach (var item in providerMgrs)
                {



                    var id = item.ProvidersName.Split('-')[1].Trim();
                    var name = item.ProvidersName.Split('-')[0].Trim();
                    lookUp.Add(new LookUpViewModel
                    {

                        code = id,
                        name = name,

                    });
                }
            }

            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<List<LookUpViewModel>>
                  { Data = lookUp, hasError = false, });
        }


        /// <summary>
        /// This endpoint allows you to change enrolle primary provider - Date Format => yyyy-MM-dd
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<DefaultResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost(ApiRoutes.Providers.ChangeProvider)]
        public async Task<IActionResult> ChangeMemberProvider([FromBody] ProviderChangeRequestModel model)
        {

            if (model == null) return BadRequest();

            if (string.IsNullOrWhiteSpace(model.PProvderno)) return BadRequest();

            if (string.IsNullOrWhiteSpace(model.memberno)) return BadRequest();

            DateTime changeDate = DateTime.Now;

            // if (string.IsNullOrWhiteSpace(model.ChangeDate))
            //{
            model.ChangeDate = changeDate.ToString("yyyy-MM-dd");
            //}

            var lastChange = _service.Enrollee.GetLastProviderChange(model.memberno);

            if (lastChange != null)
            {
                var nextPermittedDate = lastChange.NextChangeDate;

                if (DateTime.Now < nextPermittedDate)
                {
                    return StatusCode(StatusCodes.Status200OK,
                                          new ApiResponse<DefaultResponse>
                                          {
                                              Data = null,
                                              hasError = true,
                                              StatusCode = 200,
                                              Message = "You can only change your primary provider every three months"
                                          });
                }

            }

            if (!int.TryParse(model.memberno, out int id))
            {
                return BadRequest();
            }

            if (!int.TryParse(model.PProvderno, out int provid))
            {
                return BadRequest();
            }

            var memberNumber = int.Parse(model.memberno);
            var providerNumber = int.Parse(model.PProvderno);

            var enrolleeValid = (await _service.Enrollee.FetchMemberInformationByNumber(memberNumber)).FirstOrDefault();

            var enrollee = (await _service.Avon.GetEnrollee()).Where(k => k.memberNumber == memberNumber).FirstOrDefault();

            if (enrollee == null)
                return StatusCode(StatusCodes.Status204NoContent,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "Enrollee Record Not Found"
                   });

            var providerold = await _service.Toshfa.FetchProviderByProviderCode(enrollee.providerId.Value);

            var providerNew = await _service.Toshfa.FetchProviderByProviderCode(providerNumber);



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
                NewProviderCode = providerNumber,
                NewProviderName = providerNew.Name,
                EnrolleeId = enrollee.enrolleeId
            };

            //var providerChangeResponse = await _service.Avon.ChangePrimaryProvider(data);


            var _client = _httpClientFactory.CreateClient("toshfaClient");

            var reqBody = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8,
                System.Net.Mime.MediaTypeNames.Application.Json);

            using var response = await _client.PostAsync("PrimaryProviderChangeRequest", reqBody);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ProviderChangeResponseModel>();

                if (result.lstPrimaryProviderChangeRequestStatusModel.Success.ToLower() == "true")
                {

                    await _service.Enrollee.LogProviderChange(model.memberno);

                    //await _service.Enrollee.LogProviderChange(model.memberno);

                    var notificationTitle = "Provider Change Request";
                    var notificationText = "You requested to change your primary provider on the Avon HMO app. A member of our team will validate the changes with the next 24 hours";

                    await _service.Avon.LogNotification(new NotificationLogVM
                    {
                        body = notificationText,
                        subject = notificationTitle,
                        SentDate = DateTime.Now,
                        ownerId = enrollee.enrolleeAccountId.ToString(),

                    });

                    var templateName = "change_provider_request";
                    var templateNameAvon = "change_provider_request_avon";

                    var templateBuilder = new EmailTemplateBuilder(_env, templateName);
                    var templateBuilderAvon = new EmailTemplateBuilder(_env, templateNameAvon);


                    var templateResult = templateBuilder.BuildTemplate(new ChangeProviderEmailTemplatePlaceHolder()
                    {
                        avonIdNo = enrolleeValid != null ? enrolleeValid.AvonOldEnrolleId : ".",
                        enrolleeName = $"{enrollee.firstName} {enrollee.middleName}",
                        healthPlan = enrolleeValid != null ? enrolleeValid.PlanType : " . ",
                        primaryProvider = providerNew.Name
                    });

                    var templateResultAvon = templateBuilderAvon.BuildTemplate(new ChangeProviderEmailTemplatePlaceHolder()
                    {
                        avonIdNo = enrolleeValid != null ? enrolleeValid.AvonOldEnrolleId : ".",
                        enrolleeName = $"{enrollee.firstName} {enrollee.middleName}",
                        healthPlan = enrolleeValid != null ? enrolleeValid.PlanType : " . ",
                        primaryProvider = providerNew.Name
                    });

                    var sendersEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);

                    var avonReceiptEmail = _service.Settings.GetSetting(AvonConstants.Settings.INFO_EMAIL);

                    var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

                    //var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);

                    //var emailSender = new SendGridNotification(sendersEmail, sendersName, apiKey);


                    _emailService.Send("Provider Change Request", enrollee.email, templateResult, null, null, fromEmail: sendersEmail);
                    _emailService.Send("Provider Change Request", avonReceiptEmail, templateResultAvon, null, null, fromEmail: sendersEmail);



                    //return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                    //{
                    //    hasError = false,
                    //    Message = "Enrollee Primary Provider Request Submitted SuccessFully",
                    //    Data = null,
                    //});

                    return StatusCode(StatusCodes.Status200OK,
                      new ApiResponse<DefaultResponse>
                      {
                          Data = null,
                          hasError = false,
                          StatusCode = 200,
                          Message = result.lstPrimaryProviderChangeRequestStatusModel.Message
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
                                              Message = result.lstPrimaryProviderChangeRequestStatusModel.Message
                                          });
                }
            }


            //if (providerChangeResponse)
            //{
            //    await _service.Enrollee.LogProviderChange(model.memberno);

            //    var notificationTitle = "Provider Change Request";
            //    var notificationText = "You requested to change your primary provider on the Avon HMO app. A member of our team will validate the changes with the next 24 hours";

            //    await _service.Avon.LogNotification(new NotificationLogVM
            //    {
            //        body = notificationText,
            //        subject = notificationTitle,
            //        SentDate = DateTime.Now,
            //        ownerId = enrollee.enrolleeAccountId.ToString(),

            //    });

            //    var templateName = "change_provider_request";
            //    var templateNameAvon = "change_provider_request_avon";

            //    var templateBuilder = new EmailTemplateBuilder(_env, templateName);
            //    var templateBuilderAvon = new EmailTemplateBuilder(_env, templateNameAvon);


            //    var templateResult = templateBuilder.BuildTemplate(new ChangeProviderEmailTemplatePlaceHolder()
            //    {
            //        avonIdNo = enrolleeValid != null ? enrolleeValid.AvonOldEnrolleId : ".",
            //        enrolleeName = $"{enrollee.firstName} {enrollee.middleName}",
            //        healthPlan = enrolleeValid != null ? enrolleeValid.PlanType : " . ",
            //        primaryProvider = providerNew.Name
            //    });

            //    var templateResultAvon = templateBuilderAvon.BuildTemplate(new ChangeProviderEmailTemplatePlaceHolder()
            //    {
            //        avonIdNo = enrolleeValid != null ? enrolleeValid.AvonOldEnrolleId : ".",
            //        enrolleeName = $"{enrollee.firstName} {enrollee.middleName}",
            //        healthPlan = enrolleeValid != null ? enrolleeValid.PlanType : " . ",
            //        primaryProvider = providerNew.Name
            //    });

            //    var sendersEmail = _service.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);

            //    var avonReceiptEmail = _service.Settings.GetSetting(AvonConstants.Settings.INFO_EMAIL);

            //    var sendersName = _service.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

            //    //var apiKey = _service.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);

            //    //var emailSender = new SendGridNotification(sendersEmail, sendersName, apiKey);


            //    _emailService.Send("Provider Change Request", enrollee.email, templateResult, null, null, fromEmail: sendersEmail);
            //    _emailService.Send("Provider Change Request", avonReceiptEmail, templateResultAvon, null, null, fromEmail: sendersEmail);



            //    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            //    {
            //        hasError = false,
            //        Message = "Enrollee Primary Provider Request Submitted SuccessFully",
            //        Data = null,
            //    });

            //}

            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<object>
            {
                hasError = false,
                Message = "Internal server error",
                Data = null,
            });




            //var _client = _httpClientFactory.CreateClient("toshfaClient");

            //var reqBody = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8,
            //    System.Net.Mime.MediaTypeNames.Application.Json);

            //using var response = await _client.PostAsync("PrimaryProviderChangeRequest", reqBody);

            //if (response.IsSuccessStatusCode)
            //{
            //    var result = await response.Content.ReadFromJsonAsync<ProviderChangeResponseModel>();

            //    if (result.lstPrimaryProviderChangeRequestStatusModel.Success.ToLower() == "true")
            //    {

            //        await _service.Enrollee.LogProviderChange(model.memberno);

            //        return StatusCode(StatusCodes.Status200OK,
            //          new ApiResponse<DefaultResponse>
            //          {
            //              Data = null,
            //              hasError = false,
            //              StatusCode = 200,
            //              Message = result.lstPrimaryProviderChangeRequestStatusModel.Message
            //          });
            //    }
            //    else
            //    {
            //        return StatusCode(StatusCodes.Status200OK,
            //                              new ApiResponse<DefaultResponse>
            //                              {
            //                                  Data = null,
            //                                  hasError = true,
            //                                  StatusCode = 200,
            //                                  Message = result.lstPrimaryProviderChangeRequestStatusModel.Message
            //                              });
            //    }
            //}
            //else
            //{
            //    return BadRequest();
            //}
        }


        /// <summary>
        /// This endpoint returns all plans covered by a specified provider
        /// </summary>
        /// <param name="providerCode"></param>
        /// <returns></returns>

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<ProviderPlansViewModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(ApiRoutes.Providers.ProviderPlans)]
        public async Task<IActionResult> FetchProviderPlans([FromRoute] string providerCode)
        {

            if (string.IsNullOrWhiteSpace(providerCode)) return BadRequest();
            var _client = _httpClientFactory.CreateClient("toshfaClient");

            var request = new HttpRequestMessage(HttpMethod.Get, "listofplanbyprovider");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var results = await response.Content.ReadFromJsonAsync<ToshfaProviderClasses>();

                if (results.lstplanbenefitdetails.Any())
                {
                    var provider = results.lstplanbenefitdetails.FirstOrDefault(x => x.ProviderNo == providerCode);
                    if (provider != null)
                    {
                        var planList = _service.Avon.GetProviderPlans(provider.ProviderClass.ToLower());

                        return StatusCode(StatusCodes.Status200OK,
                            new ApiResponse<List<ProviderPlansViewModel>>
                            {
                                Data = planList,
                                StatusCode = 200
                            });
                    }
                }


            }

            return BadRequest();

        }


        /// <summary>
        /// This endpoint returns most and least utilized hospital
        /// </summary>
        /// <param name="usage_mode">least or most</param>
        /// <returns></returns>

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<UtilizedProviderModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(ApiRoutes.Providers.ProvidersUsageStats)]
        public async Task<IActionResult> UtilizedUnUtilizedProvider([FromQuery] string usage_mode)
        {

            if (string.IsNullOrWhiteSpace(usage_mode)) return BadRequest();

            var _client = _httpClientFactory.CreateClient("toshfaClient");

            var requestUri = string.Empty;

            if (usage_mode.ToLower() == "least")
            {
                requestUri = "LeastUtilisedProvider/GetLeastUtilisedProvider";
            }

            if (usage_mode.ToLower() == "most")
            {
                requestUri = "MostUtilisedProvider/GetMostUtilisedProvider";
            }



            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {


                var results = await response.Content.ReadFromJsonAsync<List<UtilizedProviderModel>>();

                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<List<UtilizedProviderModel>>
                    {
                        Data = results,
                        StatusCode = 200
                    });


            }

            return BadRequest();

        }

        /// <summary>
        /// This endpoint returns list of claims
        /// </summary>
        /// <param name="providerNo"></param>
        /// <param name="memberNo"></param>
        /// <returns></returns>

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<ClaimsModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(ApiRoutes.Providers.ProvidersClaimsList)]
        public async Task<IActionResult> ProviderClaimsList([FromQuery] string providerNo = "", string memberNo = "")
        {

            //  if (string.IsNullOrWhiteSpace(providerNo)) return BadRequest();


            int provider_num = 0;
            int member_num = 0;



            if (!string.IsNullOrWhiteSpace(providerNo))
            {

                if (!int.TryParse(providerNo, out int num))
                {
                    return BadRequest();
                }

                provider_num = int.Parse(providerNo);
            }

            if (!string.IsNullOrWhiteSpace(memberNo))
            {
                if (!int.TryParse(memberNo, out int nnum))
                {
                    return BadRequest();
                }

                member_num = int.Parse(memberNo);
            }

            var _client = _httpClientFactory.CreateClient("toshfaClient");

            var requestUri = "ClaimList/GetClaimList";




            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {


                var results = await response.Content.ReadFromJsonAsync<List<ClaimsModel>>();


                if ((provider_num > 0) && (member_num == 0))
                {
                    results = results.Where(x => x.providerCode == provider_num).ToList();
                }

                if ((provider_num > 0) && (member_num > 0))
                {
                    var cMemberCode = member_num.ToString();

                    results = results.Where(x => x.providerCode == provider_num && x.memberCode == cMemberCode).ToList();
                }

                if ((provider_num == 0) && (member_num > 0))
                {
                    var cMemberCode = member_num.ToString();
                    results = results.Where(x => x.memberCode == cMemberCode).ToList();
                }

                return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<List<ClaimsModel>>
                {
                    Data = results,
                    StatusCode = 200
                });


            }

            return BadRequest();

        }



        /// <summary>
        /// The endpoint is used to change provider manager
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiRoutes.Providers.ProviderManagersChange)]
        [ProducesResponseType(typeof(ApiResponse<DefaultResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangeHCPManager([FromBody] HCPManagerModel model)
        {
            if (model == null) return BadRequest();

            bool response = await _service.Avon.ChangeProviderManager(model);

            if (response)
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<DefaultResponse>
                    {
                        Data = null,
                        StatusCode = 200,
                        hasError =false,
                    });
            }

            return StatusCode(StatusCodes.Status500InternalServerError);

        }



        /// <summary>
        /// This endpoint returns list of HCP guideline Questions
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<ProviderInspectionGuideViewModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(ApiRoutes.Providers.ProvidersGuideQst)]
        public async Task<IActionResult> GuidelineQuestions()
        {
            var qst = await _service.Avon.GetInspectionGuideQestions();

            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<List<ProviderInspectionGuideViewModel>>
                  {
                      Data = qst,
                      Message = "",
                      StatusCode = 200
                  });
        }

        /// <summary>
        /// This endpoint Post HCP guideline
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost(ApiRoutes.Providers.ProvidersGuideQst)]
        public async Task<IActionResult> SaveGuideline([FromBody] ProviderInspectionGuideAnswerDTO model)
        {
            try
            {


                if (await _service.Avon.PostGuideQuestion(model))
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                    {
                        Data = null,
                        Message = "",
                        StatusCode = 200
                    });
                }

            }
            catch
            {

            }

            return StatusCode(StatusCodes.Status500InternalServerError,
                  new ApiResponse<Object>
                  {
                      Data = null,
                      Message = "unable to complete operation",
                      StatusCode = 500
                  });
        }

    }


    public class ProviderCatViewModel
    {
        public string CategoryName { get; set; }
    }

    public class ProviderTypeViewModel
    {
        public string ProviderType { get; set; }
    }


    public class ProviderManagerViewModel
    {
        public string ProvidersName { get; set; }
    }



    public class ToshfaProviderClasses
    {
        public Lstplanbenefitdetail[] lstplanbenefitdetails { get; set; }
    }

    public class Lstplanbenefitdetail
    {
        public string ProviderNo { get; set; }
        public string ProviderName { get; set; }
        public string ProviderClass { get; set; }
        public string ProviderCategory { get; set; }
        public string ProviderType { get; set; }
    }


    //public class Rootobject
    //{
    //    public Class1[] Property1 { get; set; }
    //}

    public class UtilizedProviderModel
    {
        //public string Message { get; set; }
        public int HospNo { get; set; }
        public string ProviderName { get; set; }
        public string Address { get; set; }
        public int CountofPA { get; set; }
    }


    public class ClaimsModel
    {
        public int ClaimBatchNo { get; set; }
        public int ClaimNo { get; set; }
        public string ProviderNo { get; set; }
        public string MemberNo { get; set; }
        public string Status { get; set; }
        public string OPDIPD { get; set; }
        public string ClaimType { get; set; }
        public float Amount { get; set; }
        public int providerCode
        {
            get
            {

                if (this.ProviderNo.Contains("-"))
                {
                    return int.Parse(this.ProviderNo.Substring(this.ProviderNo.LastIndexOf("-") + 1));
                }
                else
                {
                    return 0;
                }


            }
        }


        public string memberCode
        {
            get
            {

                if (this.MemberNo.Contains("-"))
                {



                    return this.MemberNo.Substring(0, this.MemberNo.IndexOf("-"));
                }
                else
                {
                    return "0";
                }


            }
        }
    }


    public class ProviderDocUploadModel
    {
        public string documentType { get; set; }

        public string file { get; set; }


    }


}

