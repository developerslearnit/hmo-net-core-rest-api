using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Authentication
{

    public enum LoginStatus
    {
        Failed = 0,
        Success = 1,
        Deactivated = 2,
        AccountLocked = 3,
    }

    public class LoginResult
    {
        public LoginStatus status { get; set; }
        public string message { get; set; }
        public bool requiredPasswordChange { get; set; }
        public UserModel user { get; set; }
    }
}
