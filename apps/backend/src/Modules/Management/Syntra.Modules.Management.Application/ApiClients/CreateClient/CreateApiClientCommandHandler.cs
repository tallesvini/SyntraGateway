using Syntra.SharedKernel.Results;
using Syntra.Modules.Management.Domain.ApiClients;
using Syntra.BuildingBlocks.Application.Abstractions.CQRS;
using Syntra.BuildingBlocks.Application.Abstractions.Security;
using Syntra.BuildingBlocks.Application.Abstractions.Persistence;

namespace Syntra.Modules.Management.Application.ApiClients.CreateClient
{
    public class CreateApiClientCommandHandler : ICommandHandler<CreateApiClientCommand, Result<CreateApiClientResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApiClientRepository _repository;
        private readonly ISecurityCredentialGenerator _securityCredentialGenerator;

        public CreateApiClientCommandHandler(IUnitOfWork unitOfWork, IApiClientRepository repository, ISecurityCredentialGenerator securityCredentialGenerator)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _securityCredentialGenerator = securityCredentialGenerator;
        }

        public async Task<Result<CreateApiClientResponse>> Handle(CreateApiClientCommand request, CancellationToken cancellationToken)
        {
            var credential = _securityCredentialGenerator.Generate();

            return await ApiClient.Create(request.Name, request.Description, credential.ClientId, credential.SecretHash)
                .Tap(client => _repository.AddAsync(client, cancellationToken))
                    .Tap(client => _unitOfWork.SaveChangesAsync(cancellationToken))
                        .Map(client => new CreateApiClientResponse(client.Credential.ClientId, credential.ClientSecret));
        }
    }
}
