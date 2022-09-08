using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Provider
{
    public class ProviderInspectionGuideViewModel
    {
        public Guid questionId { get; set; }
        public string question { get; set; }
        public bool isMultipleChoice { get; set; }
        public int orderNo { get; set; }
        public List<ProviderInspectionGuideOptions> options { get; set; } = new List<ProviderInspectionGuideOptions>();
    }

    public class ProviderInspectionGuideOptions
    {
        public Guid optionId { get; set; }
        public string Option { get; set; }
        public int orderNo { get; set; }
    }
    public class ProviderInspectionGuideAnswerDTO
    {
        public string providerId { get; set; }
        public List<ProviderInspectionGuideAnswer> providerAnswers { get; set; }

    }
    public class ProviderInspectionGuideAnswer
    {
        [Required]
        public Guid questionId { get; set; }

        [Required]
        public string answer { get; set; }

    }
}
