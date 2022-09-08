using AvonHMO.API.Areas.UserPref.Models;
using AvonHMO.API.Contracts;
using AvonHMO.API.Controllers;
using AvonHMO.API.Filters;
using AvonHMO.API.Models;
using AvonHMO.Application.Contracts;
using AvonHMO.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace AvonHMO.API.Areas.UserPref.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    [APIKeyAuth]
    public class UserPreferencesController : BaseController
    {

        private readonly IRepositoryManager _repository;
        public UserPreferencesController(IConfiguration config, IRepositoryManager repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// This endpoint allows enrollee set their preferences
        /// </summary>
        /// <remarks>
        ///  PrefTypes: cycle_planned, referer_sent,toggle_notification,toggle_cycleplanner
        /// </remarks>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.PrefRote.UserPref)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(ApiResponse<DefaultResponse>), StatusCodes.Status200OK)]
        public IActionResult SetUserPreference([FromBody] UserPrefModel model)
        {
            if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<DefaultResponse>
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Bad request"
            });

            if (string.IsNullOrWhiteSpace(model.prefType)) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<DefaultResponse>
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Preference type is required"
            });

            if (string.IsNullOrWhiteSpace(model.prefValue)) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<DefaultResponse>
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Preference value is required"
            });

            if (string.IsNullOrWhiteSpace(model.enrollee_id)) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<DefaultResponse>
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Enrollee id is required"
            });




            _repository.Settings.SetUserPref(model.prefType, model.enrollee_id, model.prefValue);

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<DefaultResponse>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Preference updated"
            });

        }



        [HttpGet(ApiRoutes.PrefRote.UserPref)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(ApiResponse<DefaultResponse>), StatusCodes.Status200OK)]
        public IActionResult GetUserPreference([FromQuery] string prefType, string enrollee_id)
        {


            if (string.IsNullOrWhiteSpace(prefType) || string.IsNullOrWhiteSpace(enrollee_id)) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<DefaultResponse>
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Preference type and enrollee id are required"
            });



            var prefValue = _repository.Settings.GetUserPref(prefType, enrollee_id);

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
            {
                Data = new
                {
                    prefValue = prefValue,
                    prefType = prefType,
                },
                StatusCode = StatusCodes.Status200OK,
                Message = ""
            });

        }

    }
}
