using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.ViewModels
{
    public class CompletePlanSubscriptionDto
    {
        [Required]
        public decimal Amount { get; set; } 
        public decimal NHISAmount { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public int ProductId { get; set; }
        public string PaymentReference { get; set; }

        public string PaymentMethod { get; set; }
        [Required]
        public string OrderReference { get; set; }

        public string UpdatedBy { get; set; }

    }

    public class CompletePlanRenewalRes
    {
        public bool hasError { get; set; } = false;
        public string email { get; set; } 
        public string firstName { get; set; } 
        public string lastName { get; set; } 
    }
    public class CompletePlanRenewal
    {
        [Required]
        public decimal Amount { get; set; }
        public decimal NHISAmount { get; set; }
        [Required]
        public string PaymentReference { get; set; }
        [Required]
        public int NewPlanId { get; set; }
        public Guid enrolleeId { get; set; }
    }
    public class CompletePlanPayment
    {
        [Required]
        public decimal Amount { get; set; }
        public decimal NHISAmount { get; set; }
        [Required]
        public string OrderPaymentRefrence { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionReference { get; set; }
        [Required]
        public int ProductId { get; set; }
    }

    public class CompletePlanSubscriptionResponseDTO
    {
        public bool hasError { get; set; }
        public int productId { get; set; }
        public Guid orderId { get; set; }
        public string orderReference { get; set; }
        public string email { get; set; }
        public string paymentReference { get; set; }
        public Guid enrolleeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool createAcct { get; set; }
    }

   
}
