using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Authentication
{
    public class UserModel
    {
        public Guid userId { get; set; }
        public string memberNo { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string mobilePhone { get; set; }
        public bool activeStatus { get; set; }
        public bool isLockedOut { get; set; }
        public string groupId { get; set; }
        public List<string> resources { get; set; }
    }


    public class UserAccountModel
    {
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string mobilePhone { get; set; }
        public string password { get; set; }
        public string passwordSalt { get; set; }
        public string companyId { get; set; }
        public string memberNo { get; set; }
        public bool selfCreated { get; set; } = false;

        //public string referalCode { get; set; }
    }

    public class UserAuthModel
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string passwordSalt { get; set; }
    }

    public class UserSocialAuthModel
    {
        public string email { get; set; }
        public string id { get; set; }
    }


    public class UserAccountViewModel
    {


        public string userName { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string mobilePhone { get; set; } 

        [Required]
        public string password { get; set; }

        public string companyId { get; set; }

        public List<PrefModel> client_preferences { get; set; }

        public string userType { get; set; } = "enrollee";


    }

    public class PrefModel
    {
        public string prefType { get; set; } // cycle_planned, referred_earn,toggle_notification,toggle_cycleplanner

        public string prefValue { get; set; }
    }
}
