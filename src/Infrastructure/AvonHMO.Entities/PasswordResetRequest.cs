using System;

namespace AvonHMO.Entities
{
    public partial class PasswordResetRequest
    {
        public Guid ResetRequestId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Email { get; set; }
        public bool IsUsed { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
