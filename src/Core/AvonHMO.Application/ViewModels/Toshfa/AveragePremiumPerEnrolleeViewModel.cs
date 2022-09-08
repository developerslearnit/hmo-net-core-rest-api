using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class AveragePremiumPerEnrolleeViewModel
    {                                                   
        public string ClientName { get; set; }           
        public string PolicyNo { get; set; }             
        public string FromDate { get; set; }              
        public string MemberNo { get; set; }             
        public string MemberHeadNo { get; set; }        
        public string EnrollmentDate { get; set; }       
        public string Name { get; set; }               
        public string PlanType { get; set; }            
        public string PlanTypeCategory { get; set; }     
        public string PaidDate { get; set; }            
        public string SBU { get; set; }                 
        public string AgentId { get; set; }              
        public string AgentName { get; set; }


    }
}
