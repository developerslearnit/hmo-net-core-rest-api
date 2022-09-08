using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{
    public class AgentOrBrokerInfomationViewModel
    {
        public int STKH_CODE { get; set; }
        public string STKH_NAME { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string NOTES { get; set; }
        public string STKH_TYPE { get; set; }
        public string IDType { get; set; }
        public string IDNo { get; set; }
        public string State { get; set; }
        public string BrokerType { get; set; }
        public string SBU { get; set; }

    }

    public class AgentOrBrokerInfomationDTO
    {
        public int    stkh_code { get; set; }
        public string stkh_name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string notes { get; set; }
        public string stkh_type { get; set; }
        public string id_type { get; set; }
        public string id_no { get; set; }
        public string state { get; set; }
        public string broker_type { get; set; }
        public string sbu { get; set; }

    }
}
