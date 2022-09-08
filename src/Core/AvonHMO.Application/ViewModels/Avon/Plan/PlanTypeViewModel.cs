using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Plan
{
    public class PlanTypeViewModel
    {
        public Guid id { get; set; }

        public string planTypeName { get; set; }

        public string description { get; set; }

        public string planClass { get; set; }

        public string color { get; set; }

        public string icon { get; set; }

        public string bgImage { get; set; }

        public bool requiredQuoteRequest { get; set; }
    }
}
