using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Authentication
{
    public class HospitalReviewViewModel
    {

        public string ReviewerName { get; set; }
        public int MemberNumber { get; set; }
        public Guid EnrolleeId { get; set; }
        public Guid HospitalReviewId { get; set; }

        public string HospitalCode { get; set; }
        public string Occupation { get; set; }

        public decimal Rating { get; set; }
        public DateTime DateCreated { get; set; }
        public string Review { get; set; }

    }
    
    
    public class HospitalReviewRequestModel
    {

        public string HospitalCode { get; set; }
        public string Occupation { get; set; }

        public decimal Rating { get; set; } 
        [Required]
        public string Review { get; set; }

    }



    public class ProviderRatingViewModel
    {

        public string ReviewerName { get; set; }
        public Guid EnrolleeAccountId { get; set; }
        public Guid HospitalRatingId { get; set; }
        public int ProviderId { get; set; }
        public string Occupation { get; set; }

        public decimal Rating { get; set; }
        public DateTime DateCreated { get; set; }
        public string Review { get; set; }
        public decimal EasyAccessingCare { get; set; }
        public decimal SatisfactoryLevel { get; set; }

    }

    public class ProviderRatingRequestModel
    {

        public int ProviderId { get; set; }
        public decimal Rating { get; set; } 
        public decimal EasyAccessingCare { get; set; } 
        public decimal SatisfactoryLevel { get; set; } 
        public string Review { get; set; }

    }
}
