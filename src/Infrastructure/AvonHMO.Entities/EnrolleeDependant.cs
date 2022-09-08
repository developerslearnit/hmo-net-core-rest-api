using System;
using System.Globalization;

namespace AvonHMO.Entities
{
    public partial class EnrolleeDependant
    {

        public Guid EnrolleeDependantId { get; set; }
        public Guid EnrolleeId { get; set; }
        public int? MemberNo { get; set; }
        public int? HeadmemberNo { get; set; }
        public string  HeadMemberEmail { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PicturePath { get; set; }
        public string Relationship { get; set; }
        public string RelationshipId { get; set; }
        public string Status { get; set; }
        public bool Deleted { get; set; } = false;

    }
}
