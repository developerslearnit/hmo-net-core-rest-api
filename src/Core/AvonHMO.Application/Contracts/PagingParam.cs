using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.Contracts
{
    public class PagingParam
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }

    public class EnrolleeSearchParam : PagingParam
    {
        public string name { get; set; }

        public string cardNo { get; set; }

        public string planType { get; set; }

        public string provider { get; set; }

        public string startDate { get; set; }

        public string endDate { get; set; }
    }
}
