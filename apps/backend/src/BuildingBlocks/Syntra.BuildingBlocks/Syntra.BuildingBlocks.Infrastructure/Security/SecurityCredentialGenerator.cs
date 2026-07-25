using System.Security.Cryptography;
using Syntra.BuildingBlocks.Application.Abstractions.Security;

namespace Syntra.BuildingBlocks.Infrastructure.Security
{
    public sealed class SecurityCredentialGenerator : ISecurityCredentialGenerator
    {
        private readonly ISecretHasher _secretHasher;

        public SecurityCredentialGenerator(ISecretHasher secretHasher)
        {
            _secretHasher = secretHasher;
        }

        public SecurityCredential Generate()
        {
            var clientId = Guid.NewGuid().ToString("N");

            var secret = Convert.ToBase64String(
                RandomNumberGenerator.GetBytes(32));

            var hash = _secretHasher.Hash(secret);

            return new SecurityCredential(clientId, secret, hash);
        }
    }
}
