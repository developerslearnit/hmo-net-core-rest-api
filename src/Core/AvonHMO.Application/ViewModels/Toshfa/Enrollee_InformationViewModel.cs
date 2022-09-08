using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class Enrollee_InformationViewModel
    {
        public int MemberNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Plan_Type { get; set; }
        public DateTime Policy_Start_Date { get; set; }
        public DateTime Policy_End_Date { get; set; }
        public string PhoneNumber { get; set; }
        public string EMAIL { get; set; }
        public decimal Amount { get; set; }
        public string ContactAddress { get; set; }
        public int Policy_no { get; set; }
        public string DiseaseCondition { get; set; }
        public DateTime DateDiagnosed { get; set; }
        public int ClaimNo { get; set; }

    }
}
