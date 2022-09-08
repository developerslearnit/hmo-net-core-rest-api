using System;

namespace AvonHMO.Entities
{
    public partial class EnrolleeReferalCode
    {
        public Guid EnrolleeReferalCodeId { get; set; }

        public string ReferalCode { get; set; }

        public Guid EnrolleeId { get; set; }

        public int? MemberNo { get; set; }
    }
}
