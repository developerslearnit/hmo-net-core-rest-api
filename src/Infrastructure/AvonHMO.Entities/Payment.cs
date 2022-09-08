using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public class Payment
    {
        public Guid PaymentId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
        public decimal NHIS { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentReference { get; set; }
        public string TransactionReference { get; set; }
    }
}
