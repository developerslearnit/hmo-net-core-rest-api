using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.EnrolleFlow
{

    public class ReferralRequestViewModel
    {
        public Guid ReferralRequestId { get; set; }
        public string BeneficiaryName { get; set; }
        public Guid EnrolleeId { get; set; }
        public string Reason { get; set; }
        public string ReferralDate { get; set; }
        public DateTime DateCreated { get; set; }
        
        public string ReferralTime { get; set; }
        public string MedicalSummary { get; set; }
        public string MedicalDocPath { get; set; }
        public int? MemberNo { get; set; }
        public string ReferralStatus { get; set; }

    }
    
    public class ReferralRequestRequestModel
    {
        public Guid ReferralRequestId { get; set; }
        public string BeneficiaryName { get; set; }
        public Guid EnrolleeId { get; set; }
        public string Reason { get; set; }
        public string ReferralDate { get; set; }
       
        public string ReferralTime { get; set; }
        public string MedicalSummary { get; set; }
        public string MedicalDocPath { get; set; }
       // public int? MemberNo { get; set; }


    }
}
