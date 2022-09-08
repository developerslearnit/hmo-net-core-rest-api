using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public partial class Provider : BaseEntity
    {
        public Guid ProviderID { get; set; }
        public int? ProviderCode { get; set; }
        public string ProviderName { get; set; }
        public string Address { get; set; }
        public string LGA { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string MDName { get; set; }
        public string MDPhoneNo { get; set; }
        public string MDEmail { get; set; }
        public string MDDirectLine { get; set; }
        public string Email { get; set; }
       // public string Phoneno { get; set; }
        public string HMOOfficerName { get; set; }
        public string HMODeskPhoneNo { get; set; }
       // public string HMOOfficerEmail { get; set; }
        public string HMOOfficerGSM { get; set; }
        public string ProviderServiceType { get; set; }
        public string ProviderOperationHour { get; set; }
        public string ProviderOperationDay { get; set; }
        public string DoctorCoverageHour { get; set; }
        public string Bankname { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string SortCode { get; set; }
      //  public string ImageUrl { get; set; }
    }
}
