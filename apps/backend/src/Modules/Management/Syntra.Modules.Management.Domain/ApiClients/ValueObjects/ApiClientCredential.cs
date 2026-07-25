using Syntra.SharedKernel.Domain;
using Syntra.SharedKernel.Results;
using System.Security.Cryptography;

namespace Syntra.Modules.Management.Domain.ApiClients.ValueObjects
{
    public sealed class ApiClientCredential : ValueObject
    {
        public string ClientId { get; }
        public string SecretHash { get; }
        public DateTimeOffset ExpiresAt { get; }

        public ApiClientCredential() { }

        public ApiClientCredential(string clientId, string secretHash)
        {
            ClientId = clientId;
            SecretHash = secretHash;
            ExpiresAt = DateTimeOffset.UtcNow;
        }

        public static Result<ApiClientCredential> Create(string clientId, string clientSecret)
        {
            return new ApiClientCredential(clientId, clientSecret);
        }

        public bool IsExpired() => 
            ExpiresAt <= DateTimeOffset.UtcNow;

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return ClientId;
            yield return SecretHash;
            yield return ExpiresAt;
        }
    }
}
