using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{

    public partial class UserRole : BasicBaseEntity
    {
        public Guid UserRoleId { get; set; }

        public Guid RoleId { get; set; }

        public Guid UserId { get; set; }

    }
}
