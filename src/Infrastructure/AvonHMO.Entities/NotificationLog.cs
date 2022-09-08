using System;

namespace AvonHMO.Entities
{
    public partial class NotificationLog
    {
        public Guid Id { get; set; }

        public string OwnerId { get; set; }

        public string body { get; set; }

        public string Subject { get; set; }

        public int Status { get; set; }

        public DateTime DateSent { get; set; }
    }
}
