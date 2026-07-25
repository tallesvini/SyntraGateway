using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Syntra.Modules.Management.Domain.ApiClients;
using Syntra.BuildingBlocks.Infrastructure.Persistence;
using Syntra.Modules.Management.Infrastructure.ApiClients;
using Syntra.Modules.Management.Infrastructure.Persistence;
using Syntra.BuildingBlocks.Application.Abstractions.Persistence;

namespace Syntra.Modules.Management.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddManagementInfrastructure(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ManagementDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsAssembly(typeof(ManagementDbContext).Assembly.FullName));
            });

            services.AddScoped<IApiClientRepository, ApiClientRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork<ManagementDbContext>>();

            return services;
        }
    }
}
