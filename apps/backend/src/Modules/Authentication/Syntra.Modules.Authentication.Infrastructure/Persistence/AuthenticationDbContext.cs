using Microsoft.EntityFrameworkCore;
using Syntra.Modules.Authentication.Domain.ApiSessions;

namespace Syntra.Modules.Authentication.Infrastructure.Persistence;

public class AuthenticationDbContext : DbContext
{
    public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) 
        :base(options) { }
    
    public DbSet<ApiSession> ApiSessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApiSession>();
    }
}