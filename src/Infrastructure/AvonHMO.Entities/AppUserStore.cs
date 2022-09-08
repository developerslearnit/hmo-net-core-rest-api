using System;

namespace AvonHMO.Entities
{
    public partial class AppUserStore
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int? MemberNo { get; set; }
        public string LoginMemberNo { get; set; }
        public string CompanyId { get; set; }
        public bool IsActive { get; set; }
        public bool IsLockedOut { get; set; }
        public int FailedPasswordTries { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastDeactivatedDate { get; set; }
        public DateTime? LastPasswordResetDate { get; set; }
        public DateTime? LastPasswordChangeDate { get; set; }
        public DateTime? NextPasswordChangeDate { get; set; }
       
    }
}
