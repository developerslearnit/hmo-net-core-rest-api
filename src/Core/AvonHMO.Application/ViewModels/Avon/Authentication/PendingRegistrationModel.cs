using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Authentication
{
    public class PendingRegistrationModel
    {
        public bool hasIncompleteRegistration { get; set; }=false;
        public List<string> pendingTasks { get; set; }=new List<string>();
    }
}
