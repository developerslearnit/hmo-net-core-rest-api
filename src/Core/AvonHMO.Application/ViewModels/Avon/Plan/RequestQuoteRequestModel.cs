using System;
using System.ComponentModel.DataAnnotations;

namespace AvonHMO.Application.ViewModels.Avon.Plan
{


    public class RequestQuoteRequestModel
    {
        [Required]
        public string Name { get; set; }
      
        [Required]
        public string PlanName { get; set; }

        [Required]
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string ContactRole { get; set; }
        [Required]
        public int NoToEnrollee { get; set; }
        public bool CompanyAndLargeAssociation { get; set; } = false;
        public bool InternationalHealthPlan { get; set; } = false;
    }


}
