using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoMemberPolicyLimitsExhaustedAndAvailableViewModel
    {
        public int Sno { get; set; }

        public int Policyno { get; set; }

        public DateTime FRomDate { get; set; }

        public int ClassCode { get; set; }

        public int MemberNo { get; set; }

        public string Limits { get; set; }

        public decimal PolicyLimit { get; set; }

        public decimal ApprovedInLC { get; set; }

        public decimal Exhausted { get; set; }

        public decimal Available { get; set; }
    }
}
