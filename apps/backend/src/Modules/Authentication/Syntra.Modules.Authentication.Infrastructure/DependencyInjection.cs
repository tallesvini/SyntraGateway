using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Syntra.BuildingBlocks.Application.Abstractions.Persistence;
using Syntra.BuildingBlocks.Infrastructure.Persistence;
using Syntra.Modules.Authentication.Domain.ApiSessions;
using Syntra.Modules.Authentication.Infrastructure.ApiSessions;
using Syntra.Modules.Authentication.Infrastructure.Persistence;

namespace Syntra.Modules.Authentication.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddAuthenticationInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AuthenticationDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                sql => sql.MigrationsAssembly(typeof(AuthenticationDbContext).Assembly.FullName));
        });
        
        services.AddScoped<IUnitOfWork, UnitOfWork<AuthenticationDbContext>>();
        services.AddScoped<IApiSessionRepository, ApiSessionRepository>();
        
        return services;
    }
}