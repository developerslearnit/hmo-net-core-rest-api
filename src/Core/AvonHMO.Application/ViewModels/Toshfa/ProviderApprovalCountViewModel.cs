using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class ProviderApprovalCountViewModel
    {
        public int ProviderNo { get; set; }
        public string ProviderName { get; set; }
        public int ApprovalCount { get; set; }
        public string Status { get; set; }
        public decimal ApprovedAmount { get; set; }
    }
}
