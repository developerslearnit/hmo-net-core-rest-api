using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.ViewModels
{
    public class TempLogModel
    {
        public Guid TemLogId { get; set; }
        public string PayLoad { get; set; }
        public string Message { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
