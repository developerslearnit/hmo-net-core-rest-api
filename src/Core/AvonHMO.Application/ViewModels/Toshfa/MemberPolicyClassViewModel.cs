using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class MemberPolicyClassViewModel
    {
        public string EnrolleeName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Relation { get; set; }
        public string MemberType { get; set; }
        public string Clientname { get; set; }
        public string PrimaryProvider { get; set; }
        public string PlanName { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public int PolicyNo { get; set; }
        public DateTime FromDate { get; set; }
        public int ClassCode { get; set; }
        public int CardNo { get; set; }
        public string Status { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime MemberExpirydate { get; set; }
        public DateTime CardExpirydate { get; set; }
        public DateTime ReqProcessDate { get; set; }
        public DateTime CardProcessDate { get; set; }
        public string EmpNo { get; set; }
        public int BranchNo { get; set; }
        public string DBNNo { get; set; }
        public string CBNNo { get; set; }
        public decimal Membershipno { get; set; }
        public string Notes { get; set; }
        public DateTime TRANS_DATE { get; set; }
        public string USERID { get; set; }
        public string PaymentTerms { get; set; }
        public string HouseholdId { get; set; }
        public int KNCU_MemberNo { get; set; }
        public bool HasInsurance { get; set; }
        public string PremiumType { get; set; }
        public int ApplicationNo { get; set; }
        public string Gm_Memberno { get; set; }
        public string Gm_TranDate { get; set; }
        public string IndPolicyNo { get; set; }
        public string VerifiedBy { get; set; }
        public string EXCEL_NAME { get; set; }
        public DateTime CardPrintDate { get; set; }
        public DateTime CertificatePrintDate { get; set; }
        public DateTime PolicyDocPrintDate { get; set; }
        public int CMemberNo { get; set; }
        public bool MemberMailStatus { get; set; }
        public string MemberNote { get; set; }
        public string SF_Trans_Type_Add { get; set; }
        public string NewRepMemberFlag { get; set; }

    }
}
