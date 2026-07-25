using Syntra.SharedKernel.Results;
using Syntra.BuildingBlocks.Application.Abstractions.CQRS;

namespace Syntra.Modules.Management.Application.ApiClients.CreateClient
{
    public sealed record CreateApiClientCommand(string Name, string Description) 
        : ICommand<Result<CreateApiClientResponse>>;
}
