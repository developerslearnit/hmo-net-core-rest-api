using AvonHMO.Application.ViewModels.Avon.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Common
{
    public class SignInResponseModel
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public Guid userId { get; set; }
        public Guid enrolleeId { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string mobilePhone { get; set; }
        public string memberNo { get; set; }
        public string planClass { get; set; }
        public bool requiredPasswordChange { get; set; }
        public List<PrefModel> preferences { get; set; }
        public PendingRegistrationModel pendingActivity { get; set; }
    }



}
