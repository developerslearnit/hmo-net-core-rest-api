using System.ComponentModel.DataAnnotations;

namespace AvonHMO.API.Areas.Payments.Models
{
    public class PaystackInitModel
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string callback_url { get; set; }
        [Required]
        public decimal amount { get; set; }
        [Required]
        public string customer_name { get; set; }
    }

    public class PaystackInitResponseModel
    {
        public string authorization_url { get; set; }

        public string reference { get; set; }

        public string access_code { get; set; }
    }
}
