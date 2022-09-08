using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class ClaimsInformationViewModel
    {
        public string ClientName { get; set; }
        public int PolicyNo { get; set; }
        public string PolicyInception { get; set; }
        public int MemberNo { get; set; }
        public string MemberHeadNo { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Name { get; set; }
        public DateTime Fromdate { get; set; }
        public string PlanType { get; set; }
        public string PlanTypeCategory { get; set; }
        public string StateOfClaimsOrigin { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public decimal PAIDAMOUNT { get; set; }
        public string ClaimNo { get; set; }
        public decimal PolicyStartDate { get; set; }
        public decimal PolicyEndDate { get; set; }
        public decimal ClaimIncurredDate { get; set; }
        public decimal ClaimReceivedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DateOfClaimsPayment { get; set; }
        public int HOSPNO { get; set; }
        public string HospitalName { get; set; }
        public string SBU { get; set; }
        public string PolicyYear { get; set; }
        public int PaymentYear { get; set; }
        public int AccidentYear { get; set; }
        public string ReasonForVisitToTheHospital { get; set; }
        public string DiagnosedAilment { get; set; }

    }
}
