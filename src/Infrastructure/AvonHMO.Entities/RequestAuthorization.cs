using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{

    public class RequestAuthorization : BaseEntity
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
        public string PACode { get; set; }
    }
}
