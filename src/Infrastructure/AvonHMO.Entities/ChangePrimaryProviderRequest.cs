using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public class ChangePrimaryProviderRequest
    {
        public Guid ChangeProviderRequestId { get; set; }
        public int MemberNumber { get; set; }
        public Guid EnrolleeId { get; set; }
        public string MemberEmail { get; set; }
        public int CurrentProviderCode { get; set; }
        public string CurrentProviderName { get; set; }
        public int NewProviderCode { get; set; }
        public string NewProviderName { get; set; }
        public string RequestStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
    }
}
