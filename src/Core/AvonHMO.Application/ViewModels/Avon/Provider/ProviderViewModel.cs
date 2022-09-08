using AvonHMO.API.Models.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Provider
{
    public class ProviderViewModels
    {
        //public int code { get; set; }
        public string providerName { get; set; }
        public string providerAddress { get; set; }
        public string mdName { get; set; }
        public string mdPhoneNo { get; set; }
        public string mdEmail { get; set; }
        public string mdDirectLine { get; set; }
        //End tab 1 - Hospital Details


        public string hmoContactDetailsEmail { get; set; }
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
       // public string imageUrl { get; set; }

        public List<ProviderOtherContactsVM> otherContacts { get; set; }
    }

    public class ProviderOtherContactsVM
    {
        public Guid providerId { get; set; }
        public string contactName { get; set; }
        public string contactEmail { get; set; }
        public string contactPhoneNo { get; set; }
        public string contactDesignation { get; set; }
    }
}
