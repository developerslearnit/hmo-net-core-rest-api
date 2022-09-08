using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Referral
{
    public class ReferralCodeViewModel
    {
        public string referralLink { get; set; }

        public string referralCode { get; set; }
    }

    public class ReferralInviteModel
    {
        public string enrolleeId { get; set; }

        public string referralCode { get; set; }

        public string friendPhone { get; set; }

        public string referralLink { get; set; }
    }

    public class ReferralSMSModel
    {
        public string enrolleeId { get; set; }

        public string referralCode { get; set; }

        public string friendPhone { get; set; }

        public string friendName { get; set; } = "Defualt";
    }


    public class ReferralInviteViewModel
    {
        public string enrolleeId { get; set; }

        public string referralCode { get; set; }

        public string friendPhone { get; set; }

        public string referralLink { get; set; }

        public DateTime refer_date  { get; set; }
    }
}
