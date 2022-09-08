using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public class HCPInspectionGuideQuestionMaster
    {
        public Guid QuestionId { get; set; }
        public string Question { get; set; }
        public bool isMultipleChoice { get; set; }
        public int orderNo { get; set; }
    }
}
