using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoMemberPolicyStatusViewModel
    {
        public int MemberNo { get; set; }

        public DateTime DOB { get; set; }

        public string Sex { get; set; }

        public string MemberheadNo { get; set; }

        public string Firstname { get; set; }

        public string MiddleName { get; set; }

        public string SurName { get; set; }

        public string Status { get; set; }

        public string ToshfaUniqueId { get; set; }

        public int Policyno { get; set; }

        public DateTime Fromdate { get; set; }

        public DateTime Todate { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public DateTime MemberExpirydate { get; set; }
    }
}
