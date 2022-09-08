using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoMemberClaimsDetailsViewModel
    {
        public int ClaimNo { get; set; }

        public DateTime ClaimIncurredDate { get; set; }

        public string Provider { get; set; }

        public string OPD_IPD { get; set; }

        public string Capitation { get; set; }

        public string ClaimStatus { get; set; }

        public decimal HNetAmt { get; set; }

        public int PolicyNo { get; set; }

        public int MemberNo { get; set; }

        public DateTime FromDate { get; set; }
    }
}
