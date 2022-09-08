using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public class CycleInfo
    {
        public Guid CycleId { get; set; }
        public Guid CyclePlannerCategoryId { get; set; }
        public Guid AppuserId { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime DateCreated { get; set; }
        public int PeriodDuration { get; set; }
        public int PeriodCycle { get; set; }
    }
}
