using AvonHMO.API.Contracts;
using AvonHMO.API.Controllers;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Communication;
using AvonHMO.Application.ViewModels.Avon.EnrolleFlow;
using AvonHMO.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AvonHMO.API.Areas.Enrollee.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    public class NotificationController : BaseController
    {
        private readonly IRepositoryManager _service;
        public NotificationController(IRepositoryManager service)
        {
            _service = service;
        }

        

        [HttpGet]
        [Route("notifications/{enrolleeId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<NotificationLogVM>>), StatusCodes.Status200OK)]
        public IActionResult FetchNotifications([FromRoute] string enrolleeId)
        {

            var notifications = _service.Avon.PendingNotifications(enrolleeId).ToList();

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<NotificationLogVM>>
            {
                Data = notifications,
                hasError=false,
                StatusCode=StatusCodes.Status200OK

            });

        }
    }
}
