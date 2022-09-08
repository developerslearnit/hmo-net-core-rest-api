using AvonHMO.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvonHMO.Persistence.StorageContexts.Toshfa
{
    public partial class ToshfaDbContext : DbContext
    {
        public ToshfaDbContext(DbContextOptions<ToshfaDbContext> options)
           : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false; 
        }

    }
}
