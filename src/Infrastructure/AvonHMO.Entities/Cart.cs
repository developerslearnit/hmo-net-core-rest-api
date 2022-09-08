using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public class Cart
    {
        public Guid CartId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public string UniqueReference { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
