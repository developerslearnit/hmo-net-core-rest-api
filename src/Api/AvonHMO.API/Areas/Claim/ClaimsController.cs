using AvonHMO.API.Contracts;
using AvonHMO.API.Controllers;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Plan;
using AvonHMO.Common;
using AvonHMO.Domain.Interfaces;
using BrightStar.Util.Storage.RepoManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvonHMO.API.Areas.Claim
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    public class ClaimsController : BaseController
    {
        private readonly IRepositoryManager _service;
        private readonly IStorageRepoManager _storageService;
        private readonly IConfiguration _config;

        public ClaimsController(IRepositoryManager service, IStorageRepoManager storageService, IConfiguration config)
        {
            _service = service;
            _storageService = storageService;
            _config = config;
        }


        /// <summary>
        /// This endpoint create claims
        /// </summary>
        /// <param name="claimModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Claims.CreateClaims)]
        public async Task<IActionResult> CreateClaims([FromBody] ClaimsRequestModel claimModel)
        {

            if (claimModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<ClaimsRequestModel>(claimModel);


            if (errorMessage.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessage)
                    });


            var createResult = await _service.Avon.CreateClaims(claimModel);

            if (createResult)
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = "Claims created successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error creating Claims"
                    });
            }

        }


        /// <summary>
        /// The endPoint to call to get all claims
        /// </summary>
        [HttpGet(ApiRoutes.Claims.GetAllClaims)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<ClaimsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllClaims()
        {
            return StatusCode(StatusCodes.Status200OK,
                  new ApiResponse<object>
                  {
                      Data = await _service.Avon.GetClaims(),
                      Message = "",
                      StatusCode = 200
                  });
        }


        /// <summary>
        /// This enpoint returns  claims detail by claim Id
        /// </summary>
        /// <returns> Enrollee contact detail</returns>
        /// 

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<ClaimsViewModel>), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Claims.GetClaimDetailById)]
        public async Task<IActionResult> GetClaimDetailById([FromRoute] Guid claimID)
        {

            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object>
                {
                    Data = await _service.Avon.GetClaimInfo(claimID),
                    Message = "",
                    StatusCode = 200
                });
        }


        /// <summary>
        /// This endpoint update claim status
        /// </summary>
        /// <param name="claimModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Claims.UpdateClaimStatus)]
        public async Task<IActionResult> UpdateClaimStatus([FromBody] ClaimsUpdateViewModel claimModel)
        {

            if (claimModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<ClaimsUpdateViewModel>(claimModel);


            if (errorMessage.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessage)
                    });

            var claimExist = await _service.Avon.IsClaimIDExist(claimModel.ClaimId);

            if (!claimExist)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = true,
                    Message = "This claim does not exist",
                    Data = null
                });
            }

            var createResult = await _service.Avon.UpdateClaimStatus(claimModel);

            if (createResult)
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = "Claims status updated successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error updating Claims status"
                    });
            }

        }
        


        /// <summary>
        /// This endpoint close claims by claimID
        /// </summary>
        /// <param name="claimModel"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Claims.CloseClaim)]
        public async Task<IActionResult> CloseClaims([FromBody] CloseClaimsModel claimModel)
        {

            if (claimModel == null) return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessage = ExceptionHelper.ModelRequiredFieldValidation<CloseClaimsModel>(claimModel);


            if (errorMessage.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessage)
                    });

            var claimExist = await _service.Avon.IsClaimIDExist(claimModel.ClaimId);

            if (!claimExist)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    hasError = true,
                    Message = "This claim does not exist",
                    Data = null
                });
            }

            var createResult = await _service.Avon.CloseClaimInfo(claimModel);

            if (createResult)
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    { Data = null, hasError = false, Message = "Claims Closed successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error closing Claims "
                    });
            }

        }

        /// <summary>
        /// This enpoint searches through Claims 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.Claims.SearchClaims)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<List<ClaimsViewModel>>), StatusCodes.Status200OK)]
        public IActionResult FAQwithSearch([FromQuery] PagingParam pagination, [FromQuery] string searchText)
        {
            var claims = _service.Avon.SearchClaims(pagination, searchText).ToList();

            return StatusCode(StatusCodes.Status200OK,
               new PagedResponse<ClaimsViewModel>
               {
                   Data = claims,
                   hasError = false,
                   PageNumber = pagination.PageNumber,
                   PageSize = pagination.PageSize,
                   StatusCode = 200,

               });

        }

    }
}
