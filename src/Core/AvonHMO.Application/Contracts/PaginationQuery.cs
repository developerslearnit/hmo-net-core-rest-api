using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.Contracts
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            
        }

        public PaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize > 20 ? 20 : pageSize;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
