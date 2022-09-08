using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{

    public class RequestQuote : BaseEntity
    {
        public Guid RequestQuoteId { get; set; }
        public string Name { get; set; }
        public string CategoryCode { get; set; }
        public string PlanName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string ContactRole { get; set; }
        public int NoToEnrollee { get; set; }
        public bool CompanyAndLargeAssociation { get; set; }
        public bool InternationalHealthPlan { get; set; }
        public string RequestStatus { get; set; }
        public DateTime? RequestDate { get; set; }

    }
}
