using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.Contracts
{

    //public class PagedResponse<T>
    //{
    //    public PagedResponse()
    //    {

    //    }

    //    public PagedResponse(IEnumerable<T> data)
    //    {
    //        Data = data;
    //    }

    //    public IEnumerable<T> Data { get; set; }

    //    public int? PageNumber { get; set; }

    //    public int? PageSize { get; set; }


    //    public int StatusCode { get; set; }

    //    public bool hasError { get; set; }

    //    public string Message { get; set; } = string.Empty;
    //}

    public class PagedResponse<T>
    {
        public PagedResponse(){ }

        public PagedResponse(IEnumerable<T> data)
        {
            Data = data;
        }

        public IEnumerable<T> Data { get; set; }

        public int? PageNumber { get; set; }

        public int? Totalrecords { get; set; }

        public int? PageSize { get; set; }

        public int StatusCode { get; set; }

        public bool hasError { get; set; }

        public string Message { get; set; } = string.Empty;

    }
}
