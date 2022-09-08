using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoMemberApprovalDetailsViewModel
    {
        public int RequestNo { get; set; }
        public string AvonPaCode { get; set; }
        public string RequestType { get; set; }
        public string Name { get; set; }
        public int MemberNo { get; set; }
        public string Client { get; set; }  
        public string Hospital { get; set; }  
        public string approvalType { get; set; } 
        public DateTime Receiveddate { get; set; } 
        public DateTime ReceivedTime { get; set; } 
        public DateTime DecisionDate { get; set; } 
        public string ApprovalStatus { get; set; } 
        public string BasicDiagnosis { get; set; } 
        public string OpdIpd { get; set; } 
        public decimal TotalAmount { get; set; }
        public decimal NegotiatedAmt { get; set; } 
        public string SBU { get; set; } 
        public string CaseManager { get; set; } 
        public string Speciality { get; set; } 
        public string ProviderManager { get; set; } 
        public string ApproveRejectCloseNotes { get; set; } 
        public string TAT { get; set; } 
        public string servicetype { get; set; } 
        public string ProviderManagerRemarks { get; set; } 
        public string ServiceDescription { get; set; } 
        public decimal Amount { get; set; } 
        public string Diagnosis { get; set; } 
        public string DecisionBy { get; set; } 
        public string FName { get; set; } 
        public string Notes { get; set; } 
        public decimal DecmodifiedAmount { get; set; } 
        public decimal ServiceNotFoundAmount { get; set; } 
        public decimal ApprovedAmt { get; set; } 
        public string RefHospName { get; set; }
        public string ServiceNotFoundDescription { get; set; } 
        public int Policyno { get; set; } 
        public DateTime fromdate { get; set; } 
    }
}
