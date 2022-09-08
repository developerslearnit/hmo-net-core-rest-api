using System;

namespace AvonHMO.Entities
{
    public partial class Plan
    {
        public Guid PlanId { get; set; }

        public Guid PlanTypeId { get; set; }

        public int PlanCode { get; set; }

        public string PlanName { get; set; }

        public string PlanClass { get; set; }

        public string SubCategory { get; set; }

        public string Description { get; set; }

        public decimal Premium { get; set; }

        public string PlanColor { get; set; }

        public string PlanIcon { get; set; }

        public string PlanBgImage { get; set; }

        public int SerialNo { get; set; }

        public int PlanCategoryCode { get; set; }

    }
}
