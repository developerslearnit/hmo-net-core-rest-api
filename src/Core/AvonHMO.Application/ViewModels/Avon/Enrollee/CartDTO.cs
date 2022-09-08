using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Enrollee
{
    public class CartDTO
    {
        [Required]
        public int productId { get; set; }
        [Required]
        public int price { get; set; }

        [Required]
        public int quantity { get; set; }

        /// <summary>
        /// UniqueReference to uniquely identify cart user: value can be: username, userEmail, enrolleeId, memberNo or any uniqueRef
        /// </summary>
        [Required]
        public string UniqueReference { get; set; }
    }
    public class CartPayLoadDTO:CartDTO
    {
        [Required]
        public Guid cartId { get; set; }
    }

    public class CartViewModel
    {
        public Guid cartId { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public int price { get; set; }
        public decimal amount { get { return price * quantity; } }
        public int quantity { get; set; }
        public string uniqueReference { get; set; }
        public DateTime dateCreated { get; set; }
    }
}
