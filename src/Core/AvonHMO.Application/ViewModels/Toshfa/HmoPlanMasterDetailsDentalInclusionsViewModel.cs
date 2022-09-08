using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoPlanMasterDetailsDentalInclusionsViewModel
    {
        public int PolicyNo { get; set; }

        public string PolicyName { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int ClassCode { get; set; }

        public string ClassName { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}
