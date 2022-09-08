using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public partial class PartnerProvider : BaseEntity
    {
        public Guid PartnerProviderId { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string Title { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string LocalGovtArea { get; set; }
        public string ProviderName { get; set; }

    }
}
