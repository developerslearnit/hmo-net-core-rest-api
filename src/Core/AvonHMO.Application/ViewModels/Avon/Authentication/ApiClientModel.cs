using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Authentication
{
    public class ApiClientModel
    {
        public Guid clientId { get; set; }

        public string clientName { get; set; }

        public string apiKey { get; set; }

        public int isActive { get; set; }
    }
}
