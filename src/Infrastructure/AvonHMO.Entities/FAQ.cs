using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{

    public class FAQ : BaseEntity
    {
        public Guid FAQId { get; set; }
        public Guid FAQCategoryId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }

    }
}
