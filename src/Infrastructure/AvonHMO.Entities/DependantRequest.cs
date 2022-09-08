using System;

namespace AvonHMO.Entities
{
    public partial class DependantRequest : BaseEntity
    {

        public Guid DependantRequestId { get; set; }
        public Guid EnrolleeId { get; set; }
        public string MemberNo { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PicturePath { get; set; }
        public string RelationshipId { get; set; }
        public string RequestStatus { get; set; }
        public DateTime? RequestDate { get; set; }
        public bool YourPlan { get; set; } = false;
    }
}
