using Syntra.SharedKernel.Domain;
using Syntra.SharedKernel.Guards;
using Syntra.SharedKernel.Results;

namespace Syntra.Modules.Authentication.Domain.ApiSessions.ValueObjects
{
    public sealed class ApiSessionJti : ValueObject
    {
        public Guid Value { get; }

        private ApiSessionJti() { }

        private ApiSessionJti(Guid value)
        {
            Value = value;
        }

        public static Result<ApiSessionJti> Create(Guid value)
        {
            var validation = GuidGuard.NotEmpty(value, ApiSessionError.InvalidJti);

            if (!validation.IsSuccess) 
                return validation.Error;

            return new ApiSessionJti(value);
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
