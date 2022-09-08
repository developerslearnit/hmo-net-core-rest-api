using AvonHMO.API.Contracts;
using AvonHMO.API.Controllers;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AvonHMO.Common;
using AvonHMO.API.Filters;

namespace AvonHMO.API.Areas.Profile.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}/profile")]
    [ApiController]
    [APIKeyAuth]
    public class ProfileController : BaseController
    {

        private readonly IRepositoryManager _authRepo;
        public ProfileController(IRepositoryManager authRepo)
        {
            this._authRepo = authRepo;
        }
      
        
        /// <summary>
        /// This endpoint is called to change user password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        [Route(ApiRoutes.Profile.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object> { Data = null, Message = "Bad Request" });



            if (string.IsNullOrWhiteSpace(model.oldPassword) || string.IsNullOrWhiteSpace(model.newPassword))
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = "All fields are required"
                    });

            if (!model.confirmPassword.Equals(model.newPassword))
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = "Password and confirm password does not match"
                    });


            var userAccount = await _authRepo.AvonAuth.FindUser(model.userId);

            if (userAccount == null)
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = "Invalid user account"
                    });


            var passwordSalt = userAccount.PasswordSalt;

            var hashedPassword = model.newPassword.EncryptSha512(passwordSalt);

            model.newPassword = hashedPassword;

            var response = await _authRepo.AvonAuth.ChangePassword(model);

            if (response)
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = false,
                        Message = "Password has been changed successfully"
                    });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = "There was an error changing password"
                    });
            }

        }

    }
}
