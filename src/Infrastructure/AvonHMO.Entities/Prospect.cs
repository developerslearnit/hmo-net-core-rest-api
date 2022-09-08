using System;

namespace AvonHMO.Entities
{
    public partial class Prospect
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
