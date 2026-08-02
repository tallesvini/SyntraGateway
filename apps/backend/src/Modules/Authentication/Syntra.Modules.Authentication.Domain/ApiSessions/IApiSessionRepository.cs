using Syntra.SharedKernel.Abstractions;

namespace Syntra.Modules.Authentication.Domain.ApiSessions;

public interface IApiSessionRepository : IRepository<ApiSession>
{
    Task<ApiSession> GetApiSessionByApiClientIdAsync(Guid apiClientId);
}