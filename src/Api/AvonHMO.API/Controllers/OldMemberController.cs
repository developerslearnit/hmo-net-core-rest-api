using AvonHMO.API.Contracts;
using AvonHMO.API.Filters;
using AvonHMO.API.Helpers;
using AvonHMO.API.Models.EmailTemplateTokens;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.Application.ViewModels.Avon.Enrollee;
using AvonHMO.Common;
using AvonHMO.Communications.Sendgrid;
using AvonHMO.Domain.Interfaces;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace AvonHMO.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    //[APIKeyAuth]
    public class OldMemberController : ControllerBase
    {
        private readonly IRepositoryManager _authRepo;

        //private readonly IIPIntegratedSMS _smsService;

        public OldMemberController(IRepositoryManager authRepo)
        {
            _authRepo = authRepo;
            //  _smsService = smsService;
        }


        [HttpGet("member/avon/account")]
        public async Task<IActionResult> GetAvonStaff([FromQuery] PagingParam objModel)
        {
            var memberMaster = await _authRepo.Toshfa.FetchAvonStaffEnrolleeMasterRecord(objModel);

            var listOfMembers = memberMaster.Data.ToList().Where(x => x.EMAIL != "" || x.EMAIL != null).ToList();

            int numOfUsers = 0;

            foreach (var item in listOfMembers)
            {
                var existingUser = await _authRepo.AvonAuth.FindUserByEmail(item.EMAIL.Trim());
                if (existingUser == null)
                {
                    //await _authRepo.AvonAuth.RemoveUser(existingUser.userId);


                    var passwordSalt = StringExtensions.RandomString(50);
                    var randomPassword = StringExtensions.RandomString(8, true, true, true);

                    var hashedPassword = randomPassword.EncryptSha512(passwordSalt);

                    var email = item.EMAIL.Contains(";") ? item.EMAIL.Split(";")[0] : item.EMAIL;


                    var userModel = new UserAccountModel
                    {
                        firstName = item.FirstName,
                        lastName = item.SurName,
                        email = email,
                        mobilePhone = item.MobileNo == "" ? " " : item.MobileNo,
                        password = hashedPassword,
                        passwordSalt = passwordSalt,
                        userName = email,
                        memberNo = item.MemberNo.ToString(),
                        selfCreated = false,


                    };

                    var response = await _authRepo.AvonAuth.CreateUserAccount(userModel);

                    if (response)
                    {


                        // _authRepo.AvonAuth.RemoveExistingInfo(item.EMAIL.Trim());

                        var existUserResponse = await _authRepo.AvonAuth.
                            CreateExistingUserDetails(item.FirstName,
                            item.SurName, email, randomPassword, item.MemberNo.ToString(), true);


                        var referalCode = StringExtensions.RandomString(8, true, true, false).ToUpper();


                        var createdUser = await _authRepo.AvonAuth.FindUserByEmail(item.EMAIL);

                        //var enrolleeExist = await _authRepo.Avon.IsEnrolleeExists(item.MemberNo);

                        // if (enrolleeExist)
                        //  {
                        //  _authRepo.Avon.RemoveEnrollee(item.MemberNo);
                        //  }


                        var enrolleeRec = new EnrolleePayloadModel()
                        {
                            enrolleeIdAccountId = createdUser.userId,
                            firstName = item.FirstName,
                            middleName = item.MiddleName,
                            surname = item.SurName,
                            email = email,
                            dateOfBirth = item.DOB.ToString("dd/MM/yyyy"),
                            gender = item.Gender,
                            providerId = item.PrimaryProviderNo,
                            address = item.Address,
                            country = item.Country,
                            enrolleeType = item.MemberType,
                            state = item.State,
                            providerName = item.PrimaryProviderName,
                            memberNumber = item.MemberNo.ToString(),
                            companyName = item.ClientName,

                        };

                        await _authRepo.Avon.AddEnrollee(enrolleeRec);


                        await _authRepo.AvonAuth.GenerateEnrolleeReferalCode(referalCode, createdUser.userId, 0);

                        await _authRepo.AvonAuth.AddUserToRole("Enrollee", createdUser.userId);
                        numOfUsers++;

                    }




                }





                //}
            }

            return StatusCode(StatusCodes.Status200OK,
                           new ApiResponse<UserModel>
                           { Data = null, hasError = false, Message = $"{numOfUsers.ToString()} user accounts created successfully" });

        }


        [HttpGet("member/account/email")]
        public async Task<IActionResult> MemberMaster([FromQuery] PagingParam objModel)
        {
            var memberMaster = await _authRepo.Toshfa.FetchMemberWithEmail(objModel);



            int numOfUsers = 0;

            foreach (var item in memberMaster)
            {
                var email = item.EMAIL.Contains(";") ? item.EMAIL.Split(";")[0] : item.EMAIL;

                var existingUser = await _authRepo.AvonAuth.FindUserByEmail(email);
                if (existingUser != null)
                {
                    await _authRepo.AvonAuth.RemoveUser(existingUser.userId);
                }

                var passwordSalt = StringExtensions.RandomString(50);
                var randomPassword = StringExtensions.RandomString(8, true, true, true);

                var hashedPassword = randomPassword.EncryptSha512(passwordSalt);


                var userModel = new UserAccountModel
                {
                    firstName = item.FirstName,
                    lastName = item.SurName,
                    email = email,
                    mobilePhone = item.MobileNo == "" ? " " : item.MobileNo,
                    password = hashedPassword,
                    passwordSalt = passwordSalt,
                    userName = email,
                    memberNo = item.MemberNo.ToString(),
                    selfCreated = false,


                };

                var response = await _authRepo.AvonAuth.CreateUserAccount(userModel);

                if (response)
                {


                    _authRepo.AvonAuth.RemoveExistingInfo(email);

                    var existUserResponse = await _authRepo.AvonAuth.
                        CreateExistingUserDetails(item.FirstName,
                        item.SurName, email, randomPassword, item.MemberNo.ToString());


                    var referalCode = StringExtensions.RandomString(8, true, true, false).ToUpper();


                    var createdUser = await _authRepo.AvonAuth.FindUserByEmail(email);

                    //var enrolleeExist = await _authRepo.Avon.IsEnrolleeExists(item.MemberNo);

                    // if (enrolleeExist)
                    //  {
                    _authRepo.Avon.RemoveEnrollee(item.MemberNo);
                    //  }


                    var enrolleeRec = new EnrolleePayloadModel()
                    {
                        enrolleeIdAccountId = createdUser.userId,
                        firstName = item.FirstName,
                        middleName = item.MiddleName,
                        surname = item.SurName,
                        email = email,
                        dateOfBirth = item.DOB.ToString("dd/MM/yyyy"),
                        gender = item.Gender,
                        providerId = item.PrimaryProviderNo,
                        address = item.Address,
                        country = item.Country,
                        enrolleeType = item.MemberType,
                        state = item.State,
                        providerName = item.PrimaryProviderName,
                        memberNumber = item.MemberNo.ToString(),
                        companyName = item.ClientName,

                    };

                    await _authRepo.Avon.AddEnrollee(enrolleeRec);


                    await _authRepo.AvonAuth.GenerateEnrolleeReferalCode(referalCode, createdUser.userId, 0);

                    await _authRepo.AvonAuth.AddUserToRole("Enrollee", createdUser.userId);
                    numOfUsers++;

                }

                //}
            }

            return StatusCode(StatusCodes.Status200OK,
                           new ApiResponse<UserModel>
                           { Data = null, hasError = false, Message = $"{numOfUsers.ToString()} user accounts created successfully" });


        }


        [HttpGet("member/account/no-email")]
        public async Task<IActionResult> MemberMasterIthNo([FromQuery] PagingParam objModel)
        {
            var memberMaster = await _authRepo.Toshfa.FetchMemberWithoutEmail(objModel);

            var listOfMembers = memberMaster.Data.ToList();

            //var listOfMembers = memberMaster.Data.ToList();



            int numOfUsers = 0;

            foreach (var item in listOfMembers)
            {

                var existingUser = await _authRepo.AvonAuth.FindUserByMemberNo(item.MemberNo);
                if (existingUser != null)
                {
                    await _authRepo.AvonAuth.RemoveUser(existingUser.userId);
                }


                var passwordSalt = StringExtensions.RandomString(50);
                var randomPassword = StringExtensions.RandomString(8, true, true, true);

                var hashedPassword = randomPassword.EncryptSha512(passwordSalt);


                var userModel = new UserAccountModel
                {
                    firstName = item.FirstName,
                    lastName = item.SurName,
                    email = " ",
                    mobilePhone = item.MobileNo,
                    password = hashedPassword,
                    passwordSalt = passwordSalt,
                    userName = item.MemberNo.ToString(),
                    memberNo = item.MemberNo.ToString(),
                    selfCreated = false

                };

                var response = await _authRepo.AvonAuth.CreateUserAccount(userModel);

                if (response)
                {

                    _authRepo.AvonAuth.RemoveExistingInfo(item.MemberNo.ToString());

                    var existUserResponse = await _authRepo.AvonAuth.
                        CreateExistingUserDetails(item.FirstName, item.SurName, " ", randomPassword, item.MemberNo.ToString());


                    var referalCode = StringExtensions.RandomString(8, true, true, false).ToUpper();

                    var createdUser = await _authRepo.AvonAuth.FindUserByMemberNo(item.MemberNo);

                    //  var enrolleeExist = await _authRepo.Avon.IsEnrolleeExists(item.MemberNo);

                    //if (enrolleeExist)
                    // {
                    _authRepo.Avon.RemoveEnrollee(item.MemberNo);
                    // }


                    var enrolleeRec = new EnrolleePayloadModel()
                    {
                        enrolleeIdAccountId = createdUser.userId,
                        firstName = item.FirstName,
                        middleName = item.MiddleName,
                        surname = item.SurName,
                        dateOfBirth = item.DOB.ToString("dd/MM/yyyy"),
                        gender = item.Gender,
                        providerId = item.PrimaryProviderNo,
                        address = item.Address,
                        country = item.Country,
                        enrolleeType = item.MemberType,
                        state = item.State,
                        providerName = item.PrimaryProviderName,
                        memberNumber = item.MemberNo.ToString(),
                        companyName = item.ClientName,
                    };

                    await _authRepo.Avon.AddEnrollee(enrolleeRec);

                    await _authRepo.AvonAuth.GenerateEnrolleeReferalCode(referalCode, createdUser.userId, 0);

                    await _authRepo.AvonAuth.AddUserToRole("Enrollee", createdUser.userId);
                    numOfUsers++;

                }


            }

            return StatusCode(StatusCodes.Status200OK,
                           new ApiResponse<UserModel>
                           { Data = null, hasError = false, Message = $"{numOfUsers.ToString()} user accounts created successfully" });


        }



        [HttpGet("member/hhStaff/account")]
        public async Task<IActionResult> GethhStaff([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var memberMaster = await _authRepo.Toshfa.FetchHHStaffEnrolleeMasterRecord(pageNumber, pageSize);

          

            int numOfUsers = 0;

            foreach (var item in memberMaster)
            {
                var email = "N/A";

                var existingUser = await _authRepo.AvonAuth.FindUserByName(item.MemberNo.ToString());

                if (existingUser != null)
                {
                    await _authRepo.AvonAuth.RemoveUser(existingUser.userId);
                }

                var passwordSalt = StringExtensions.RandomString(50);
                var randomPassword = StringExtensions.RandomString(8, true, true, true);

                var hashedPassword = randomPassword.EncryptSha512(passwordSalt);




                var userModel = new UserAccountModel
                {
                    firstName = item.FirstName,
                    lastName = item.SurName,
                    email = email,
                    mobilePhone = item.MobileNo == "" ? " " : item.MobileNo,
                    password = hashedPassword,
                    passwordSalt = passwordSalt,
                    userName = item.MemberNo.ToString(),
                    memberNo = item.MemberNo.ToString(),
                    selfCreated = false,


                };

                var response = await _authRepo.AvonAuth.CreateUserAccount(userModel);

                if (response)
                {


                    _authRepo.AvonAuth.RemoveExistingInfo(item.MemberNo.ToString());

                    var existUserResponse = await _authRepo.AvonAuth.
                        CreateExistingUserDetails(item.FirstName,
                        item.SurName, email, randomPassword, item.MemberNo.ToString(), true);


                    var referalCode = StringExtensions.RandomString(8, true, true, false).ToUpper();


                    var createdUser = await _authRepo.AvonAuth.FindUserByName(item.MemberNo.ToString());

                    //var enrolleeExist = await _authRepo.Avon.IsEnrolleeExists(item.MemberNo);

                    // if (enrolleeExist)
                    //  {
                    //_authRepo.Avon.RemoveEnrollee(item.MemberNo);
                    //  }


                    //if (!enrolleeExist)
                    //{
                    var enrolleeRec = new EnrolleePayloadModel()
                    {
                        enrolleeIdAccountId = createdUser.userId,
                        firstName = item.FirstName,
                        middleName = item.MiddleName,
                        surname = item.SurName,
                        email = email,
                        dateOfBirth = item.DOB.ToString("dd/MM/yyyy"),
                        gender = item.Gender,
                        providerId = item.PrimaryProviderNo,
                        address = item.Address,
                        country = item.Country,
                        enrolleeType = item.MemberType,
                        state = item.State,
                        providerName = item.PrimaryProviderName,
                        memberNumber = item.MemberNo.ToString(),
                        companyName = item.ClientName,

                    };

                    await _authRepo.Avon.AddEnrollee(enrolleeRec);


                    await _authRepo.AvonAuth.GenerateEnrolleeReferalCode(referalCode, createdUser.userId, 0);

                    await _authRepo.AvonAuth.AddUserToRole("Enrollee", createdUser.userId);
                    numOfUsers++;
                    //}





                } //End if not user exists

                // }
            }

            return StatusCode(StatusCodes.Status200OK,
                           new ApiResponse<UserModel>
                           { Data = null, hasError = false, Message = $"{numOfUsers.ToString()} user accounts created successfully" });

        }



    }
}
