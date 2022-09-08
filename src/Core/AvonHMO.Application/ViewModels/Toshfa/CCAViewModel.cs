using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class CCAViewModel
    {
        public int MemberNo { get; set; }
        public string MemberName { get; set; }
        public int PolicyNo { get; set; }
        public string ClientName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string MemberStatus { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Portfolio { get; set; }
        public string Hospital { get; set; }
        public string SBU { get; set; }
        public string GeographicalLocation { get; set; }
        public DateTime Date { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public int AgeGroup { get; set; }
        public string MemberType { get; set; }
        public string ProductType { get; set; }
        public string Industry { get; set; }
        public string ClientCategory { get; set; }
        public decimal ActualPremium { get; set; }
        public decimal ProRataPremium { get; set; }
        public decimal EarnedPremium { get; set; }
        public int EarnedDays { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}
