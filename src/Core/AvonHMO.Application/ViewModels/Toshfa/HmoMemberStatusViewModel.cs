using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoMemberStatusViewModel
    {
        public int Memberno { get; set; }

        public string MemberStatus { get; set; }

        public DateTime MemberStatusDate { get; set; }

        public string PolicyName { get; set; }

        public int Policyno { get; set; }

        public DateTime PolicyStartDate { get; set; }

        public DateTime PolicyEndDate { get; set; }

        public string PolicyStatus { get; set; }

        public DateTime PolicyStatusDate { get; set; }
    }
}
