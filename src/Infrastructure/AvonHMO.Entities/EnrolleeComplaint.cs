using System;

namespace AvonHMO.Entities
{
    public partial class EnrolleeComplaint : BaseEntity
    {
        public Guid EnrolleeComplaintId { get; set; }

        public string Name { get; set; }
        public Guid EnrolleeId { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string ComplaintStatus { get; set; }
        public string Plan { get; set; }
        public int? MemberNo { get; set; }


    }
}
