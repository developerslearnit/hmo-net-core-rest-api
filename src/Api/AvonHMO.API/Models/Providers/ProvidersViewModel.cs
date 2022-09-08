using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.API.Models.Providers
{

    public class ProvidersViewModel
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



    public class ProvidersDTO
    {
        public int code { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string address { get; set; }
        public string lga { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string mdName { get; set; }
        public string mdPhoneNo { get; set; }
        public string mdEmail { get; set; }
        public string mdDirectLine { get; set; }
        public string email { get; set; }
        public string phoneno { get; set; }
        public string hmoOfficerName { get; set; }
        public string hmoDeskPhoneNo { get; set; }
        public string hmoOfficerEmail { get; set; }
        public string providerServiceType { get; set; }
        public int providerOperationHour { get; set; }
        public int providerOperationDay { get; set; }
        public int doctorCoverageHour { get; set; }
        public string bankname { get; set; }
        public string accountNo { get; set; }
        public string accountName { get; set; }
        public string sortCode { get; set; }
        public IFormFile file { get; set; }
        public string imageUrl { get; set; }

       // public List<ProviderContactRequestModel> providerContacts { get; set; }

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


    public class ToshfaProviderViewModel
    {
        public string Code { get; set; }
        public string AvonHMOProviderNo { get; set; }
        public string ProviderName { get; set; }
        public string ContactName { get; set; }
        public string ServiceType { get; set; }
        public string ProviderCategory { get; set; }
        public string ProviderManager { get; set; }
        public string Providertype { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string LocalGovernmentArea { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string Currency { get; set; }
        public string TariffCode { get; set; }
        public string Logo { get; set; }
        public string UserId { get; set; }
        public int AvonHMOId { get; set; }
    }


}
