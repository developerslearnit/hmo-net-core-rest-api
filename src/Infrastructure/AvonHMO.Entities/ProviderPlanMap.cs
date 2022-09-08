using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public partial class ProviderPlanMap
    {
        public Guid Id { get; set; }

        public string ProviderClass { get; set; }

        public string Plan { get; set; }


    }
}
