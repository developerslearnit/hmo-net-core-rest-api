using System;

namespace AvonHMO.Entities
{
    public partial class HospitalReview : BaseEntity
    {
        public Guid HospitalReviewId { get; set; }
        public Guid EnrolleeId { get; set; }

        public string MemberNumber { get; set; }
        public string HospitalCode { get; set; }

        public string Occupation { get; set; }

        public decimal Rating { get; set; }

        public string Review { get; set; }

    }
}
