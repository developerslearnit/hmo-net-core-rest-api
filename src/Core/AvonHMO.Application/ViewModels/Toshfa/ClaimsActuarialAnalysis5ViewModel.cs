using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class ClaimsActuarialAnalysis5ViewModel
    {
        public int ClaimNo { get; set; }
        public int ClaimBatchNo { get; set; }
        public string StateOfClaimsOrigin { get; set; }
        public int EnroleesNo { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public DateTime PolicyStartdate { get; set; }
        public DateTime PolicyEnddate { get; set; }
        public string Plans { get; set; }
        public string PremiumType { get; set; }
        public string TypeOfPlan { get; set; }
        public string SbuUnit { get; set; }
        public int Sbucode { get; set; }
        public string DateOfClaimsNotification { get; set; }
        public string DateCareWasAccessed { get; set; }
        public string ClaimApproved { get; set; }
        public string DateOfClaimsPayment { get; set; }
        public string Controls { get; set; }
        public string EmailAddressOfPrincipal { get; set; }
        public int Age { get; set; }
        public string AgeBrackets { get; set; }
        public string Gender { get; set; }
        public string HospNo { get; set; }
        public string ClaimType { get; set; }
        public string HospAccNo { get; set; }
        public string TreatmentProcedure { get; set; }
        public decimal BillAmount { get; set; }
        public decimal ReviwAmout { get; set; }
        public decimal TotalAmount { get; set; }
        public string ClaimsSubmitted { get; set; }
        public string Remarks { get; set; }
        public string InOutPatient { get; set; }
        public int DaysInAdmission { get; set; }
        public string PreExistingCondition { get; set; }
        public string PACode { get; set; }
        public string Relation { get; set; }
        public string PlanType { get; set; }

    }
}
