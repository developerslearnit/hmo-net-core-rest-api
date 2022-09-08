using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoTotalPremiumViewModel
    {
        public string ClientName { get; set; }

        public int PolicyNo { get; set; }

        public DateTime FromDate { get; set; }

        public int MemberNo { get; set; }

        public string MemberHeadNo { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string Name { get; set; }

        public string PlanType { get; set; }

        public string PlanTypeCategory { get; set; }

        public DateTime PaidDate { get; set; }

        public string SBU { get; set; }

        public string AgentId { get; set; }

        public string AgentName { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public DateTime DOB { get; set; }
    }
}
