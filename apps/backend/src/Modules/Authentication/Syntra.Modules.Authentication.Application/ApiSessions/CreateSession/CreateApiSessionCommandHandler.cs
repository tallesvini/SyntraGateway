using Syntra.SharedKernel.Results;
using Syntra.Modules.Authentication.Domain.ApiSessions;
using Syntra.BuildingBlocks.Application.Abstractions.CQRS;
using Syntra.BuildingBlocks.Application.Abstractions.Persistence;

namespace Syntra.Modules.Authentication.Application.ApiSessions.CreateSession;

public class CreateApiSessionCommandHandler : ICommandHandler<CreateApiSessionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApiSessionRepository _repository;

    public CreateApiSessionCommandHandler(IApiSessionRepository repository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    
    public async Task<Result> Handle(CreateApiSessionCommand request, CancellationToken cancellationToken)
    {
        return await ApiSession.Create(request.ClientId, request.Jti,DateTimeOffset.UtcNow, request.ExpiresAt)
            .Tap(session => _repository.AddAsync(session, cancellationToken))
                .Tap(_ => _unitOfWork.SaveChangesAsync(cancellationToken));
    }
}