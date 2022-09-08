using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{

    public class Claim : BaseEntity
    {
        public Guid ClaimId { get; set; }
        public string Name { get; set; }
        public string PreAuthorizationCode { get; set; }
        public string PlanName { get; set; }
        public string Gender { get; set; }
        public string Diagnosis { get; set; }
        public string Services { get; set; }
        public DateTime? EncounterDate { get; set; }
        public decimal Amount { get; set; }
        public int DrugQuantity { get; set; }
        public string Notes { get; set; }
        public string CloseReason { get; set; }
        public bool CloseClaim { get; set; }
        public string RequestStatus { get; set; }
     

    }
}
