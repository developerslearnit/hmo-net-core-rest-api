using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Enrollee
{
    public class PaymentRequestModel
    {
        [Required]
        public int productId { get; set; }
        [Required]
        public decimal amount { get; set; }
        public decimal nhis { get; set; }
        public decimal TotalAmount { get { return amount + nhis; } }
        public string paymentMethod { get; set; }
        public string transactionReference { get; set; }
    }

    public class PaymentResponseModel
    {
        public string paymentReference { get; set; }
        public string transactionReference { get; set; }
    }
    public class PaymentRepoResponseModel
    {
        public bool hasError { get; set; }
        public string PaymentReference { get; set; }

    }
}
