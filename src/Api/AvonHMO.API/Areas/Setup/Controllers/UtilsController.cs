using AvonHMO.API.Filters;
using AvonHMO.API.Models;
using AvonHMO.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvonHMO.API.Areas.Setup.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    [APIKeyAuth]
    public class UtilsController : ControllerBase
    {


        [HttpGet("utils/nhis/{amount}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<DefaultResponse>), StatusCodes.Status200OK)]
        public IActionResult CalculateNHIS([FromRoute] decimal amount)
        {


            var onePercent = (double) amount * 0.01;

            return StatusCode(StatusCodes.Status200OK,new ApiResponse<object>
            {
                Data = onePercent.ToString(),
                hasError = false,
                StatusCode =200
            });
        }

    }
}
