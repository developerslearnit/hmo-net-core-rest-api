using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class MemberApprovalViewModel
    {
        public int RequestNo { get; set; }
        public string AvonPaCode { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string Provider { get; set; }
        public string OPDIPD { get; set; }
        public string ClaimStatus { get; set; }
        public int PolicyNo { get; set; }
        public int MemberNo { get; set; }
        public DateTime FromDate { get; set; }
        public decimal TotalToshfaAmount { get; set; }
        public decimal NegotiatedAmount { get; set; }
        public decimal ModifiedAmount { get; set; }
        public decimal ServicenotfoundAmount { get; set; }
        public decimal PAApprovalAmount { get; set; }

    }
}
