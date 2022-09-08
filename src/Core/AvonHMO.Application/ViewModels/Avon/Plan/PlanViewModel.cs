using System;

namespace AvonHMO.Application.ViewModels.Avon.Plan
{


    public class PlanViewModel
    {
        public Guid id { get; set; }

        public Guid planTypeId { get; set; }

        public int code { get; set; }
        public string planName { get; set; }
        public string planClass { get; set; }
        public decimal premium { get; set; }
        public string color { get; set; }
        public int planCategoryCode { get; set; }
        public string icon { get; set; }
    }


}
