using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public class UserPreference
    {
        public Guid PrefId { get; set; }

        public string MemberNo { get; set; }

        public string PrefKey { get; set; }

        public string PrefValue { get; set; }
    }
}
