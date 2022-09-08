using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class HmoMemberDetailsWithToshfaUIDViewModel
    {
        public string ToshfaUID { get; set; }

        public int Memberno { get; set; }

        public string HouseHoldId { get; set; }

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string MaidenName { get; set; }

        public string Age { get; set; }

        public string Sex { get; set; }

        public string MobileNo { get; set; }

        public string Email { get; set; }

        public string Maritalstatus { get; set; }

        public string PrimaryProviderName { get; set; }

        public string ClientName { get; set; }

        public DateTime PolicyStartDate { get; set; }

        public DateTime PolicyEndDate { get; set; }
    }
}
