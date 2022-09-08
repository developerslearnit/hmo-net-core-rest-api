using System;
using System.ComponentModel.DataAnnotations;

namespace AvonHMO.Application.ViewModels.Avon.Plan
{


    public class ClaimsRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string PreAuthorizationCode { get; set; }
        [Required]
        public string PlanName { get; set; }
        public string Gender { get; set; }
        public int DrugQuantity { get; set; }
        public string Diagnosis { get; set; }
        [Required]
        public string Services { get; set; }
        public DateTime? EncounterDate { get; set; }
       [Required]
        public decimal Amount { get; set; }
        public string Notes { get; set; }

    }
    
    public class ClaimsViewModel
    {
        public Guid ClaimId { get; set; }
        public string Name { get; set; }
        public string PreAuthorizationCode { get; set; }
        public string PlanName { get; set; }
        public string Gender { get; set; }
        public string Diagnosis { get; set; }
        public int DrugQuantity { get; set; }
        public string Services { get; set; }
        public DateTime? EncounterDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public bool CloseClaim { get; set; }
        public string RequestStatus { get; set; }

    }
    
    
    public class ClaimsUpdateViewModel
    {
        [Required]
        public Guid ClaimId { get; set; }
        [Required]
        public string RequestStatus { get; set; }

    }
    
    public class CloseClaimsModel
    {
        [Required]
        public Guid ClaimId { get; set; }
        [Required]
        public string CloseReason { get; set; }

    }


}
