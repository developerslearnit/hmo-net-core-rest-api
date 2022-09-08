using System;

namespace AvonHMO.Entities
{
    public partial class EnrolleeFeedback : BaseEntity
    {
        public Guid EnrolleeFeedbackId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }


    }
}
