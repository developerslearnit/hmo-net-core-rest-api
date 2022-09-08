using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public partial class Client : BaseEntity
    {
        public Guid ClientId { get; set; }

        public string ClientNumber { get; set; }

        public string GroupId { get; set; }

        public string ClientName { get; set; }

        public string Email { get; set; }

        public string GroupIndustryType { get; set; }

        public string ClientIndustryType { get; set; }

        public string Address { get; set; }

        public string ClientManager { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string LocalGovtArea { get; set; }

        public string CommunicationType { get; set; }

        public string PhoneCountryCode { get; set; } //mapped to Extension in Toshfa

        public string CommunicationInformation { get; set; }

        public string ShortName { get; set; }

        public string Logo { get; set; }

        public string Notes { get; set; }

    }
}
