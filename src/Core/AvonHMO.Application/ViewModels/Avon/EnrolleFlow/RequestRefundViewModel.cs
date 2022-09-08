using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.EnrolleFlow
{

    public class RequestRefundViewModel
    {
        public Guid RequestRefundId { get; set; }
        public Guid EnrolleeId { get; set; }
        public string MemberNo { get; set; }
        public string Reason { get; set; }
        public string OtherReasons { get; set; }
        public decimal Amount { get; set; }
        public string RequestDate { get; set; }
        public string RequestStatus { get; set; }
        public string EncounteredDate { get; set; }
        public string HospitalName { get; set; }
        public string HospitalLocation { get; set; }
        public string CompanyName { get; set; }
        public string PACode { get; set; }
        public string BeneficiaryName { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string MedicalReportDoc { get; set; }
        public string ReceiptsDoc { get; set; }
        public string InvoiceDoc { get; set; }

    }
    
    public class RequestRefundRequestModel
    {
        //public string MemberNo { get; set; }
        public string Reason { get; set; }
        public string OtherReasons { get; set; }
        public string Amount { get; set; }
        public string EncounteredDate { get; set; }
        public string HospitalName { get; set; }
        public string HospitalLocation { get; set; }
        public string CompanyName { get; set; }
        public string PACode { get; set; }
        public string BeneficiaryName { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string MedicalReportDoc { get; set; }
        public string ReceiptsDoc { get; set; }
        public string InvoiceDoc { get; set; }


    }
}
