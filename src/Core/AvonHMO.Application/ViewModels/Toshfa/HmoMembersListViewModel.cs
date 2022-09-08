using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoMembersListViewModel
    {
        public int MemberNo { get; set; }

        public string MemberName { get; set; }

        public string StaffId { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public string PolicyName { get; set; }

        public string PlanName { get; set; }

        public string MemberType { get; set; }

        public string PremiumType { get; set; }

        public string Status { get; set; }

        public int PolicyNo { get; set; }

        public DateTime Fromdate { get; set; }

        public DateTime Todate { get; set; }

        public string DebitNoteGenerated { get; set; }
    }
}
