using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Plan
{
    public class EnrolleeProviderViewModel
    {
        [Required]
        public Guid enrolleeId { get; set; }

        [Required]
        public int providerCode { get; set; }
    }
}
