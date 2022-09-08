using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class SupplyListViewModel
    {
        public int ClaimBatchNo { get; set; }
        public string BatchStatus { get; set; }
        public int ClaimNo { get; set; }
        public string ClaimStatus { get; set; }
        public string ClaimType { get; set; }
        public int MemberNo { get; set; }
        public string Name { get; set; }
        public int ProviderID { get; set; }
        public DateTime ClaimIncurredDate { get; set; }
        public string VisitType { get; set; }
        public string ServiceType { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceCode { get; set; }
        public int Quantity { get; set; }
        public decimal Amtclaimed { get; set; }
        public decimal AmtRejected { get; set; }
        public string ReasonforRejection { get; set; }
        public decimal PaidAmt { get; set; }
        public string SBU { get; set; }
        public string ReportFrom { get; set; }
        public string ReportTo { get; set; }
        public string Provider { get; set; }
        public string ProviderType { get; set; }
        public string PlanType { get; set; }
    }
}
