using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class ClientPremiumPostDtlsViewModel
    {
        public string Clientname { get; set; }
        public int Policyno { get; set; }
        public DateTime Fromdate { get; set; }
        public DateTime Todate { get; set; }
        public string PremiumPosted { get; set; }

    }
}
