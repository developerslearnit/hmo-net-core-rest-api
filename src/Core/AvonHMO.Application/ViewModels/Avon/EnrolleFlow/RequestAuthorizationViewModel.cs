using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.EnrolleFlow
{

    public class RequestAuthorizationViewModel
    {
        public string FirstName { get; set; }
        public int? MemberNo { get; set; }
        public string PhoneNumber { get; set; }
        public string PaCode { get; set; }
        public string Email { get; set; }
        [Required]
        public int? ProviderId { get; set; }
        public string AvonEnrolleId { get; set; }
        public string Reason { get; set; }
    
    }
    
    public class RequestAuthorizationModel
    {
        public Guid RequestAuthorizationId { get; set; }
        public string FirstName { get; set; }
        public Guid EnrolleeId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? ProviderId { get; set; }
        public int? MemberNo { get; set; }
        public string AvonEnrolleId { get; set; }
        public string Reason { get; set; }
        public DateTime? DateCreated { get; set; }

    }
}
