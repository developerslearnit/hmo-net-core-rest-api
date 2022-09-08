using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public class Order:BaseEntity
    {
        public Guid OrderId { get; set; }
        public string OrderReference { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? Amount { get; set; }
        public decimal? NHISAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public int ProductId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentReference { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public Guid ClientId { get; set; }
        public string PicturePath { get; set; }
        public string SyncStatus { get; set; }
        public int? IsSponsored { get; set; }
        public string sponsoredEmail { get; set; }


    }
}
