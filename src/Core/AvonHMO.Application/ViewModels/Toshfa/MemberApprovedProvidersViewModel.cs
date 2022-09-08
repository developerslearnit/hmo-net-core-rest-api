using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class MemberApprovedProvidersViewModel
    {
        public int PolicyNo { get; set; }
        public DateTime FromDate { get; set; }
        public int ClassCode { get; set; }
        public int HospNo { get; set; }
        public string Name { get; set; }
        public int ContNo { get; set; }
        public string IPDAllowed { get; set; }
        public string OPDAllowed { get; set; }
        public string MaternityAllowed { get; set; }
        public string DentalAllowed { get; set; }
        public string OpticalAllowed { get; set; }
        public string AvgClaim { get; set; }
        public decimal Avg_Amount { get; set; }
        public string Capitation { get; set; }
    }
}
