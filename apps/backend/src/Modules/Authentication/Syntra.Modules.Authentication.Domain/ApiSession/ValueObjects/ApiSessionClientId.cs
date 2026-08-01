using Syntra.SharedKernel.Domain;
using Syntra.SharedKernel.Guards;
using Syntra.SharedKernel.Results;

namespace Syntra.Modules.Authentication.Domain.ApiSession.ValueObjects
{
    public sealed class ApiSessionClientId : ValueObject
    {
        public Guid Value { get; }

        private ApiSessionClientId(Guid value)
        {
            Value = value;
        }

        public static Result<ApiSessionClientId> Create(Guid value)
        {
            var validation = GuidGuard.NotEmpty(value, ApiSessionError.InvalidClientId);

            if (!validation.IsSuccess) 
                return validation.Error;

            return new ApiSessionClientId(value);
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
