using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Explore
{
    public class FeedbackViewModel
    {

        public Guid EnrolleeFeedbackId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
    
    
    public class FeedbackRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
    
    public class CompliantRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        

    }
    public class CompliantViewModel
    {

        public Guid EnrolleeComplaintId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string Plan { get; set; }
        public string MemberNo { get; set; }
        public DateTime CreatedDate { get; set; }



        public class CompliantUpdateViewModel
        {
            [Required]
            public Guid EnrolleeComplaintId { get; set; }
            [Required]
            public string Status { get; set; }

        }

        public class CompliantAdminRequestModel
        {
            [Required]
            public Guid enrolleeComplaintId { get; set; }
            [Required]
            public string adminResponse { get; set; }

        }
        public class CompliantAdminViewModel
        {
            public Guid enrolleeComplaintId { get; set; }
            public Guid EnrolleeComplaintAdminId { get; set; }
            public string adminResponse { get; set; }
            public DateTime? dateCreated { get; set; }

        }
    }
}
