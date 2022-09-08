using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoTotalPremiumPerHealthPlanViewModel
    {
        public string ClientName { get; set; }

        public int PolicyNo { get; set; }

        public DateTime FromDate { get; set; }

        public int MemberNo { get; set; }

        public string MemberHeadNo { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string Name { get; set; }

        public string PlanType { get; set; }
        /*ClientName, varchar(200),>
           ,<PolicyNo, int,>
           ,<FromDate, datetime,>
           ,<MemberNo, int,>
           ,<MemberHeadNo, varchar(10),>
           ,<EnrollmentDate, datetime,>
           ,<Name, varchar(160),>
           ,<PlanType, varchar(200),>
           ,<Plan Type Category, varchar(50),>
           ,<PaidDate, datetime,>
           ,<SBU, varchar(200),>
           ,<AgentId, varchar(15),>
           ,<AgentName, varchar(200*/
        public string PlanTypeCategory { get; set; }

        public DateTime PaidDate { get; set; }

        public string SBU { get; set; }

        public string AgentId { get; set; }

        public string AgentName { get; set; }
    }
}
