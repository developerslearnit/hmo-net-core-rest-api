using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public class HCPInspectionGuideOptions
    {
        public Guid OptionId { get; set; }
        public string Option { get; set; }
        public Guid QuestionId { get; set; }
        public int OrderNo { get; set; }
    }
}
