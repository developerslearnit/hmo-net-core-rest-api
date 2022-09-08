using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public partial class Referalhistory
    {
        public Guid ReferalhistoryId { get; set; }

        public int? MemberNo { get; set; }

        public string ReferalCode { get; set; }

        public Guid EnrolleeId { get; set; }

        public string InviteePhone { get; set; }

        public string ReferalLink { get; set; }

        public DateTime ReferDate { get; set; }
    }
}
