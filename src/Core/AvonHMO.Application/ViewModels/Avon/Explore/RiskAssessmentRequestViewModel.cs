using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Authentication
{
    public class RiskAssessmentRequestViewModel
    {
        [Required]
        public int Age { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string DrinkingFrequency { get; set; }
        [Required]
        public bool IsSmoker { get; set; }
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public List<RiskAssessmentAnsweredModel> assessmentResult { get; set; }
    }
    
    public class RiskAssessmentRequestModel
    {
        public Guid RiskAssessmentRequestId { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string DrinkingFrequency { get; set; }
        public bool IsSmoker { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
    }
    
    public class RiskAssessmentQuestionModel
    {
        public Guid HealthRiskAssessmentQuestionId { get; set; }
        public string QuestionText { get; set; }
    }
    
    public class RiskAssessmentQuestionAnswerModel
    {
        public Guid HealthRiskAssessmentQuestionId { get; set; }
        public int Never { get; set; }
        public int Ocassionally { get; set; }
        public int Always { get; set; }
    }
    
    public class RiskAssessmentAnsweredModel
    {
        public Guid HealthRiskAssessmentQuestionId { get; set; }
        public string AnswerText { get; set; }
    }
}
