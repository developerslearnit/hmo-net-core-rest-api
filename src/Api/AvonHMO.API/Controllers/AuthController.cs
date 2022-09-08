using AvonHMO.API.Extensions;
using AvonHMO.API.Models;
using AvonHMO.Application.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using AvonHMO.Domain.Interfaces;
using AvonHMO.Common;
using AvonHMO.Application.ViewModels.Avon.Authentication;
using System.Security.Cryptography;
using AvonHMO.API.Contracts;
using Microsoft.AspNetCore.Identity;
using AvonHMO.Application.Contracts;
using System.Linq;
using AvonHMO.Application.ViewModels.Toshfa;
using AvonHMO.Domain.Interfaces.Toshfa;

namespace AvonHMO.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JWTSettings _jWTSettings;
        private readonly IRepositoryManager _service;
        
        public AuthController(IOptions<JWTSettings> jWTSettings, IRepositoryManager service)
        {
            _jWTSettings = jWTSettings.Value;
            _service = service;
            
        }


        /// <summary>
        /// This endpoint allows user of the application to login to the platform
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns>JWT Token</returns>

        [HttpPost(ApiRoutes.Auth.Login)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<SignInResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {


            if (loginModel == null) return BadRequest();

            var user = await _service.AvonAuth.FindUser(loginModel.userName);

            if (user == null) return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object>
                {
                    Data = null,
                    Message = "Wrong username or password",
                    StatusCode = StatusCodes.Status400BadRequest,
                    hasError = true
                });



            var passwordSalt = user.passwordSalt;

            var hashedPassword = loginModel.password.EncryptSha512(passwordSalt);

            var signInResult = await _service.AvonAuth.LoginWithPassword(loginModel.userName, hashedPassword);

            if (signInResult.status != LoginStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object> { Data = null, Message = signInResult.message, StatusCode = StatusCodes.Status200OK, hasError = true });

            }
            int memberNum = int.Parse(signInResult.user.memberNo.Trim());
           var planClass = await _service.Toshfa.FetchEnrolleePlanClass(memberNum);
            
            string enrolleePlanClass = string.Empty;
            
            if(planClass !=null)
            {
                enrolleePlanClass = planClass.PlanClass;
            }

            var refreshToken = ComputeRefreshToken();
            refreshToken.username = user.userName;

            // var accessToken = "";
            _service.AvonAuth.LogToken(refreshToken.authToken, refreshToken.expiryDate, refreshToken.username);

            var userRoles = await _service.AvonAuth.FindUserRole(signInResult.user.userId);

            List<string> roles = userRoles.Select(x => x.roleName).ToList();

            var jwtToken = await ComputeToken(loginModel.userName, roles);

            var preferencesList = _service.Settings.GetUserPrefs(signInResult.user.userId.ToString());

            if (preferencesList == null)
                preferencesList = _service.Settings.GetUserPrefs(signInResult.user.memberNo);

            var enrolleeId = new Guid();
            var incompleteTasks = new PendingRegistrationModel();
            var enrollee = (await _service.Avon.GetEnrollee()).FirstOrDefault(g => g.enrolleeAccountId == signInResult.user.userId);

            if (enrollee != null)
            {
                enrolleeId = enrollee.enrolleeId;
                incompleteTasks = await _service.Avon.GetEnrolleependingTasks(enrolleeId);
            }

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<SignInResponseModel>
            {
                Data = new SignInResponseModel
                {
                    access_token = jwtToken,
                    refresh_token = refreshToken.authToken,
                    userId = signInResult.user.userId,
                    enrolleeId = enrolleeId,
                    email = signInResult.user.email,
                    firstName = signInResult.user.firstName,
                    lastName = signInResult.user.lastName,
                    userName = signInResult.user.userName,
                    mobilePhone = signInResult.user.mobilePhone,
                    memberNo = signInResult.user.memberNo,
                    requiredPasswordChange = signInResult.requiredPasswordChange,
                    preferences = preferencesList,
                    pendingActivity = incompleteTasks,
                    planClass = enrolleePlanClass
                },
                hasError = false,
            });

        }

        /// <summary>
        /// This endpoint allows enrollee sign in with Google
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Auth.GoogleSignIn)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<SignInResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginWithGoogle([FromBody] UserSocialAuthModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object> { Data = null, Message = "Bad Request" });

            if (!model.email.IsEmailAddress())
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "A valid email address is required"
                   });

            var user = await _service.AvonAuth.FindUser(model.email);


            if (user == null) return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object> { Data = null, Message = "Wrong username or password", StatusCode = StatusCodes.Status200OK, hasError = true });



            var passwordSalt = user.passwordSalt;

            var hashedPassword = model.id.EncryptSha512(passwordSalt);

            var signInResult = await _service.AvonAuth.LoginWithPassword(model.email, hashedPassword);

            if (signInResult.status != LoginStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object> { Data = null, Message = signInResult.message, StatusCode = StatusCodes.Status200OK, hasError = true });

            }

            var refreshToken = ComputeRefreshToken();
            refreshToken.username = user.userName;

            int memberNum = int.Parse(signInResult.user.memberNo.Trim());
            var planClass = await _service.Toshfa.FetchEnrolleePlanClass(memberNum);

            string enrolleePlanClass = string.Empty;

            if (planClass != null)
            {
                enrolleePlanClass = planClass.PlanClass;
            }

            // var accessToken = "";
            _service.AvonAuth.LogToken(refreshToken.authToken, refreshToken.expiryDate, refreshToken.username);


            var jwtToken = await ComputeToken(model.email, new List<string> { "enrollee" });

            var preferencesList = _service.Settings.GetUserPrefs(signInResult.user.userId.ToString());

            if (preferencesList == null)
                preferencesList = _service.Settings.GetUserPrefs(signInResult.user.memberNo);

            //get enrolleeId if the user is an enrollee
            var enrolleeId = new Guid();
            var incompleteTasks = new PendingRegistrationModel();
            var enrollee = (await _service.Avon.GetEnrollee()).FirstOrDefault(g => g.enrolleeAccountId == signInResult.user.userId);

            if (enrollee != null)
            {
                enrolleeId = enrollee.enrolleeId;
                incompleteTasks = await _service.Avon.GetEnrolleependingTasks(enrolleeId);
            }

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<SignInResponseModel>
            {
                Data = new SignInResponseModel
                {
                    access_token = jwtToken,
                    refresh_token = refreshToken.authToken,
                    userId = signInResult.user.userId,
                    enrolleeId = enrolleeId,
                    email = signInResult.user.email,
                    firstName = signInResult.user.firstName,
                    lastName = signInResult.user.lastName,
                    userName = signInResult.user.userName,
                    mobilePhone = signInResult.user.mobilePhone,
                    memberNo = signInResult.user.memberNo,
                    requiredPasswordChange = signInResult.requiredPasswordChange,
                    preferences = preferencesList,
                    pendingActivity = incompleteTasks,
                    planClass = enrolleePlanClass
                },
                hasError = false,
            });
        }



        /// <summary>
        /// This endpoint allows enrollee sign in with any social media accounts
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost(ApiRoutes.Auth.SocialSignIn)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<SignInResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SocialLogin([FromBody] UserSocialAuthModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object> { Data = null, Message = "Bad Request" });

            if (!model.email.IsEmailAddress())
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "A valid email address is required"
                   });

            var user = await _service.AvonAuth.FindUser(model.email);


            if (user == null) return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object> { Data = null, Message = "Wrong username or password", StatusCode = StatusCodes.Status200OK, hasError = true });



            var passwordSalt = user.passwordSalt;

            var hashedPassword = model.id.EncryptSha512(passwordSalt);

            var signInResult = await _service.AvonAuth.LoginWithPassword(model.email, hashedPassword);

            if (signInResult.status != LoginStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object> { Data = null, Message = signInResult.message, StatusCode = StatusCodes.Status200OK, hasError = true });

            }

            var refreshToken = ComputeRefreshToken();
            refreshToken.username = user.userName;
            int memberNum = int.Parse(signInResult.user.memberNo.Trim());

            var planClass = await _service.Toshfa.FetchEnrolleePlanClass(memberNum);

            string enrolleePlanClass = string.Empty;

            if (planClass != null)
            {
                enrolleePlanClass = planClass.PlanClass;
            }

            // var accessToken = "";
            _service.AvonAuth.LogToken(refreshToken.authToken, refreshToken.expiryDate, refreshToken.username);


            var jwtToken = await ComputeToken(model.email, new List<string> { "enrollee" });

            var preferencesList = _service.Settings.GetUserPrefs(signInResult.user.userId.ToString());

            if (preferencesList == null)
                preferencesList = _service.Settings.GetUserPrefs(signInResult.user.memberNo);

            //get enrolleeId if the user is an enrollee
            var enrolleeId = new Guid();
            var incompleteTasks = new PendingRegistrationModel();
           
            var enrollee = (await _service.Avon.GetEnrollee()).FirstOrDefault(g => g.enrolleeAccountId == signInResult.user.userId);

            if (enrollee != null)
            {
                enrolleeId = enrollee.enrolleeId;
                incompleteTasks = await _service.Avon.GetEnrolleependingTasks(enrolleeId);
            }

            return StatusCode(StatusCodes.Status200OK, new ApiResponse<SignInResponseModel>
            {
                Data = new SignInResponseModel
                {
                    access_token = jwtToken,
                    refresh_token = refreshToken.authToken,
                    userId = signInResult.user.userId,
                    enrolleeId = enrolleeId,
                    email = signInResult.user.email,
                    firstName = signInResult.user.firstName,
                    lastName = signInResult.user.lastName,
                    userName = signInResult.user.userName,
                    mobilePhone = signInResult.user.mobilePhone,
                    memberNo = signInResult.user.memberNo,
                    requiredPasswordChange = signInResult.requiredPasswordChange,
                    preferences = preferencesList,
                    pendingActivity = incompleteTasks,
                    planClass = enrolleePlanClass
                },
                hasError = false,
            });
        }

        /// <summary>
        /// This endpoint is called to refresh an expired token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        [Route(ApiRoutes.Auth.RefreshToken)]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshRequestModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object> { Data = null, Message = "Bad Request" });
            var user = await FetchUserFromAccessToken(model.accessToken);

            if (user != null && await ValidateRefreshToken(user, model.refreshToken))
            {

                var userRoles = new List<string>();

                userRoles.Add("client");

                //Add Refresh Token;
                var refreshToken = ComputeRefreshToken();
                refreshToken.username = user.userName;

                // var accessToken = "";
                _service.AvonAuth.LogToken(refreshToken.authToken, refreshToken.expiryDate, refreshToken.username);

                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = new
                        {
                            access_token = ComputeToken(user.userName, userRoles),
                            refreshToken = refreshToken.authToken,
                        },
                        hasError = false,
                    });

            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }



        private async Task<string> ComputeToken(string username, List<string> roles)
        {

            var user = await _service.AvonAuth.FindUserByName(username);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppConstants.JWT_SECRET_KEY);

            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Name, username),
                 new Claim(ClaimTypes.GroupSid,user.userId.ToString()),
                 new Claim(ClaimTypes.GivenName, user.memberNo),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(ClaimTypes.Email, user.email),
            };

            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(_jWTSettings.tokenExipration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        private LoginTokenModel ComputeRefreshToken()
        {
            var randomNumber = new byte[32];
            var refreshToken = new LoginTokenModel();
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                refreshToken.authToken = Convert.ToBase64String(randomNumber);
            }
            refreshToken.expiryDate = DateTime.Now.AddMonths(6);

            return refreshToken;

        }


        private async Task<UserModel> FetchUserFromAccessToken(string accessToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppConstants.JWT_SECRET_KEY);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };

            SecurityToken securityToken;
            string username = string.Empty;
            var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                username = principal.FindFirst(ClaimTypes.Name)?.Value;

                return await _service.AvonAuth.FindUserByName(username);

            }

            return null;

        }

        private async Task<bool> ValidateRefreshToken(UserModel user, string refreshToken)
        {
            var userRefreshToken = await _service.AvonAuth.FetchLoginToken(refreshToken, user.userName.Trim());

            if (userRefreshToken != null && userRefreshToken.expiryDate > DateTime.Now)
            {
                return true;
            }

            return false;
        }

        [HttpPost]
        [Route("password/change")]
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


            var userAccount = await _service.AvonAuth.FindUser(model.userId);

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

            var response = await _service.AvonAuth.ChangePassword(model);

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
