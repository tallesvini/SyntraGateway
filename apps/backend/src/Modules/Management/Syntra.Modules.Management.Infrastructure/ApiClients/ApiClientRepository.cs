using Microsoft.EntityFrameworkCore;
using Syntra.Modules.Management.Domain.ApiClients;
using Syntra.Modules.Management.Infrastructure.Persistence;

namespace Syntra.Modules.Management.Infrastructure.ApiClients
{
    public sealed class ApiClientRepository : IApiClientRepository
    {
        private readonly ManagementDbContext _dbContext;

        public ApiClientRepository(ManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiClient?> GetByClientIdAsync(string clientId, CancellationToken cancellationToken = default)
            => await _dbContext.ApiClients
            .AsNoTracking()
            .FirstOrDefaultAsync(
                x => x.Credential.ClientId == clientId, 
                cancellationToken);

        public async Task AddAsync(ApiClient client, CancellationToken cancellationToken = default)
            => await _dbContext.ApiClients
            .AddAsync(client, cancellationToken);   
    }
}
