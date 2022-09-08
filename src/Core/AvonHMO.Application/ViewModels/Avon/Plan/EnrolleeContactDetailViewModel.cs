using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Plan
{
    public class EnrolleeContactDetailViewModel
    {
        [Required]
        public Guid enrolleeId { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string residentAddress { get; set; }
        public string state { get; set; }
        public string lga { get; set; }
        public string mailingAddress { get; set; }
    }
}
