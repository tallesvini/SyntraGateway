using Syntra.SharedKernel.Abstractions;

namespace Syntra.Modules.Management.Domain.ApiClients
{
    public interface IApiClientRepository : IRepository<ApiClient>
    {
        Task<ApiClient?> GetByClientIdAsync(string clientId, CancellationToken cancellationToken = default);
    }
}
