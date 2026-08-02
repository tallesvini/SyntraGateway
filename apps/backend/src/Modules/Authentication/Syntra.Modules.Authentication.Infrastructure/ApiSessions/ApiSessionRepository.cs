using Microsoft.EntityFrameworkCore;
using Syntra.Modules.Authentication.Domain.ApiSessions;
using Syntra.Modules.Authentication.Infrastructure.Persistence;

namespace Syntra.Modules.Authentication.Infrastructure.ApiSessions;

public class ApiSessionRepository : IApiSessionRepository
{
    private readonly AuthenticationDbContext _dbContext;
    
    public ApiSessionRepository(AuthenticationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ApiSession> GetApiSessionByApiClientIdAsync(Guid apiClientId)
    {
        return await _dbContext.ApiSessions.FirstOrDefaultAsync(x => x.ApiClientId.Value == apiClientId);
    }
    
    public async Task AddAsync(ApiSession value, CancellationToken cancellationToken = default)
    {
        await _dbContext.ApiSessions.AddAsync(value, cancellationToken);
    }
}