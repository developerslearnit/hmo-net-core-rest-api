using AvonHMO.API.Contracts;
using AvonHMO.API.Filters;
using AvonHMO.API.Helpers;
using AvonHMO.API.Models;
using AvonHMO.API.Models.EmailTemplateTokens;
using AvonHMO.API.NotificationHelper;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.Application.ViewModels.Avon.Post;
using AvonHMO.Application.ViewModels.Common;
using AvonHMO.Common;
using AvonHMO.Communications.Sendgrid;
using AvonHMO.Domain.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AvonHMO.API.Areas.Account.Controllers
{



    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}/accounts")]
    [ApiController]
    [APIKeyAuth]
    public class AccountController : ControllerBase
    {
        private readonly IRepositoryManager _authRepo;
        IWebHostEnvironment _env;
        IEmailService _emailService;
        private readonly IIPIntegratedSMS _smsService;
        private static string signUpMessage = "Welcome to the Avon HMO app, your sign-up was successful. Please check your email for additional information";
        public AccountController(IRepositoryManager authRepo, IWebHostEnvironment env, IIPIntegratedSMS smsService, IEmailService emailService)
        {
            this._authRepo = authRepo;
            _env = env;
            _smsService = smsService;
            _emailService = emailService;
        }



        /// <summary>
        /// This endpoint creates a new user login account
        /// </summary>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="200">Returns list of posts</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<UserModel>), StatusCodes.Status200OK)]
        [Route("")]
        public async Task<IActionResult> CreateAccount([FromBody] UserAccountViewModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object> { Data = null, Message = "Bad Request" });



            var errorMessages = ExceptionHelper.ModelRequiredFieldValidation<UserAccountViewModel>(model);

            if (errorMessages.Any())
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = string.Join("; ", errorMessages)
                    });

            if (!model.email.IsEmailAddress())
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "A valid email address is required"
                   });

            var existingUser = await _authRepo.AvonAuth.FindUserByEmail(model.email.Trim());

            if (existingUser != null) return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "A customer with this email address already exist"
                   });

            var userWithSamePhone = await _authRepo.AvonAuth.FindUserByPhone(model.mobilePhone);

            if (userWithSamePhone != null) return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "A customer with this phone number already exist"
                   });



            var passwordSalt = StringExtensions.RandomString(50);

            var hashedPassword = model.password.EncryptSha512(passwordSalt);

            var memberNum = await generateTempMemberNumber();

            var userModel = new UserAccountModel
            {
                firstName = model.firstName,
                lastName = model.lastName,
                email = model.email,
                mobilePhone = model.mobilePhone,
                password = hashedPassword,
                passwordSalt = passwordSalt,
                userName = model.email,
                companyId = model.companyId,
                memberNo = memberNum.ToString(),
                selfCreated = true

            };



            var response = await _authRepo.AvonAuth.CreateUserAccount(userModel);

            if (response)
            {

                var referalCode = StringExtensions.RandomString(8, true, true, false).ToUpper();


                var createdUser = await _authRepo.AvonAuth.FindUserByEmail(model.email.Trim());

                switch (model.userType)
                {
                    case "enrollee":
                        await _authRepo.AvonAuth.GenerateEnrolleeReferalCode(referalCode, createdUser.userId, 0);

                        await _authRepo.AvonAuth.AddUserToRole("Enrollee", createdUser.userId);
                        break;
                    case "hcp":
                        await _authRepo.AvonAuth.AddUserToRole("Provider", createdUser.userId);
                        break;

                    case "admin":
                        await _authRepo.AvonAuth.AddUserToRole("Admin", createdUser.userId);
                        break;

                    case "client":
                        await _authRepo.AvonAuth.AddUserToRole("Client", createdUser.userId);
                        break;
                    default:
                        await _authRepo.AvonAuth.GenerateEnrolleeReferalCode(referalCode, createdUser.userId, 0);

                        await _authRepo.AvonAuth.AddUserToRole("Enrollee", createdUser.userId);
                        break;
                }





                var templateName = "new_account_welcome";

                var templateBuilder = new EmailTemplateBuilder(_env, templateName);

                var templateResult = templateBuilder.BuildTemplate(new NewAccountEmailToken()
                {
                    firstName = userModel.firstName,
                    email = userModel.email,
                    password = model.password
                });

                var sendersEmail = _authRepo.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);

               // var sendersName = _authRepo.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

               

                _emailService.Send("Login Details", userModel.email, templateResult,null,null,sendersEmail);


                if (!string.IsNullOrWhiteSpace(userModel.mobilePhone))
                {
                    var formattedNumber = string.Empty;

                    if (userModel.mobilePhone.Length == 11)
                    {
                        formattedNumber = $"234{userModel.mobilePhone.Right(10)}";
                    }
                    else if (userModel.mobilePhone.Length > 11)
                    {
                        if (userModel.mobilePhone.Contains("+"))
                        {
                            formattedNumber = userModel.mobilePhone.Right(13);
                        }
                        else
                        {
                            formattedNumber = userModel.mobilePhone;
                        }
                    }
                    else
                    {
                        formattedNumber = userModel.mobilePhone;
                    }

                    var smsResponse = await _smsService.SendSMS(userModel.firstName, formattedNumber, signUpMessage);


                }


                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<UserModel>
                    { Data = createdUser, hasError = false, Message = "User Account created successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error creating user account"
                    });
            }


        }


        /// <summary>
        /// This endpoint creates a new user login account
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("google")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> SignUpWithGoogle([FromBody] UserAccountViewModel model)
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

            var existingUser = await _authRepo.AvonAuth.FindUserByEmail(model.email.Trim());

            if (existingUser != null) return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "A customer with this email address already exist"
                   });




            var passwordSalt = StringExtensions.RandomString(50);

            var hashedPassword = model.password.EncryptSha512(passwordSalt);
            var memberNum = await generateTempMemberNumber();

            var userModel = new UserAccountModel
            {
                firstName = model.firstName,
                lastName = model.lastName,
                email = model.email,
                mobilePhone = model.mobilePhone,
                password = hashedPassword,
                passwordSalt = passwordSalt,
                userName = model.email,
                selfCreated = true,
                memberNo = memberNum.ToString(),
                // companyId = model.companyId,

            };



            var response = await _authRepo.AvonAuth.CreateUserAccount(userModel);

            if (response)
            {

                var referalCode = StringExtensions.RandomString(8, true, true, false).ToUpper();


                var createdUser = await _authRepo.AvonAuth.FindUserByEmail(model.email.Trim());

                switch (model.userType)
                {
                    case "enrollee":
                        await _authRepo.AvonAuth.GenerateEnrolleeReferalCode(referalCode, createdUser.userId, 0);

                        await _authRepo.AvonAuth.AddUserToRole("Enrollee", createdUser.userId);
                        break;
                    case "hcp":
                        await _authRepo.AvonAuth.AddUserToRole("Provider", createdUser.userId);
                        break;

                    case "admin":
                        await _authRepo.AvonAuth.AddUserToRole("Admin", createdUser.userId);
                        break;

                    case "client":
                        await _authRepo.AvonAuth.AddUserToRole("Client", createdUser.userId);
                        break;
                    default:
                        await _authRepo.AvonAuth.GenerateEnrolleeReferalCode(referalCode, createdUser.userId, 0);

                        await _authRepo.AvonAuth.AddUserToRole("Enrollee", createdUser.userId);
                        break;
                }

                if (!string.IsNullOrWhiteSpace(userModel.mobilePhone))
                {
                    var formattedNumber = string.Empty;

                    if (userModel.mobilePhone.Length == 11)
                    {
                        formattedNumber = $"234{userModel.mobilePhone.Right(10)}";
                    }
                    else if (userModel.mobilePhone.Length > 11)
                    {
                        if (userModel.mobilePhone.Contains("+"))
                        {
                            formattedNumber = userModel.mobilePhone.Right(13);
                        }
                        else
                        {
                            formattedNumber = userModel.mobilePhone;
                        }
                    }


                    var smsResponse = await _smsService.SendSMS(userModel.firstName, formattedNumber, signUpMessage);


                }


                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<UserModel>
                    { Data = createdUser, hasError = false, Message = "User Account created successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error creating user account"
                    });
            }


        }

        /// <summary>
        /// This endpoint allow user to request for password reset token when they forget password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost(ApiRoutes.Accounts.RequestPasswordChangeLink)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> SendForgotPasswordLinkEmail([FromBody] ChangePasswordReqViewModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object> { Data = null, Message = "Bad Request" });

            if (string.IsNullOrWhiteSpace(model.email)) return StatusCode(StatusCodes.Status200OK,
                     new ApiResponse<object> { Data = null, Message = "Email is required" });

            if (!model.email.IsEmailAddress())
                return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "A valid email address is required"
                   });


            var allowedPlatforms = new[] { "mobile", "web" };

            if (!allowedPlatforms.Contains(model.platform.ToLower())) return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        Message = "Allowed platform can only be mobile or web"
                    });




            var user = await _authRepo.AvonAuth.FindUserByEmail(model.email);

            if (user == null) return StatusCode(StatusCodes.Status200OK,
                       new ApiResponse<object>
                       {
                           Data = null,
                           hasError = true,
                           Message = "If the provided email exists, A password reset token has been sent to your email"
                       });


            _authRepo.AvonAuth.UpdateResetToken(user.email.Trim());

            bool isMobile = model.platform.ToLower().Trim() == "mobile" ? true : false;

            var resetToken = await _authRepo.AvonAuth.GeneratePasswordResetToken(user.email, isMobile);

            var finalLinkOrCode = string.Empty;
            if (isMobile)
            {
                finalLinkOrCode = resetToken;
            }
            else
            {
                resetToken = $"{_authRepo.Settings.GetSetting("WEB_USER_APP") }{resetToken}";
            }


            var templateName = "password_reset";

            var templateBuilder = new EmailTemplateBuilder(_env, templateName);

            var templateResult = templateBuilder.BuildTemplate(new ForgotPasswordEmailToken()
            {
                firstName = user.firstName,
                token = resetToken
            });

            var sendersEmail = _authRepo.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);


            _emailService.Send("Reset Password", model.email, templateResult, null, null, sendersEmail);



            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<object>
                { Data = null, hasError = false, Message = "If the provided email exists, A password reset token has been sent to your email" });

        }

        /// <summary>
        /// This endpoint reset user password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost(ApiRoutes.Accounts.ResetPassword)]
        [ProducesResponseType(200)]
        //[ProducesResponseType(500)]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> ResetPassword([FromBody] PasswordResetModel model)
        {
            if (model == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ApiResponse<object> { Data = null, hasError = true, Message = "Bad Request" });

            if (string.IsNullOrWhiteSpace(model.email)) return StatusCode(StatusCodes.Status200OK,
                     new ApiResponse<object> { Data = null, hasError = true, Message = "Email is required" });

            if (!model.email.IsEmailAddress())
                return StatusCode(StatusCodes.Status400BadRequest,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "A valid email address is required"
                   });

            if (string.IsNullOrWhiteSpace(model.password)) return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object> { Data = null, hasError = true, Message = "Password is required" });

            var tokenValid = await _authRepo.AvonAuth.IsResetTokenStillValid(model.token);

            if (!tokenValid) return StatusCode(StatusCodes.Status200OK,
                      new ApiResponse<object> { Data = null, hasError = true, Message = "This password reset token is expired" });

            var user = await _authRepo.AvonAuth.FindUser(model.email);

            if (user == null) return StatusCode(StatusCodes.Status404NotFound,
                      new ApiResponse<object>
                      {
                          Data = null,
                          hasError = true,
                          Message = "User with this email does not exist"
                      });


            var hashedPassword = model.password.EncryptSha512(user.passwordSalt);
            model.password = hashedPassword;


            var result = await _authRepo.AvonAuth.ResetPassword(model);
            if (result) return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<UserModel>
                { Data = null, hasError = false, Message = "Your password was reset successfully" });


            return StatusCode(StatusCodes.Status500InternalServerError,
                      new ApiResponse<object>
                      {
                          Data = null,
                          hasError = true,
                          Message = "We couldn't reset your password due to an error"
                      });



        }


        /// <summary>
        /// This endpoint allows enrolle to signup with any social media account
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("social")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> SocialSignUp([FromBody] UserAccountViewModel model)
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

            var existingUser = await _authRepo.AvonAuth.FindUserByEmail(model.email.Trim());

            if (existingUser != null) return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<object>
                   {
                       Data = null,
                       hasError = true,
                       Message = "A customer with this email address already exist"
                   });



            var passwordSalt = StringExtensions.RandomString(50);

            var hashedPassword = model.password.EncryptSha512(passwordSalt);
            var memberNum = await generateTempMemberNumber();

            var userModel = new UserAccountModel
            {
                firstName = model.firstName,
                lastName = model.lastName,
                email = model.email,
                mobilePhone = model.mobilePhone,
                password = hashedPassword,
                passwordSalt = passwordSalt,
                userName = model.email,
                selfCreated = true,
                memberNo = memberNum.ToString(),
                // companyId = model.companyId,

            };



            var response = await _authRepo.AvonAuth.CreateUserAccount(userModel);

            if (response)
            {

                var referalCode = StringExtensions.RandomString(8, true, true, false).ToUpper();


                var createdUser = await _authRepo.AvonAuth.FindUserByEmail(model.email.Trim());

                //  await _authRepo.AvonAuth.GenerateEnrolleeReferalCode(referalCode, createdUser.userId, 0);

                switch (model.userType)
                {
                    case "enrollee":
                        await _authRepo.AvonAuth.GenerateEnrolleeReferalCode(referalCode, createdUser.userId, 0);

                        await _authRepo.AvonAuth.AddUserToRole("Enrollee", createdUser.userId);
                        break;
                    case "hcp":
                        await _authRepo.AvonAuth.AddUserToRole("Provider", createdUser.userId);
                        break;

                    case "admin":
                        await _authRepo.AvonAuth.AddUserToRole("Admin", createdUser.userId);
                        break;

                    case "client":
                        await _authRepo.AvonAuth.AddUserToRole("Client", createdUser.userId);
                        break;
                    default:
                        await _authRepo.AvonAuth.GenerateEnrolleeReferalCode(referalCode, createdUser.userId, 0);

                        await _authRepo.AvonAuth.AddUserToRole("Enrollee", createdUser.userId);
                        break;
                }

                if (!string.IsNullOrWhiteSpace(userModel.mobilePhone))
                {
                    var formattedNumber = string.Empty;

                    if (userModel.mobilePhone.Length == 11)
                    {
                        formattedNumber = $"234{userModel.mobilePhone.Right(10)}";
                    }
                    else if (userModel.mobilePhone.Length > 11)
                    {
                        if (userModel.mobilePhone.Contains("+"))
                        {
                            formattedNumber = userModel.mobilePhone.Right(13);
                        }
                        else
                        {
                            formattedNumber = userModel.mobilePhone;
                        }
                    }


                    var smsResponse = await _smsService.SendSMS(userModel.firstName, formattedNumber, signUpMessage);


                }


                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<UserModel>
                    { Data = createdUser, hasError = false, Message = "User Account created successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<object>
                    {
                        Data = null,
                        hasError = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "There was an error creating user account"
                    });
            }


        }




        private async Task<string> generateTempMemberNumber()
        {
            
            string _symb = "1100000";

            var lastNum = await _authRepo.AvonAuth.CountUsers();

            lastNum = lastNum + 1;

            var result = int.Parse($"{_symb}{lastNum.ToString()}".Right(9));

            return $"-{result.ToString()}";
        }

    }


}
