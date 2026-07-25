using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Syntra.BuildingBlocks.Infrastructure.Security;
using Syntra.BuildingBlocks.Application.Abstractions.Security;

namespace Syntra.BuildingBlocks.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddScoped<ISecurityCredentialGenerator, SecurityCredentialGenerator>();
            services.AddScoped<ISecretHasher, SecretHasher>();

            return services;
        }
    }
}
