using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class SupplyPriceListViewModel
    {
        public int ProviderNo { get; set; }
        public string ProviderName { get; set; }
        public string ProviderType { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Capitation { get; set; }
        public string CPTCode { get; set; }
        public string CPTDescription { get; set; }
        public string PAApprove { get; set; }
        public string PlanName { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime TRANS_DATE { get; set; }

    }
}
