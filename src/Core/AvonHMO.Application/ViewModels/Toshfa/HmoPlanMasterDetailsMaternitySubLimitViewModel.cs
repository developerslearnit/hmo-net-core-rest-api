using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoPlanMasterDetailsMaternitySubLimitViewModel
    {
        public int PolicyNo { get; set; }

        public string PolicyName { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int ClassCode { get; set; }

        public string ClassName { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal SubLimit { get; set; }

        public decimal CoInsurance { get; set; }

        public decimal TotalLimit { get; set; }

        public bool ListInMemberVerification { get; set; }
    }
}
