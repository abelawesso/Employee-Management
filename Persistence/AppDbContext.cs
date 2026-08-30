using Employee_API.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
namespace Employee_API.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<AuditableEntity> AuditableEntities { get; set; }
        public DbSet<Employe> Employes { get; set; }

    }
}
