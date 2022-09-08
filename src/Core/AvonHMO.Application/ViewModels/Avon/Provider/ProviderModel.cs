using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.API.Models.Providers
{

    public class ProviderModel
    {
        [Required]
        public Guid ProviderID { get; set; }
        public int Code { get; set; }
         [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
         [Required]
        public string Address { get; set; }
        public string LGA { get; set; }
         [Required]
        public string State { get; set; }
        public string City { get; set; }
        public string MDName { get; set; }
        public string MDPhoneNo { get; set; }
        public string MDEmail { get; set; }
        public string MDDirectLine { get; set; }
         [Required]
        public string Email { get; set; }
         [Required]
        public string Phoneno { get; set; }
        public string HMOOfficerName { get; set; }
        public string HMODeskPhoneNo { get; set; }
        public string HMOOfficerEmail { get; set; }
        public string ProviderServiceType { get; set; }
        public int ProviderOperationHour { get; set; }
        public int ProviderOperationDay { get; set; }
        public int DoctorCoverageHour { get; set; }
        public string Bankname { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string SortCode { get; set; }
        public string ImageUrl { get; set; }

    }
   
    
    
    public class ProvidersRepoDTO
    {
        public int code { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string mdName { get; set; }
        public string mdPhoneNo { get; set; }        
        public string mdEmail { get; set; }
        public string mdDirectLine { get; set; }
        //End tab 1 - Hospital Details


        public string email { get; set; }
        public string hmoDeskPhoneNo { get; set; }
        public string hmoOfficerName { get; set; }
        public string hmoOfficerGSM { get; set; }
        public string providerServiceType { get; set; }
        public string providerOperationHour { get; set; }
        public string providerOperationDay { get; set; }
        public string doctorCoverageHour { get; set; }
        //End tab 2 - Contact Details

        public string lga { get; set; }
        public string state { get; set; }
        public string city { get; set; }        
       
       
       
        public string bankname { get; set; }
        public string accountNo { get; set; }
        public string accountName { get; set; }
        public string sortCode { get; set; }
        public string imageUrl { get; set; }

        public List<ProviderOtherContacts> otherContacts { get; set; }

    }

    public class ProviderOtherContacts
    {
        public Guid ProviderID { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNo { get; set; }
        public string ContactDesignation { get; set; }
    }

    public class ProviderContactViewModel
    {
        public Guid ProviderContactID { get; set; }
        public Guid ProviderID { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNo { get; set; }
        public string ContactDesignation { get; set; }
    }
    public class ProviderContactRequestModel
    {
        public string contactName { get; set; }
        public string contactEmail { get; set; }
        public string contactPhoneNo { get; set; }
        public string contactDesignation { get; set; }
    }

}
