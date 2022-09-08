using System.Collections.Generic;

namespace AvonHMO.Application.ViewModels.Avon.EnrolleFlow
{


    public class MedicalRecordLists
    {
        public List<MedicalRecordViewModel> lstEnroleeMedicalRecordsDetails { get; set; }
    }

    public class MedicalRecordViewModel
    {
        public string PARequestNo { get; set; }
        public string PACode { get; set; }
        public string PARequestDate { get; set; }
        public string BenefitName { get; set; }
        public string Provider { get; set; }
        public string Diagnosis { get; set; }
        public string ServicePriceList { get; set; }
        public string FinalAmount { get; set; }
        public string ValidationError { get; set; }
    }



   

}
