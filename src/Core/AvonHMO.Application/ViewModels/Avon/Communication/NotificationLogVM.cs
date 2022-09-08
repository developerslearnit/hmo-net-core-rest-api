using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Communication
{
    public class NotificationLogVM
    {
        public  Guid id { get; set; }
        public string ownerId { get; set; }

        public string body { get; set; }

        public string subject { get; set; }

        public DateTime SentDate { get; set; }

        public string DateSent { get { return SentDate.ToString("dd/MMM/yyyy"); } }

    }
}
