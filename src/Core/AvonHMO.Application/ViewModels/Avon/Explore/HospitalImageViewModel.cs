using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Authentication
{
    public class HospitalImageViewModel
    {
        public Guid HospitalImageId { get; set; }
        [Required]
        public string HospitalCode { get; set; }
        [Required]
        public string Image { get; set; }

    }
    
    public class HospitalImageRequestModel
    {
        [Required]
        public string HospitalCode { get; set; }
        [Required]
        public string Image { get; set; }

    }
}
