using Syntra.SharedKernel.Results;
using Syntra.Modules.Management.Domain.ApiClients;
using Syntra.BuildingBlocks.Application.Abstractions.CQRS;

namespace Syntra.Modules.Management.Application.ApiClients.GetByClientId
{
    public sealed record GetByClientIdQuery(string ClientId) 
        : IQuery<Result<ApiClient>>;
}
