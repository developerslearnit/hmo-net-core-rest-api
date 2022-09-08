using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.EnrolleFlow
{

    public class EnrolleeRecommendationViewModel
    {
        public Guid EnrolleeRecommendationId { get; set; }
        public string BeneficairyId { get; set; }
        public string RecommendationCategory { get; set; }
        public string BeneficairyName { get; set; }
        public string Recommendation { get; set; }
        public DateTime DateCreated { get; set; }
        public string MemberNo { get; set; }

    }
    
    
    public class EnrolleeRecommendationRequestModel
    {
        [Required]
        public string RecommendationCategory { get; set; }
        public string BeneficairyName { get; set; }
        public string BeneficairyId { get; set; }
       
        [Required]
        public string Recommendation { get; set; }

    }
}
