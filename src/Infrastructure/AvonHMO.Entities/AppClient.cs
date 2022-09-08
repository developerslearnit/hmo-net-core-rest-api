using System;

namespace AvonHMO.Entities
{
    public partial class AppClient
    {
        public Guid AppClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientApiKey { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
