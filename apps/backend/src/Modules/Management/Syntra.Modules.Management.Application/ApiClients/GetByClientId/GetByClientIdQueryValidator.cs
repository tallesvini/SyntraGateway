using FluentValidation;

namespace Syntra.Modules.Management.Application.ApiClients.GetByClientId
{
    public class GetByClientIdQueryValidator
        : AbstractValidator<GetByClientIdQuery>
    {
        public GetByClientIdQueryValidator()
        {
            RuleFor(query => query)
                .NotEmpty();

            RuleFor(x => x.ClientId)
                .NotEmpty();
        }
    }
}
