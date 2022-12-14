using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Authentication
{
    public class PartnerProviderViewModel
    {
        [Required]
        public string Surname { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string Title { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }
        [Required]
        public string City { get; set; }

        public string LocalGovtArea { get; set; }
        public string ProviderName { get; set; }
    }


    public class PartnerProviderModel
    {
        public Guid PartnerProviderId { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }

        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }
        public string City { get; set; }

        public string LocalGovtArea { get; set; }
        public string ProviderName { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
