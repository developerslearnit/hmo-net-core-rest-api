using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Plan;
using System.Linq;

namespace AvonHMO.Domain.Interfaces.Avon
{
    public interface IPlanRepository
    {
        IQueryable<PlanTypeViewModel> AllPlanTypes();
        IQueryable<PlanViewModel> AllPlans();
        IQueryable<PlanTypeViewModel> AllOtherPlans();
        IQueryable<PlanCategoryViewModel> PlanCategories();


    }
}
