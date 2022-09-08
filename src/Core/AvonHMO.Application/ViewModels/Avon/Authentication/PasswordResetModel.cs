using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Authentication
{
    public class PasswordResetModel
    {
        public string token { get; set; }

        public string email { get; set; }
        public string password { get; set; }
    }
}
