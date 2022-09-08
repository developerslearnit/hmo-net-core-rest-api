using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public class SubscriptionHistory
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public int  PlanId { get; set; }

        public decimal  AmountPaid { get; set; }
        public string  PaymentMethod { get; set; }
        public string  OrderReference { get; set; }
        public string  PaymentReference { get; set; }
        public string Email { get; set; }
        public string Platform { get; set; }
        public string Type { get; set; }
        public string userId { get; set; }
        public string EnrolleeName { get; set; }
    }
}
