using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoMemberDetailsViewModel
    {
        public int MemberNo { get; set; }

        public string MemberName { get; set; }

        public string MobileNo { get; set; }

        public string EMAIL { get; set; }

        public DateTime ClaimIncurredDate { get; set; }

        public DateTime ClaimReceivedDate { get; set; }

        public DateTime TRANS_DATE { get; set; }
    }
}
