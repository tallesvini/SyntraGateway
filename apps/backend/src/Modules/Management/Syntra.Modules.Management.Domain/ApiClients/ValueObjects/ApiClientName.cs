using Syntra.SharedKernel.Domain;
using Syntra.SharedKernel.Results;

namespace Syntra.Modules.Management.Domain.ApiClients.ValueObjects
{
    public sealed class ApiClientName : ValueObject
    {
        public string Value { get; }

        private ApiClientName(string value)
        {
            Value = value;
        }

        public static Result<ApiClientName> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return ApiClientErrors.NameRequired;

            value = value.Trim();

            if (value.Length > 128) return ApiClientErrors.NameTooLong;

            return new ApiClientName(value);
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
