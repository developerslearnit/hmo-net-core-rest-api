using System;

namespace AvonHMO.Entities
{
    public partial class PasswordChangeHistory
    {
        public Guid PasswordChangeHistoryId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
