using AvonHMO.Application.ViewModels.Avon.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvonHMO.Entities;

namespace AvonHMO.Domain.Interfaces.Avon
{
    public interface IAuthenticationRepository
    {

        Task<bool> RemoveUser(Guid id);

        IQueryable<ApiClientModel> FetcAllApiClients();

        Task<LoginResult> LoginWithPassword(string username, string password);

        Task<UserModel> FindUserById(Guid id);

        Task<UserModel> FindUserByName(string username);

        Task<int> CountUsers();

        Task<UserModel> FindUserByEmail(string email);

        Task<UserModel> FindUserByPhone(string phone);

        Task<UserAuthModel> FindUser(string param);

        Task<UserModel> FindUserByMemberNo(int memberNo);

        Task<bool> CreateUserAccount(UserAccountModel user);

        //Task<bool> CreateExistingUserDetails(string firstName, string lastName, string email, string password);
        Task<bool> CreateExistingUserDetails(string firstName, string lastName,
            string email, string password, string memberNum, bool isAvonStaff = false);

        Task<LoginTokenModel> FetchLoginToken(string refreshToken, string username);

        void LogToken(string token, DateTime expiryDate, string username);

        Task<AppUserStore> FindUser(Guid id);

        Task<bool> ChangePassword(ChangePasswordModel model);

        Task<RoleViewModel> FindRole(Guid roleId);

        Task<RoleViewModel> FindRoleByRoleName(string roleName);

        Task<IEnumerable<RoleViewModel>> FetchRoles();

        Task<IEnumerable<RoleViewModel>> FindRole(string username);

        Task<IEnumerable<UserRoleViewModel>> FindUserRole(Guid userId);

        Task<bool> AddUserToRole(string roleName, Guid userId);

        Task<bool> GenerateEnrolleeReferalCode(string code, Guid enrolleeId, int? memberNo);

        Task<string> GeneratePasswordResetToken(string email, bool isMobile = true);

        void UpdateResetToken(string email);

        Task<bool> IsResetTokenStillValid(string token);

        Task<bool> ResetPassword(PasswordResetModel model);

        void RemoveExistingInfo(string userId);

    }
}
