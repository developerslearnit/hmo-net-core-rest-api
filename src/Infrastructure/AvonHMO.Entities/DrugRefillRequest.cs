using System;

namespace AvonHMO.Entities
{
    public partial class DrugRefillRequest : BaseEntity
    {

        public Guid DrugRefillRequestId { get; set; }
        public Guid EnrolleeId { get; set; }
        public string MemberNo { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string DeliverAddress { get; set; }
        public string PrescriptionePath { get; set; }
        public string RequestStatus { get; set; }
        public bool RequestState { get; set; } = false;
        public bool MonthlyRefill { get; set; } = false;
        public DateTime RequestDate { get; set; }
    }
}
