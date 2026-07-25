using Syntra.SharedKernel.Results;
using Syntra.Modules.Management.Domain.ApiClients;
using Syntra.BuildingBlocks.Application.Abstractions.CQRS;

namespace Syntra.Modules.Management.Application.ApiClients.GetByClientId
{
    public class GetByClientIdQueryHandler : IQueryHandler<GetByClientIdQuery, Result<ApiClient>>
    {
        private readonly IApiClientRepository _repository;

        public GetByClientIdQueryHandler(IApiClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<ApiClient>> Handle(GetByClientIdQuery request, CancellationToken cancellationToken)
        {
            ApiClient? client = await _repository.GetByClientIdAsync(request.ClientId, cancellationToken);

            return client is not null ? 
                client : ApiClientErrors.NotFound(nameof(request.ClientId));
        }
    }
}
