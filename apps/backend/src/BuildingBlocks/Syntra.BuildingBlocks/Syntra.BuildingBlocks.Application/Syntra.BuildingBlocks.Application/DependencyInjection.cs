using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Syntra.BuildingBlocks.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(assemblies);
            });

            return services;
        }
    }
}
