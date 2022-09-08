using System;

namespace AvonHMO.Entities
{
    public partial class LoginToken
    {
        public Guid LoginTokenId { get; set; }

        public string Username { get; set; }

        public string AuthToken { get; set; }

        public DateTime ExpiryDate { get; set; }

    }
}
