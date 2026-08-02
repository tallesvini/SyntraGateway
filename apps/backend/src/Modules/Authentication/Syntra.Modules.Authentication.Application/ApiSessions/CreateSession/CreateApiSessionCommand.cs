using Syntra.BuildingBlocks.Application.Abstractions.CQRS;
using Syntra.SharedKernel.Results;

namespace Syntra.Modules.Authentication.Application.ApiSessions.CreateSession;

public sealed record CreateApiSessionCommand(Guid ClientId, Guid Jti, DateTimeOffset ExpiresAt)
    : ICommand<Result>;