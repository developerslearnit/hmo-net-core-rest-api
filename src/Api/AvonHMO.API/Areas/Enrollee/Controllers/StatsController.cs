using AvonHMO.API.Controllers;
using AvonHMO.Application.Contracts;
using AvonHMO.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AvonHMO.API.Areas.Enrollee.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    public class StatsController : BaseController
    {

        private readonly IRepositoryManager _service;

        public StatsController(IRepositoryManager service)
        {
            _service = service;
        }

        [HttpGet("stats/enrollee-profile/completion-level/{enrolleId}")]
        public async Task<IActionResult> EnrolleeProfileSetupPercentage([FromRoute] Guid enrolleId)
        {
            var percentage = 0;

            var basicInfo = await _service.Enrollee.FetchLocalEnrollee(enrolleId);


            if (basicInfo == null) return StatusCode(StatusCodes.Status200OK,
                 new ApiResponse<object> { Data = 0, Message = "" });

            if (basicInfo != null) { }
            percentage = 50;

            var enrolleDependant = _service.Enrollee.FetchLocalEnrolleeDependents(basicInfo.EMAIL);

            if(enrolleDependant != null)
            {
                percentage = 100;
            }

            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object> { Data = percentage, Message = "" });

        }

    }
}
