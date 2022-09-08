using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public partial class HospitalImage : BaseEntity
    {
        public Guid HospitalImageId { get; set; }

        public string HospitalCode { get; set; }

        public string Image { get; set; }

    }

    public partial class ProviderContractualDoc : BaseEntity
    {
        public Guid DocumentId { get; set; }

        public string ProviderCode { get; set; }

        public string DocumentUri { get; set; }

    }
}
