using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoPlanMasterDetailsInformationViewModel
    {
        public string GroupName { get; set; }

        public int PolicyNo { get; set; }

        public string PolicyName { get; set; }

        public int ClassCode { get; set; }

        public string ClassName { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string PlanType { get; set; }

        public int TemplateCode { get; set; }

        public string TemplateName { get; set; }

        public string PolicyPlanType { get; set; }

        public int PlanCategoryCode { get; set; }

        public string PlanCategoryName { get; set; }

        public string AvonHMoPlanType { get; set; }

        public int MinDpndsCovered { get; set; }

        public int DaysCoveredPolExp { get; set; }

        public int MaxEmpAge { get; set; }

        public int MinEmpAge { get; set; }

        public int MinSonAgeDays { get; set; }

        public int MaxSonAgeYear { get; set; }

        public int MinDaughterAgeDays { get; set; }

        public int MaxDaughterAgeYear { get; set; }

        public bool SecondOpnionReq { get; set; }

        public bool PreExistAllow { get; set; }

        public bool ConginatalDeseaseAllow { get; set; }

        public bool PreExistMaternityAllow { get; set; }

        public int MaternityWaitPeriod { get; set; }

        public decimal PreExistDisSubLimitPerMem { get; set; }

        public decimal PreExistDisClassAggrLimit { get; set; }

        public decimal PreExistMaternityLimitperMem { get; set; }

        public decimal PreExistClassAggrLimitForMaternity { get; set; }

        public decimal ConginatalSubLimitPerMem { get; set; }

        public decimal ConginatalClassAggrLimit { get; set; }

        public int MaxConsultation { get; set; }

        public decimal AggregrateAnnualLimitPerMem { get; set; }

        public string BenefitType { get; set; }

        public bool Primary { get; set; }

        public bool Secondary { get; set; }

        public bool Tertiary { get; set; }

        public bool Chronic { get; set; }

        public int ANCAndDeliveryServices { get; set; }

        public string Currency { get; set; }

        public string Broker { get; set; }

        public string Relation { get; set; }

        public decimal BasicPremium { get; set; }

        public decimal MaternityPremium { get; set; }

        public decimal DentalPremium { get; set; }

        public decimal OpticalPremium { get; set; }

        public decimal VaccPremium { get; set; }

        public decimal OtherPremium { get; set; }

        public decimal TotalPremium { get; set; }
    }
}
