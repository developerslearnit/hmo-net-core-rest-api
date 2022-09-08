using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public partial class RiskAssessmentRequest : BaseEntity
    {
        public Guid RiskAssessmentRequestId { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public string DrinkingFrequency { get; set; }

        public bool IsSmoker { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

    }
}
