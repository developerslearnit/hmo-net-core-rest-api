using AvonHMO.API.Contracts;
using AvonHMO.API.Controllers;
using AvonHMO.API.Filters;
using AvonHMO.API.Models;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.ViewModels;
using AvonHMO.Common;
using AvonHMO.Domain.Interfaces;
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
    [APIKeyAuth]
    public class CyclePlannerController : BaseController
    {
        private readonly IRepositoryManager _service;

        public CyclePlannerController(IRepositoryManager service)
        {
            _service = service;
        }

        /// <summary>
        /// The EndPoint to call to get cycle planner categories
        /// </summary>
        [HttpGet(ApiRoutes.CyclePlanner.CyclePlannerCategory)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(List<CyclePlannerCategoryViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCyclePlannerCategory()
        {
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = await _service.Avon.GetCyclePlannerCategories(),
                      Message = "",
                      StatusCode = 200
                  });
        }

        /// <summary>
        /// The EndPoint to call to get cycle planner categories by category Id
        /// </summary>

        [HttpGet(ApiRoutes.CyclePlanner.CyclePlannercategoryById)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(List<CyclePlannerCategoryViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCyclePlannerCategoryByCatId([FromRoute] Guid categoryId)
        {
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = (await _service.Avon.GetCyclePlannerCategories())
                      .Where(l => l.cyclePlannerCategoryId == categoryId).ToList(),
                      Message = "",
                      StatusCode = 200
                  });
        }

        /// <summary>
        /// The EndPoint to call to make save cycle planner info
        /// </summary>
        [HttpPost(ApiRoutes.CyclePlanner.PostCycleInfo)]
        public async Task<IActionResult> SaveCyclePlanner([FromBody] CycleInfoRequestModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });
            
            if (model.CyclePlannerCategoryId == new Guid())
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "invalid cyclePlannerCategoryId"
                   });

            var validationErrors = ExceptionHelper.ModelRequiredFieldValidation<CycleInfoRequestModel>(model);
            if (validationErrors.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", validationErrors)
                    });

            if (!Enumerable.Range(21, 35).Contains(model.periodCycle))
                return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = null,
                      hasError = true,
                      Message = "Invalid Period Cycle. The average cycle is 28 days long; however, a cycle can range in length from 21 days to about 35 days"
                  });

            if (!Enumerable.Range(3, 8).Contains(model.periodDuration))
                return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = null,
                      hasError = true,
                      Message = "Invalid Period duration. An Average Period duration ranges from 3 days to about 8 days"
                  });

            var user = Guid.Parse(loggedInUserId);
            if (string.IsNullOrEmpty(model.cycleId) || string.IsNullOrWhiteSpace(model.cycleId))
            {
                var res = await _service.Avon.AddCycleInfo(model, user);

                if (!res.hasError)
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                    {
                        hasError = false,
                        Message = "Cycle Info Added Successfully",
                        Data = new
                        {
                            cycleId = res.cycleId,
                        },
                    });
            }
            else
            {
                var resp = await _service.Avon.UpdateCycleInfo(model, user);
                if (resp)
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                    {
                        hasError = false,
                        Message = "Cycle Info Updated Successfully",
                        Data = null
                    });

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = true,
                    Message = "Unable to update Cycle Info",
                    Data = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                hasError = true,
                Message = "unable to complete the operation",
            });
        }

        /// <summary>
        /// The EndPoint to call to get cycle info for the current loggon enrollee
        /// </summary>
        [HttpGet(ApiRoutes.CyclePlanner.CycleInfo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(List<CycleInfoViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CycleInfos()
        {
            var user = Guid.Parse(loggedInUserId);
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = await _service.Avon.GetCycleInfo(user),
                      Message = "",
                      StatusCode = 200
                  });
        }

        /// <summary>
        /// The EndPoint to call to get most recent cycle info setting for the current app user
        /// </summary>
        [HttpGet(ApiRoutes.CyclePlanner.RecentCycleInfo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(CyclePlannerCategoryViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> RecentCycleInfos()
        {
            var user = Guid.Parse(loggedInUserId);
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = await _service.Avon.GetRecentCycleInfo(user),
                      Message = "",
                      StatusCode = 200
                  });
        }

        [HttpGet(ApiRoutes.CyclePlanner.NextPriodInfo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(List<NextPeriodInfoViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetNextPeriodInfos()
        {
            var user = Guid.Parse(loggedInUserId);
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = await _service.Avon.GetNextPeriodInfo(user),
                      Message = "",
                      StatusCode = 200
                  });
        }


        /// <summary>
        /// The EndPoint to call to get cycle info by cycleId
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(List<CycleInfoViewModel>), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.CyclePlanner.CycleInfoByCycleId)]
        public async Task<IActionResult> CycleInfosByCycleId([FromRoute] Guid cycleid)
        {
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = await _service.Avon.GetCycleInfoByCycleId(cycleid),
                      Message = "",
                      StatusCode = 200
                  });
        }

        /// <summary>
        /// The EndPoint to call to get Count down to the next menstral cycle.
        /// </summary>
        [HttpGet(ApiRoutes.CyclePlanner.countdown)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetNextPeriodcountdownInfos()
        {
            var user = Guid.Parse(loggedInUserId);
            var nextPeriodInfo= await _service.Avon.GetNextPeriodInfo(user);
            var daystoPeriod = 0;
            var isPeriodStartIn3orLessDays=false;
            var msg = string.Empty;
            var pluraliseMsg=string.Empty;
            var detail=string.Empty;

            if (nextPeriodInfo != null && nextPeriodInfo.nextPeriodStartDate >= DateTime.Now)
            {
                var daysTo = nextPeriodInfo.nextPeriodStartDate.Subtract(DateTime.Now).Days + 1;
                if (Enumerable.Range(1, 3).Contains(daysTo))
                {
                    isPeriodStartIn3orLessDays = true;
                    daystoPeriod = daysTo;
                    if (daysTo > 1) pluraliseMsg = "s";
                    msg = $"{daysTo} day{pluraliseMsg} to go";
                    detail = $"Your Mestral Cycle is in 3 day{pluraliseMsg}";
                }
            }

            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data =new 
                      {
                          daysToPeriod= daystoPeriod,
                          isPeriodStartIn3orLessDays = isPeriodStartIn3orLessDays,
                          message= msg
                      },
                      Message = "",
                      StatusCode = 200,
                  });
        }

    }
}
