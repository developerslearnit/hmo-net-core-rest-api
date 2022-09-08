using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class BenefitNameViewModel
    {
        public string Benefitnames { get; set; }
        [JsonPropertyName("code")]
        public string BenefitNameCode { get; set; }
    }

    public class EnrolleePlanClassViewModel
    {
        public string PlanClass { get; set; }
       
        public int MemberNo { get; set; }
    }
}
