using AvonHMO.API.Contracts;
using AvonHMO.API.Controllers;
using AvonHMO.API.Extensions;
using AvonHMO.API.Helpers;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.Application.ViewModels.Avon.Referral;
using AvonHMO.Application.ViewModels.Avon.ViewModels;
using AvonHMO.Common;
using AvonHMO.Domain.Interfaces;
using AvonHMO.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvonHMO.API.Areas.Enrollee.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    public class ReferralController : BaseController
    {
        private readonly IRepositoryManager _service;
        private readonly IIPIntegratedSMS _smsService;
        public ReferralController(IRepositoryManager service, IIPIntegratedSMS smsService)
        {
            _service = service;
            _smsService = smsService;
        }

        /// <summary>
        /// This enpoint returns referral code and share link taking enrolleeId as parameter
        /// </summary>
        /// <param name="enrolleeId"></param>
        /// <returns>referral code and share link</returns>

        [HttpGet]
        [Route(ApiRoutes.Referral.EnrolleeReferal)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(ReferralCodeViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEnrolleeReferralCode([FromRoute] Guid enrolleeId)
        {

            if (enrolleeId == Guid.Empty) return BadRequest();


            //var userId = this.loggedInUserId;
            //var roles = this.loggedInUserRoles;

            ReferralCodeViewModel enrolleeCode = null;

            string referalCode = string.Empty;

            enrolleeCode = await _service.Enrollee.FetchEnrolleeReferalCode(enrolleeId);



            if (enrolleeCode == null)
            {
                referalCode = StringExtensions.RandomString(8, true, true, false).ToUpper();
                await _service.AvonAuth.GenerateEnrolleeReferalCode(referalCode, enrolleeId, 0);

                var shareLink = $"{_service.Settings.GetSetting("WEB_USER_APP")}{referalCode}"; //$"https://avonuser.app?referral_code={referalCode}";

                enrolleeCode = new ReferralCodeViewModel
                {
                    referralCode = referalCode,
                    referralLink = shareLink
                };
            }
            else
            {


                var shareLink = $"{_service.Settings.GetSetting("WEB_USER_APP")}{referalCode}";

                enrolleeCode = new ReferralCodeViewModel
                {
                    referralCode = enrolleeCode.referralCode,
                    referralLink = shareLink
                };
            }

            return StatusCode(StatusCodes.Status200OK,
            new ApiResponse<object>
            {
                Data = enrolleeCode,
                hasError = false,
                StatusCode = 200,

            });
        }


        /// <summary>
        /// This enpoint saved referral history of a given enrollee
        /// </summary>
        /// <param name="model"></param>
        /// <returns>true</returns>

        [HttpPost]
        [Route(ApiRoutes.Referral.EnrolleeReferals)]
        public async Task<IActionResult> PostEnrolleeReferral([FromBody] ReferralInviteModel model)
        {

            if (model == null) return StatusCode(StatusCodes.Status400BadRequest,
                     new ApiResponse<object> { Data = null, Message = "Bad Request", hasError = true, });
            
            try
            {


                // log payload
                //try
                //{
                //    var temlog = new TempLogModel()
                //    {
                //        PayLoad = System.Text.Json.JsonSerializer.Serialize(model),
                //        Action = "Post Referral",
                //        Controller = "Referral",
                //        Message = $"Loging User: {HttpContext.LoggedInUserId()}"
                //    };
                //    await _service.Avon.AddToTempLog(temlog);
                //}
                //catch
                //{


                //}


                var formattedNumber = string.Empty;

                if (!string.IsNullOrWhiteSpace(model.friendPhone))
                {
                    //  var shareLink = $"{_service.Settings.GetSetting("WEB_USER_APP")}{model.referralCode}";


                    if (model.friendPhone.Length == 11)
                    {
                        formattedNumber = $"234{model.friendPhone.Right(10)}";
                    }
                    else if (model.friendPhone.Length > 11)
                    {
                        if (model.friendPhone.Contains("+"))
                        {
                            formattedNumber = model.friendPhone.Right(13);
                        }
                        else
                        {
                            formattedNumber = model.friendPhone;
                        }
                    }




                }


                var result = await _service.Enrollee.AddEnrolleeReferrals(model);

                if (result)
                {
                    if (!string.IsNullOrEmpty(formattedNumber))
                    {
                        var signUpMessage = $"Avon HMO provides best care, join the train for a heathier life." +
                    $"Buy an Avon health plan today, click {model.referralLink}";
                        var smsResponse = await _smsService.SendSMS("Referree", formattedNumber, signUpMessage);


                        if (!smsResponse.posted)
                        {
                            return StatusCode(StatusCodes.Status200OK,
                             new ApiResponse<object>
                             {
                                 Data = null,
                                 hasError = false,
                                 StatusCode = 200,
                                 Message = $"Your referral details has been logged. SMS could not be sent {smsResponse.message}"

                             });
                        }
                    }

                    return StatusCode(StatusCodes.Status200OK,
                          new ApiResponse<object>
                          {
                              Data = null,
                              hasError = false,
                              StatusCode = 200,
                              Message = "Your referral details has been logged"

                          });

                }
            }
            catch (Exception ex)
            {
                try
                {
                    var temlog = new TempLogModel()
                    {
                        PayLoad = ex.ToString(),
                        Action = "Post Referral",
                        Controller = "Referral",
                        Message = $"Loging User: {HttpContext.LoggedInUserId()}"
                    };
                    await _service.Avon.AddToTempLog(temlog);
                }
                catch
                {


                }
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                     new ApiResponse<object> { Data = null, Message = "Bad Request", hasError = true, });


        }


        /// <summary>
        /// This enpoint returns list of enrollee referral histories
        /// </summary>
        /// <param name="enrolleeId"></param>
        /// <returns></returns>

        [HttpGet]
        [Route(ApiRoutes.Referral.AllEnrolleeReferals)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<ReferralInviteViewModel>>), StatusCodes.Status200OK)]
        public IActionResult GetEnrolleeReferralHistories([FromRoute] Guid enrolleeId)
        {

            // log payload
            //try
            //{
            //    var temlog = new TempLogModel()
            //    {
            //        PayLoad =enrolleeId.ToString(),
            //        Action = "GetEnrolleeReferralHistories",
            //        Controller = "Referral",
            //        Message = $"Loging User: {HttpContext.LoggedInUserId()}"
            //    };
            //     _service.Avon.AddToTempLog(temlog).GetAwaiter().GetResult();
            //}
            //catch
            //{


            //}

            var enrolleeReferrals = _service.Enrollee.GetEnrolleeReferrals(enrolleeId).ToList();

            return StatusCode(StatusCodes.Status200OK,
            new ApiResponse<List<ReferralInviteViewModel>>
            {
                Data = enrolleeReferrals,
                hasError = false,
                StatusCode = 200,

            });
        }



    }
}
