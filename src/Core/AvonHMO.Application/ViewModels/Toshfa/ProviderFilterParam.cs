using AvonHMO.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class ProviderFilterParam: PagingParam
    {
        
        public string City { get; set; }
        public string ServiceType { get; set; }
        //public string Name { get; set; }
        public string searchKey { get; set; }
        public string Lga { get; set; }
        public string planClass { get; set; }
    } 
    public class ProviderSearchFilterParam: PagingParam
    {
        public string searchKey { get; set; }
        public string category { get; set; }
    }
}
