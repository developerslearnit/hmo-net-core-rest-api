using System;

namespace AvonHMO.Entities
{
    public partial class EnrolleeComplaintAdminResponse : BaseEntity
    {
        public Guid EnrolleeComplaintAdminId { get; set; }

        public Guid EnrolleeComplaintId { get; set; }

        public string AdminResponse { get; set; }


    }
}
