using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.ViewModels
{
    public class EnrolleeViewModelDTO
    {
        public Guid enrolleeId { get; set; }
        public Guid enrolleeAccountId { get; set; }
        public int? memberNumber { get; set; }
        public string middleName { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? providerId { get; set; }
        public Guid clientId { get; set; }
        public int productId { get; set; }
      
    }
}
