using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public partial class PartnerBroker : BaseEntity
    {
        public Guid PartnerBrokerId { get; set; }

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

        public string CompanyName { get; set; }

        public string Message { get; set; }

    }
}
