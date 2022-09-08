using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoMemberWisePremiumDtlsViewModel
    {
        public string ClientName { get; set; }

        public int PolicyNo { get; set; }

        public DateTime Inception { get; set; }
        
        public DateTime Expiry { get; set; }

        public string PlanType { get; set; }

        public string PolicyPlanType { get; set; }

        public string PolicyType { get; set; }

        public int PlanCode { get; set; }

        public int MemberNo { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public DateTime DOB { get; set; }

        public string Address { get; set; }

        public string SBU { get; set; }

        public string Country { get; set; }

        public string StateName { get; set; }

        public string Town { get; set; }

        public string MemberType { get; set; }

        public string MemberHeadNo { get; set; }

        public string HeadMember { get; set; }

        public string AgentId { get; set; }

        public string AgentName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public DateTime CardPrintDate { get; set; }

        public DateTime CardProcessDate { get; set; }

        public string MemberRelation { get; set; }

        public DateTime PaidDate { get; set; }
    }
}
