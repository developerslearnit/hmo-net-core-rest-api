using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public partial class PlanCategory
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string CategoryName { get; set; }
    }
}
