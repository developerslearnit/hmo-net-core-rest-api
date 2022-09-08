using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{

    public class HealthRiskAssessmentQuestion : BaseEntity
    {
        public Guid HealthRiskAssessmentQuestionId { get; set; }
        public string QuestionText { get; set; }
        public int Never { get; set; }
        public int Ocassionally { get; set; }
        public int Always { get; set; }
    }
}
