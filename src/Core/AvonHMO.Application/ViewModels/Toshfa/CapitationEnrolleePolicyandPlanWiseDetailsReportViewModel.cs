using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class CapitationEnrolleePolicyandPlanWiseDetailsReportViewModel
    {
        public int PolicyNo { get; set; }
        public string ClientName { get; set; }
        public int MemberNo { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string Sex { get; set; }
        public string MemberType { get; set; }
        public decimal CapitationAmt { get; set; }
        public DateTime TRANS_DATE { get; set; }
        public int Month { get; set; }
        public string HName { get; set; }

    }
}
