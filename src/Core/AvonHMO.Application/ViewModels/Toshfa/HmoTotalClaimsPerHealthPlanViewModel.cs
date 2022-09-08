using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoTotalClaimsPerHealthPlanViewModel
    {
        public string ClientName { get; set; }

        public int PolicyNo { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime PolicyInception { get; set; }

        public int MemberNo { get; set; }

        public string MemberHeadNo { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string Name { get; set; }

        public string PlanType { get; set; }

        public string PlanTypeCategory { get; set; }

        public decimal PAIDAMOUNT { get; set; }

        public int ClaimNo { get; set; }

        public DateTime ClaimIncurredDate { get; set; }

        public DateTime ClaimReceivedDate { get; set; }

        public int HOSPNO { get; set; }

        public string HospitalName { get; set; }

        public string SBU { get; set; }
    }
}
