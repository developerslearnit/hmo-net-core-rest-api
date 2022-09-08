using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class ApprovalReqUtilizationPendingDetailsViewModel
    {
        public int RequestNo { get; set; }                  
        public string AvonPaCode { get; set; }                 
        public string RequestType { get; set; }                
        public string Name { get; set; }                       
        public string Client { get; set; }                      
        public string Hospital { get; set; }                    
        public string RefHospName { get; set; }                 
        public string Type { get; set; }                        
        public string OpdIpd { get; set; }                       
        public DateTime RequestDate { get; set; }                  
        public DateTime DecisionDate { get; set; }                 
        public string Notes { get; set; }                        
        public string ProviderUtilizationManager { get; set; }   
        public string Remarks { get; set; }                     
        public string ApprovalStatus { get; set; }              
        public string Utilizationmanager { get; set; }        
        public string caseManager { get; set; }
        public string Emanagertype { get; set; }

    }
}
