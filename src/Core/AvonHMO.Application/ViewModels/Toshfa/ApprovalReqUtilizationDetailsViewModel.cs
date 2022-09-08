using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class ApprovalReqUtilizationDetailsViewModel
    {
        public int RequestNo { get; set; }                
        public string AvonPaCode { get; set; }            
        public string RequestType { get; set; }           
        public string Name { get; set; }                  
        public string Client { get; set; }                 
        public string Planname { get; set; }               
        public string Hospital { get; set; }                
        public string RefHospName { get; set; }             
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
        public string FName { get; set; }                      
        public string DecisionBy { get; set; }                 
        public string MissingTariff { get; set; }             
        public string MobileNo { get; set; }                  
        public decimal ModifiedAmount { get; set; }          
        public decimal ServiceNotFoundAmount { get; set; }    
        public string ServiceNotFoundDescription { get; set; }
        public decimal ApprovedAmt { get; set; }               
        public string Remarks { get; set; }                   
        public string MemberName { get; set; }                
        public string Gender { get; set; }                    
        public string Relation { get; set; }                  
        public int Age { get; set; }                       
        public string Provider { get; set; }                 

        public int Quantity { get; set; }                     
        public DateTime ExpAdmissionDate { get; set; }        
        public DateTime OperationDate { get; set; }            
        public decimal Planpremium { get; set; }              
        public decimal Monthlypremium { get; set; }           
        public decimal Annualpremium { get; set; }           
        public string Avonmemberno { get; set; }             
        public string PaymentBy { get; set; }                  
        public string PaymentTerms { get; set; }

    }
}
