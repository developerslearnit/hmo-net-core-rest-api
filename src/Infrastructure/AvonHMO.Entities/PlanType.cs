using System;

namespace AvonHMO.Entities
{
    public partial class PlanType
    {
        public Guid PlanTypeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PlanColor { get; set; }

        public string PlanIcon { get; set; }

        public string PlanBgImage { get; set; }

        public int SerialNo { get; set; }
    }
}
