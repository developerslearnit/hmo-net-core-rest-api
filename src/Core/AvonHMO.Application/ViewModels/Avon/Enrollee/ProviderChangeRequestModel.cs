using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Enrollee
{

    public class ProviderChangeRequestModel
    {
        public string memberno { get; set; }
        public string PProvderno { get; set; }
        public string ChangeDate { get; set; } //yyyy-MM-dd
    }


    public class ProviderChangeResponseModel
    {
        public Lstprimaryproviderchangerequeststatusmodel lstPrimaryProviderChangeRequestStatusModel { get; set; }
    }

    public class Lstprimaryproviderchangerequeststatusmodel
    {
        public string Success { get; set; }
        public string Message { get; set; }
        public string ValidationError { get; set; }
    }


}
