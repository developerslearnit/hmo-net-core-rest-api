using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class ApprovalRequestDetailedViewModel
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
        public decimal ServiceNotFoundAmount { get; set; }
        public decimal PAApprovalAmount { get; set; }
        public string ServiceNotFoundDescription { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string LocalGovernmentArea { get; set; }
        public string ClientName { get; set; }
        public string PAIssuedBy { get; set; }
        public string DecisionBy { get; set; }
        public string Notes { get; set; }
    }
}
