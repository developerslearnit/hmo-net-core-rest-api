using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class ApprovalRequestServiceWiseDetailedViewModel
    {
        public int RequestNo { get; set; }
        public string AvonPaCode { get; set; }
        public string RequestType { get; set; }
        public string MemberName { get; set; }
        public int MemberNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string AVONMemberNo { get; set; }
        public DateTime DOB { get; set; }
        public string Sex { get; set; }
        public string MobileNo { get; set; }
        public string MemberType { get; set; }
        public string Relation { get; set; }
        public int PolicyNo { get; set; }
        public string Client { get; set; }
        public DateTime Fromdate { get; set; }
        public int PlanCode { get; set; }
        public string PlanName { get; set; }
        public string PremiumType { get; set; }
        public string Hospital { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }
        public int ProviderNo { get; set; }
        public string Address { get; set; }
        public string ApprovalType { get; set; }
        public DateTime Receiveddate { get; set; }
        public DateTime ReceivedTime { get; set; }
        public DateTime DecisionDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ApprovalStatus { get; set; }
        public string Benefits { get; set; }
        public string OpdIpd { get; set; }
        public string SBU { get; set; }
        public string CaseManager { get; set; }
        public string Speciality { get; set; }
        public string ProviderManager { get; set; }
        public string ApproveRejectCloseNotes { get; set; }
        public string TAT { get; set; }
        public string servicetype { get; set; } 
        public string ProviderManagerRemarks { get; set; } 
        public string ServiceDescription { get; set; }  
        public int NoOfUnits { get; set; }      
        public decimal UnitCost { get; set; }     
        public decimal ToshfaAmount { get; set; }           
        public decimal NegotiatedAmt { get; set; }       
        public decimal ModifiedAmount { get; set; }     
        public string Diagnosis { get; set; }       
        public string DecisionBy { get; set; }    
        public string PAIssuedBy { get; set; }   
        public string Notes { get; set; }         
        public string MissingServiceRemarks { get; set; }     
        public string PrimaryCareProvider { get; set; }  

        public string PARequired { get; set; }        
        public string CaseUtilizationManager { get; set; } 
        public string ReasonForPending { get; set; }  
        
        public string NewApprovalStatus { get; set; }  
        
        public decimal FinalPAAmount { get; set; }
    }
}
