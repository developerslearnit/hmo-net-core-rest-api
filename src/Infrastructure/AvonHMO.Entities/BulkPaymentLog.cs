using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public class BulkPaymentLog
    {
        public Guid BulkPaymentLogId { get; set; }
        public int NoOfPlans { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentReference { get; set; }
        public string PaymentMethod { get; set; }
       
        public DateTime PaymentDate { get; set; }
    }
}
