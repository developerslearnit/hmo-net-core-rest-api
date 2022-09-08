using System.Collections.Generic;

namespace AvonHMO.Application.ViewModels.Avon.Plan
{
    public class PlanBenefitDetailsModel
    {
        public List<Lstistofplanbyproviderdetail> lstistofplanbyproviderDetails { get; set; }
        
    }

    public class Lstistofplanbyproviderdetail
    {
        public string PolicyNo { get; set; }
        public string PlanCode { get; set; }
        public string BenefitName { get; set; }
        public string WaitingPeriod { get; set; }
        public string ValueLimit { get; set; }
        public string FrequencyLimit { get; set; }
        public string Age { get; set; }
    }

}
