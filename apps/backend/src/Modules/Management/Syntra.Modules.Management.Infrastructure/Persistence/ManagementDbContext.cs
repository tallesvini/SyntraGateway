using Microsoft.EntityFrameworkCore;
using Syntra.Modules.Management.Domain.ApiClients;

namespace Syntra.Modules.Management.Infrastructure.Persistence
{
    public sealed class ManagementDbContext : DbContext
    {
        public ManagementDbContext(DbContextOptions<ManagementDbContext> options) 
            : base(options) { }

        public DbSet<ApiClient> ApiClients => Set<ApiClient>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ManagementDbContext).Assembly);
        }
    }
}
