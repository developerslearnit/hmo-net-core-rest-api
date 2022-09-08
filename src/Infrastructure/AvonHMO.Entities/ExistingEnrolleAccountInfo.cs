using System;

namespace AvonHMO.Entities
{
    public partial class ExistingEnrolleAccountInfo
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string MemberNo { get; set; }

        public string Password { get; set; }

        public bool IsAvonStaff { get; set; }

        public DateTime DateCreated { get; set; }

        public bool EmailSent { get; set; }
    }
}
