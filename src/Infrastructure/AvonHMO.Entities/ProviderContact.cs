using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public partial class ProviderContact
    {
        public Guid ProviderContactID { get; set; }
        public Guid ProviderID { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNo { get; set; }
        public string ContactDesignation { get; set; }
    }
}
