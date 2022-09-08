using System;

namespace AvonHMO.Application.ViewModels.Avon.Authentication
{
    public class ChangePasswordModel
    {
        public Guid userId { get; set; }

        public string oldPassword { get; set; }

        public string newPassword { get; set; }

        public string confirmPassword { get; set; }
    }

    public class ChangePasswordReqViewModel
    {
        public string email { get; set; }
        public string platform { get; set; } = "mobile";
    }
}
