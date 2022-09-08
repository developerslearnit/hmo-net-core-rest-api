using System;

namespace AvonHMO.Entities
{
    public partial class HCPManagerRequest
    {
        public Guid RequestId { get; set; }

        public string ManagerCode { get; set; }

        public string ManagerName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RequestDate { get; set; }

        public string Status { get; set; }
    }
}
