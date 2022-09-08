using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public partial class LoginTrail
    {
        public Guid LoginTrailId { get; set; }

        public string UserId { get; set; }

        public DateTime LoginDate { get; set; }
    }
}
