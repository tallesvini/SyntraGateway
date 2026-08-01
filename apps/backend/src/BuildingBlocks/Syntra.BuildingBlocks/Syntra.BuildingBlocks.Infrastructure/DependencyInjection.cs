using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Syntra.BuildingBlocks.Infrastructure.Security;
using Syntra.BuildingBlocks.Application.Abstractions.Security;
using Syntra.BuildingBlocks.Infrastructure.Time;
using Syntra.SharedKernel.Abstractions;

namespace Syntra.BuildingBlocks.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddScoped<ISecurityCredentialGenerator, SecurityCredentialGenerator>();
            services.AddScoped<ISecretHasher, SecretHasher>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}
