using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public partial class AppSetting
    {
        public Guid AppSettingId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
