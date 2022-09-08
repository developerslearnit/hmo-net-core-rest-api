using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.Domain.Interfaces.Avon;
using AvonHMO.Entities;
using AvonHMO.Persistence.StorageContexts.Avon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Domain.Services.Avon
{
    /// <summary>
    /// Sign-In,create and find users
    /// Created By: Adesina Mark
    /// Created Date: 30-10-2021
    /// </summary>
    public class AuthenticationRepository : IAuthenticationRepository
    {

        private readonly AvonDbContext _context;
        public AuthenticationRepository(AvonDbContext context)
        {
            _context = context;
        }



        public async Task<bool> CreateUserAccount(UserAccountModel user)
        {

            var memNumber = int.Parse(user.memberNo);

            var userAccount = new AppUserStore()
            {
                UserName = user.userName,
                Password = user.password,
                PasswordSalt = user.passwordSalt,
                Email = user.email,
                DateCreated = DateTime.Now,
                FailedPasswordTries = 0,
                FirstName = user.firstName,
                LastName = user.lastName,
                IsActive = true,
                IsLockedOut = false,
                MobilePhone = user.mobilePhone,
                NextPasswordChangeDate = DateTime.Now.AddDays(90),
                CompanyId = user.companyId,
                MemberNo = memNumber,
                LoginMemberNo = memNumber.ToString(),
                // LastPasswordChangeDate = DateTime.Now
                //LastLoginDate = DateTime.Now,

            };

            if (user.selfCreated)
            {
                userAccount.LastPasswordChangeDate = DateTime.Now;
                // userAccount.LastLoginDate = DateTime.Now;
            }



            await _context.ApplicationUsers.AddAsync(userAccount);



            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<ApiClientModel> FetcAllApiClients()
        {
            return _context.AppClients.AsNoTracking()
                    .Select(x => new ApiClientModel
                    {
                        clientId = x.AppClientId,
                        apiKey = x.ClientApiKey,
                        clientName = x.ClientName,
                        isActive = x.Status,

                    });
        }

        public async Task<LoginTokenModel> FetchLoginToken(string refreshToken, string username)
        {
            return await _context.LoginTokens.Where(x => x.AuthToken == refreshToken && x.Username == username)
                 .AsNoTracking()
                 .OrderByDescending(y => y.LoginTokenId)
                 .Select(u => new LoginTokenModel { authToken = u.AuthToken, username = u.Username, expiryDate = u.ExpiryDate })
                 .FirstOrDefaultAsync();
        }

        public async Task<UserAuthModel> FindUser(string param)
        {

            

            var user = await _context.ApplicationUsers.AsNoTracking().Where(x => x.Email == param)
                                .Select(x => new UserAuthModel { password = x.Password, passwordSalt = x.PasswordSalt, userName = x.UserName })
                                .FirstOrDefaultAsync();

            if (user == null) user = await _context.ApplicationUsers.AsNoTracking().Where(x => x.UserName == param)
                                .Select(x => new UserAuthModel { password = x.Password, passwordSalt = x.PasswordSalt, userName = x.UserName })
                                 .FirstOrDefaultAsync();



            if (user == null) user = await _context.ApplicationUsers.AsNoTracking().Where(x => x.MemberNo.Value.ToString() == param)
                                .Select(x => new UserAuthModel { password = x.Password, passwordSalt = x.PasswordSalt, userName = x.UserName })
                                 .FirstOrDefaultAsync();

            return user;
        }

        public async Task<bool> RemoveUser(Guid id)
        {
            var targetUser = await _context.ApplicationUsers.FindAsync(id);

            if (targetUser == null) return true;

            _context.ApplicationUsers.Remove(targetUser);

            _context.SaveChanges();
            return true;
        }

        public async Task<UserModel> FindUserByEmail(string email)
        {
            return await _context.ApplicationUsers.AsNoTracking().Where(x => x.Email == email)
                 .Select(x => new UserModel
                 {
                     userId = x.UserId,
                     email = x.Email,
                     activeStatus = x.IsActive,
                     firstName = x.FirstName,
                     lastName = x.LastName,
                     mobilePhone = x.MobilePhone,
                     userName = x.UserName,
                     isLockedOut = x.IsLockedOut,
                     memberNo = x.MemberNo.ToString()
                 })
                 .FirstOrDefaultAsync();
        }

        public async Task<UserModel> FindUserById(Guid id)
        {
            return await _context.ApplicationUsers.AsNoTracking().Where(x => x.UserId == id)
                 .Select(x => new UserModel
                 {
                     userId = x.UserId,
                     email = x.Email,
                     activeStatus = x.IsActive,
                     firstName = x.FirstName,
                     lastName = x.LastName,
                     mobilePhone = x.MobilePhone,
                     userName = x.UserName,
                     isLockedOut = x.IsLockedOut,
                     memberNo = x.MemberNo.ToString()
                 })
                 .FirstOrDefaultAsync();
        }

        public async Task<UserModel> FindUserByName(string username)
        {
            var user = await _context.ApplicationUsers.AsNoTracking().Where(x => x.UserName == username)
                 .Select(x => new UserModel
                 {
                     userId = x.UserId,
                     email = x.Email,
                     activeStatus = x.IsActive,
                     firstName = x.FirstName,
                     lastName = x.LastName,
                     mobilePhone = x.MobilePhone,
                     userName = x.UserName,
                     isLockedOut = x.IsLockedOut,
                     memberNo = x.MemberNo.HasValue ? x.MemberNo.ToString() : "0",
                 })
                 .FirstOrDefaultAsync();


            if (user == null)
                user = await _context.ApplicationUsers.AsNoTracking().Where(x => x.MemberNo.ToString() == username)
                 .Select(x => new UserModel
                 {
                     userId = x.UserId,
                     email = x.Email,
                     activeStatus = x.IsActive,
                     firstName = x.FirstName,
                     lastName = x.LastName,
                     mobilePhone = x.MobilePhone,
                     userName = x.UserName,
                     isLockedOut = x.IsLockedOut,
                     memberNo = x.MemberNo.HasValue ? x.MemberNo.ToString() : "0",
                 })
                 .FirstOrDefaultAsync();

            if (user == null)
                user = await _context.ApplicationUsers.AsNoTracking().Where(x => x.Email == username)
                 .Select(x => new UserModel
                 {
                     userId = x.UserId,
                     email = x.Email,
                     activeStatus = x.IsActive,
                     firstName = x.FirstName,
                     lastName = x.LastName,
                     mobilePhone = x.MobilePhone,
                     userName = x.UserName,
                     isLockedOut = x.IsLockedOut,
                     memberNo = x.MemberNo.HasValue ? x.MemberNo.ToString() : "0",
                 })
                 .FirstOrDefaultAsync();



            return user;
        }




        public async Task<LoginResult> LoginWithPassword(string username, string password)
        {
            var potentialUser = await _context.ApplicationUsers.AsNoTracking()
                                .FirstOrDefaultAsync(x => x.UserName == username);

            if (potentialUser == null)
                potentialUser = await _context.ApplicationUsers
                                .FirstOrDefaultAsync(x => x.Email == username);


            if (potentialUser == null)
                potentialUser = await _context.ApplicationUsers
                                .FirstOrDefaultAsync(x => x.LoginMemberNo == username);


            if (potentialUser == null) return new LoginResult
            {
                status = LoginStatus.Failed,
                message = "Wrong username or password"
            };

            if (!potentialUser.IsActive)
                return new LoginResult
                {
                    status = LoginStatus.Deactivated,
                    message = "Your account has been deactivated, please contact your administrator"
                };

            if (potentialUser.IsLockedOut)
                return new LoginResult
                {
                    status = LoginStatus.AccountLocked,
                    message = "Your account has been locked, please contact your administrator"
                };

            if (!potentialUser.Password.Equals(password))
            {
                return new LoginResult
                {
                    status = LoginStatus.Failed,
                    message = "Wrong username or password"
                };
            }

            var currUser = _context.ApplicationUsers.Find(potentialUser.UserId);

            currUser.LastLoginDate = DateTime.Now;

            _context.SaveChanges();

            var requiredPasswordChange = !currUser.LastPasswordChangeDate.HasValue;


            return new LoginResult
            {
                status = LoginStatus.Success,
                message = "Login success",
                requiredPasswordChange = requiredPasswordChange,
                user = new UserModel
                {
                    userId = potentialUser.UserId,
                    email = potentialUser.Email,
                    activeStatus = potentialUser.IsActive,
                    firstName = potentialUser.FirstName,
                    lastName = potentialUser.LastName,
                    mobilePhone = potentialUser.MobilePhone,
                    userName = potentialUser.UserName,
                    memberNo = potentialUser.MemberNo.ToString(),
                }
            };


        }

        public void LogToken(string token, DateTime expiryDate, string username)
        {
            var logToken = new LoginToken()
            {
                AuthToken = token,
                ExpiryDate = expiryDate,
                Username = username
            };

            _context.LoginTokens.Add(logToken);

            _context.SaveChanges();
        }

        public async Task<AppUserStore> FindUser(Guid id)
        {
            return await _context.ApplicationUsers.FindAsync(id);
        }

        public async Task<bool> ChangePassword(ChangePasswordModel model)
        {
            var targetUser = await _context.ApplicationUsers.FindAsync(model.userId);

            if (targetUser == null) return false;

            targetUser.Password = model.newPassword;
            targetUser.LastPasswordResetDate = DateTime.Now;
            targetUser.LastPasswordChangeDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<RoleViewModel> FindRole(Guid roleId)
        {
            return await _context.Roles.AsNoTracking().Where(x => x.RoleId == roleId).Select(x => new RoleViewModel()
            {
                roleId = x.RoleId,
                roleName = x.RoleName

            }).FirstOrDefaultAsync();
        }

        public async Task<RoleViewModel> FindRoleByRoleName(string roleName)
        {
            return await _context.Roles.AsNoTracking().Where(x => x.RoleName == roleName).Select(x => new RoleViewModel()
            {
                roleId = x.RoleId,
                roleName = x.RoleName

            }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RoleViewModel>> FetchRoles()
        {
            return await _context.Roles.AsNoTracking().Select(x => new RoleViewModel()
            {
                roleId = x.RoleId,
                roleName = x.RoleName

            }).ToListAsync();
        }

        public async Task<IEnumerable<RoleViewModel>> FindRole(string username)
        {
            return await (from r in _context.Roles
                          join ur in _context.UserRoles
                              on r.RoleId equals ur.RoleId
                          join usr in _context.ApplicationUsers
                              on ur.UserId equals usr.UserId
                          where usr.UserName == username
                          select new RoleViewModel()
                          {
                              roleId = r.RoleId,
                              roleName = r.RoleName

                          }).ToListAsync();
        }

        public async Task<IEnumerable<UserRoleViewModel>> FindUserRole(Guid userId)
        {
            return await (from r in _context.Roles
                          join ur in _context.UserRoles
                              on r.RoleId equals ur.RoleId
                          join usr in _context.ApplicationUsers
                              on ur.UserId equals usr.UserId
                          where ur.UserId == userId
                          select new UserRoleViewModel()
                          {
                              roleId = r.RoleId,
                              roleName = r.RoleName,
                              username = usr.UserName

                          }).ToListAsync();
        }

        public async Task<bool> AddUserToRole(string roleName, Guid userId)
        {
            var roles = await FetchRoles();
            var targetRole = roles.FirstOrDefault(x => x.roleName == roleName);

            if (targetRole == null) return false;

            var userRole = new UserRole
            {
                CreatedBy = "Admin",
                DateCreated = DateTime.Now,
                Deleted = false,
                RoleId = targetRole.roleId,
                UserId = userId,
                DateUpdated = DateTime.Now,
            };

            await _context.UserRoles.AddAsync(userRole);

            return await _context.SaveChangesAsync() > 0;


        }

        public async Task<UserModel> FindUserByPhone(string phone)
        {
            return await _context.ApplicationUsers.AsNoTracking().Where(x => x.MobilePhone == phone)
                 .Select(x => new UserModel
                 {
                     userId = x.UserId,
                     email = x.Email,
                     activeStatus = x.IsActive,
                     firstName = x.FirstName,
                     lastName = x.LastName,
                     mobilePhone = x.MobilePhone,
                     userName = x.UserName,
                     isLockedOut = x.IsLockedOut,
                     memberNo = x.MemberNo.ToString()
                 })
                 .FirstOrDefaultAsync();
        }

        public async Task<bool> GenerateEnrolleeReferalCode(string code, Guid enrolleeId, int? memberNo)
        {

            var refCode = _context.EnrolleeReferalCodes.AsNoTracking().Where(x => x.EnrolleeId == enrolleeId).FirstOrDefault();

            if (refCode != null) return true;

            var referalCode = new EnrolleeReferalCode()
            {
                EnrolleeId = enrolleeId,
                ReferalCode = code,

            };

            if (memberNo > 0)
            {
                referalCode.MemberNo = memberNo;
            }

            await _context.EnrolleeReferalCodes.AddAsync(referalCode);

            return await _context.SaveChangesAsync() > 0;
        }


        public void RemoveExistingInfo(string userId)
        {
            var existingInfo = _context.ExistingEnrolleAccountInfos.Where(x => x.Email == userId).FirstOrDefault();

            if (existingInfo == null)
            {
                existingInfo = _context.ExistingEnrolleAccountInfos.Where(x => x.MemberNo == userId).FirstOrDefault();                
            }

            if (existingInfo != null)
            {
                _context.ExistingEnrolleAccountInfos.Remove(existingInfo);
            }

            _context.SaveChanges();
        }

        public async Task<bool> CreateExistingUserDetails(string firstName, string lastName,
            string email, string password, string memberNum, bool isAvonStaff = false)
        {
            var newObj = new ExistingEnrolleAccountInfo()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                DateCreated = DateTime.Now,
                EmailSent = false,
                MemberNo = memberNum,
                IsAvonStaff = isAvonStaff
            };


            await _context.ExistingEnrolleAccountInfos.AddAsync(newObj);

            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<int> CountUsers()
        {
            return await _context.ApplicationUsers.CountAsync();
        }

        public async Task<string> GeneratePasswordResetToken(string email, bool isMobile = true)
        {
            var str = generateRandomString(40);

            if (isMobile)
            {
                str = generateRandomNumber(7);
            }


            var link = new PasswordResetRequest()
            {
                Email = email,
                ExpiryDate = DateTime.Now.AddMinutes(90),
                IsUsed = false,
                Token = str
            };

            _context.PasswordChangeRequests.Add(link);
            await _context.SaveChangesAsync();
            return str;


        }

        public void UpdateResetToken(string email)
        {
            var target = _context.PasswordChangeRequests.FirstOrDefault(x => x.Email == email);
            if (target != null)
            {
                target.IsUsed = true;
                target.ExpiryDate = DateTime.Now.AddDays(-2);
                _context.SaveChanges();
            }
        }




        private string generateRandomString(int length)
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }

        private string generateRandomNumber(int length)
        {
            Random random = new Random();
            string characters = "0123456789";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }

        public async Task<bool> IsResetTokenStillValid(string token)
        {
            var resetToken = await _context.PasswordChangeRequests.FirstOrDefaultAsync(x => x.Token == token);
            if (resetToken == null) return false;

            if (resetToken.IsUsed) return false;

            var expiredDate = resetToken.ExpiryDate;

            return expiredDate > DateTime.Now;
        }

        public async Task<bool> ResetPassword(PasswordResetModel model)
        {
            var resetRequest = await _context.PasswordChangeRequests.
                FirstOrDefaultAsync(x => x.Token == model.token && x.Email == model.email && x.IsUsed == false);
            if (resetRequest == null) return false;

            var userAccount = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Email == resetRequest.Email);
            if (userAccount == null) return false;

            userAccount.Password = model.password;
            userAccount.LastLoginDate = DateTime.Now;
            userAccount.LastPasswordChangeDate = DateTime.Now;
            userAccount.NextPasswordChangeDate = DateTime.Now.AddDays(90);
            resetRequest.IsUsed = true;

            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<UserModel> FindUserByMemberNo(int memberNo)
        {
            return await _context.ApplicationUsers.AsNoTracking().Where(x => x.MemberNo == memberNo)
                 .Select(x => new UserModel
                 {
                     userId = x.UserId,
                     email = x.Email,
                     activeStatus = x.IsActive,
                     firstName = x.FirstName,
                     lastName = x.LastName,
                     mobilePhone = x.MobilePhone,
                     userName = x.UserName,
                     isLockedOut = x.IsLockedOut,
                     memberNo = x.MemberNo.ToString()
                 })
                 .FirstOrDefaultAsync();
        }
    }
}
