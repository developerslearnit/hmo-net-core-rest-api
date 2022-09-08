using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Enrollee
{
   
    public class EnrolleePhotoUploadResponseModel
    {
        public Lstenroleephotouploadstatusmodel lstEnroleePhotoUploadStatusModel { get; set; }
    }

    public class Lstenroleephotouploadstatusmodel
    {
        public string Success { get; set; }
        public string Message { get; set; }
        public string ValidationError { get; set; }
    }

}
