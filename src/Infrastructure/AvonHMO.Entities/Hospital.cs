using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public partial class Hospital : BaseEntity
    {
        public Guid HospitalId { get; set; }

        public string HospitalCode { get; set; }

        public string HospitalName { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public string ShortName { get; set; }

        public string Logo { get; set; }

        public string Notes { get; set; }

        public string Website { get; set; }

    }
}
