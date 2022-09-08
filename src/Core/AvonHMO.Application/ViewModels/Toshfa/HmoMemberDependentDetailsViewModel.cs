using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoMemberDependentDetailsViewModel
    {
        public int MemberNo { get; set; }
        public string MemberName { get; set; }
        public string Gender { get; set; }
        public string Relation { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string AxaMemberNo { get; set; }
        public string Status { get; set; }
        public int POLICYNO { get; set; }
        public DateTime FROMDATE { get; set; }
        public string MemberHeadNo { get; set; }
    }
}
