using System;

namespace AvonHMO.Application.ViewModels.Avon.Plan
{


    public class RequestQuoteModel
    {
        public Guid RequestQuoteId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string ContactRole { get; set; }
        public int NoToEnrollee { get; set; }
        public bool CompanyAndLargeAssociation { get; set; } = false;
        public bool InternationalHealthPlan { get; set; } = false;
        public string RequestStatus { get; set; }
        public DateTime? RequestDate { get; set; }
      
    }


}
