using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{
    public class HCPInspectionGuildAnswer
    {
        public Guid AnswerId { get; set; }    
        public Guid QuestionId { get; set; }    
        public string Answer { get; set; }    
        public string HCPId { get; set; }    
        public DateTime DateCreated { get; set; }    
    }
}
