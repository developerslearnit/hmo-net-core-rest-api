using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.ViewModels
{
    public class CyclePlannerCategoryViewModel
    {
        public Guid cyclePlannerCategoryId { get; set; }
        public string description { get; set; }
    }

    public class CycleInfoViewModel
    {
        public Guid cycleId { get; set; }
        public DateTime periodStartDate { get; set; }
        public int periodDuration { get; set; }
        public int periodCycle { get; set; }
        public Guid CyclePlannerCategoryId { get; set; }
        public string CyclePlannerCategory { get; set; }
    }

    public class NextPeriodInfoViewModel
    {
        public DateTime lastPeriodStartDate { get; set; }
        public DateTime nextPeriodStartDate { get; set; }
        public DateTime nextOvulationDate { get; set; }
        public DateTime periodEndDate { get { return nextPeriodStartDate.AddDays(averageperiodDuration); } }
        public int averageperiodDuration { get; set; }
        public int averageperiodCycle { get; set; }
    }

    public class CycleInfoRequestModel
    {
        public string cycleId { get; set; }


        /// <summary>
        /// format: dd/MM/yyyy
        /// </summary>
        [Required]
        public string periodStartDate { get; set; } 
       
        [Required]
        public int periodDuration { get; set; }
        [Required]
        public int periodCycle { get; set; }

        [Required]
        public Guid CyclePlannerCategoryId { get; set; }
    }
    public class CycleInfoResponseDTO
    {
        public Guid cycleId { get; set; }
        public int memberNumber { get; set; }
        public Guid enrolleeId { get; set; }
        public bool hasError { get; set; }
    }
}
