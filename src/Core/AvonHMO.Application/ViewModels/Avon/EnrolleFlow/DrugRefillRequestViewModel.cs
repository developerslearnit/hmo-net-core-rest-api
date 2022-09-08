using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.EnrolleFlow
{

    public class DrugRefillRequestRequestModel
    {

        public string EnrolleeId { get; set; }
        public string MemberNo { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string DeliverAddress { get; set; }
        public string PrescriptionPath { get; set; }
        public int MonthlyRefill { get; set; }
        public string RequestStatus { get; set; }
        public string RequestDate { get; set; }
    }
    
    public class DrugRefillRequestViewModel
    {
        public Guid DrugRefillRequestId { get; set; }
       
        public Guid EnrolleeId { get; set; }

        public Guid userId { get; set; }
     
        public string MemberNo { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string DeliverAddress { get; set; }
        public int MonthlyRefill { get; set; }
        public string PrescriptionPath { get; set; }
        public string RequestStatus { get; set; }
        public bool RequestState { get; set; }
        public string RequestDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class DrugRefillUpdateViewModel
    {
        [Required]
        public Guid DrugRefillRequestId { get; set; }
        [Required]
        public string Status { get; set; }

    }
}
