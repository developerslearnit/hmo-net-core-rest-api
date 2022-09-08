using System.ComponentModel.DataAnnotations;

namespace AvonHMO.Application.ViewModels.Avon.Post
{
    public class ProspectViewModel
    {
        [Required]
        public string readersName { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string phoneNumber { get; set; }
    }
}
