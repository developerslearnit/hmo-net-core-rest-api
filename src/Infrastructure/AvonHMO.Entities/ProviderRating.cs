using System;

namespace AvonHMO.Entities
{
    public partial class ProviderRating : BaseEntity
    {
        public Guid HospitalRatingId { get; set; }
        public string ReviewerName { get; set; }
        public string ProviderName { get; set; }
        public Guid EnrolleeAccountId { get; set; }
        public int ProviderId { get; set; }
        public string Occupation { get; set; }
        public decimal Rating { get; set; }
        public string Review { get; set; }
        public decimal EasyAccessingCare { get; set; }
        public decimal SatisfactoryLevel { get; set; }
    }
}
