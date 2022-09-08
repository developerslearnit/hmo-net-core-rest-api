using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoMissingServicesDetailsApprovalViewModel
    {
        public int RequestNo { get; set; }

        public int ProviderNo { get; set; }

        public string ProviderName { get; set; }

        public string AvonPaCode { get; set; }

        public DateTime ReceivedDate { get; set; }

        public DateTime ApprovalDate { get; set; }

        public string OPDIPD { get; set; }

        public string ClaimStatus { get; set; }

        public int PolicyNo { get; set; }

        public DateTime FromDate { get; set; }

        public int MemberNo { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string SurName { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string Relation { get; set; }

        public string MobileNo { get; set; }

        public string AvonMemberNo { get; set; }

        public int ClassCode { get; set; }

        public string PlanName { get; set; }

        public string PremiumType { get; set; }

        public string ProviderManager { get; set; }

        public int PrimaryHospNo { get; set; }

        public string ApprovalType { get; set; }

        public string Benefits { get; set; }

        public string Diagnosis { get; set; }

        public string Case_UtilizationManager { get; set; }

        public string ServiceType { get; set; }

        public string Speciality { get; set; }

        public string LGA { get; set; }

        public string ApproveRejectCloseNotes { get; set; }

        public string ProviderManagerRemarks { get; set; }

        public string PrimaryCareProvider { get; set; }

        public string PARequired { get; set; }

        public int NoOfUnits { get; set; }

        public decimal UnitCost { get; set; }

        public string SBUName { get; set; }

        public decimal TotalToshfaAmount { get; set; }

        public decimal NegotiatedAmount { get; set; }

        public decimal ModifiedAmount { get; set; }

        public string ServiceNotFoundDescription { get; set; }

        public decimal ServiceNotFoundAmount { get; set; }

        public decimal PAApprovalAmount { get; set; }

        public string MissingServiceRemarks { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string ClientName { get; set; }

        public string PAIssuedBy { get; set; }

        public string DecisionBy { get; set; }

        public string Notes { get; set; }
    }
}
