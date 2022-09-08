using AvonHMO.Application.ViewModels.Avon.Plan;
using AvonHMO.Domain.Interfaces.Avon;
using AvonHMO.Persistence.StorageContexts.Avon;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AvonHMO.Domain.Services.Avon
{
    public class PlanRepository : IPlanRepository
    {

        private readonly AvonDbContext _context;
        public PlanRepository(AvonDbContext context)
        {
            _context = context;
        }

        public IQueryable<PlanCategoryViewModel> PlanCategories()
        {
            return _context.PlanCategories.AsNoTracking()
                .Select(c => new PlanCategoryViewModel { code = c.Code, name = c.CategoryName });
        }


        public IQueryable<PlanViewModel> AllPlans()
        {
            return _context.Plans.AsNoTracking()
                    .Select(plan => new PlanViewModel
                    {
                        id = plan.PlanId,
                        code = plan.PlanCode,
                        planName = plan.PlanName,
                        planTypeId = plan.PlanTypeId,
                        premium = plan.Premium,
                        color =plan.PlanColor,
                        icon = plan.PlanIcon,
                        planClass = plan.PlanClass,
                        planCategoryCode =plan.PlanCategoryCode
                    });
        }


        public IQueryable<PlanTypeViewModel> AllOtherPlans()
        {
            return _context.Plans.AsNoTracking()
                .Where(x=>x.PlanCode== 10001)
                .OrderBy(x=>x.SerialNo)
                    .Select(t => new PlanTypeViewModel
                    {
                        id = t.PlanTypeId,
                        planTypeName = t.PlanName,
                        description = t.Description,
                        icon = t.PlanIcon,
                        color = t.PlanColor,
                        requiredQuoteRequest =true,
                        bgImage = t.PlanBgImage,
                        planClass=t.PlanClass,
                    });
        }

        public IQueryable<PlanTypeViewModel> AllPlanTypes()
        {
            return _context.PlanTypes.AsNoTracking()
                .OrderBy(x=>x.SerialNo)
                .Select(t => new PlanTypeViewModel
                {
                    id = t.PlanTypeId,
                    planTypeName = t.Name,
                    description = t.Description,
                    icon =t.PlanIcon,
                    color = t.PlanColor,
                    requiredQuoteRequest =false,
                    bgImage=t.PlanBgImage,
                    
                    
                });
        }
    }
}
