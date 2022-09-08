using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class EnrolleMemberViewModel
    {
        public decimal MemberNo { get; set; }
        public int PolicyNo { get; set; }
        public string PolicyName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Name { get; set; }
        public string StaffId { get; set; }
        public string PlanType { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Relation { get; set; }
        public string MemberType { get; set; }
        public DateTime Enrollmentdate { get; set; }
        public string Provider { get; set; }
        public int NoDays { get; set; }
        public string PremiumType { get; set; }
        public decimal Premium { get; set; }
        public string AvonMemberNo { get; set; }
        public string PolicyType { get; set; }
        public string MemberHeadNo { get; set; }
        public string AxaMemberNo { get; set; }
        public int ClientNo { get; set; }
        public string SBU { get; set; }
        public string PreExisteing { get; set; }
        public string MemberStatus { get; set; }
        public string brokerorAgentName { get; set; }
        public decimal BrokerPercentage { get; set; }
        public decimal BrokerCommission { get; set; }
        public DateTime StopDeleteDate { get; set; }
        public string AgentSBU { get; set; }
        public string AgentSBUCode { get; set; }
        public string DebitNotegen { get; set; }
        public decimal DebitNotegenAmount { get; set; }
        public int EarnedDays { get; set; }
        public decimal EarnedPremium { get; set; }
        public DateTime RestartDate { get; set; }
        public int StopDays { get; set; }
        public decimal StopDaysPremium { get; set; }
        public decimal TotalEarnedPremium { get; set; }
        public decimal RealPremium { get; set; }

    }

    public class CurrencyViewModel
    {
        public int CurrCode { get; set; }

        public string Description { get; set; }
    }
}
