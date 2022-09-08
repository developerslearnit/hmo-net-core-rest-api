using System.ComponentModel.DataAnnotations;

namespace AvonHMO.Application.ViewModels.Avon.Communication
{
    public class ContactUsEmailViewModel
    {

        [Required]
        public string subject { get; set; }

        [Required]
        public string senderEmail { get; set; }

        [Required]
        public string senderName { get; set; }

        [Required]
        public string message { get; set; }
    }
}
