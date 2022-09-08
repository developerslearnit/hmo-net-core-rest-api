using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public class ProviderChangeLog
    {
        public Guid Id { get; set; }

        public string MemberNo { get; set; }

        public DateTime ChangedDate { get; set; }

        public DateTime NextPossibleChangeDate { get; set; }
    }
}
