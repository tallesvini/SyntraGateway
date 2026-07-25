using System.Security.Cryptography;
using Syntra.BuildingBlocks.Application.Abstractions.Security;

namespace Syntra.BuildingBlocks.Infrastructure.Security
{
    public class SecretHasher : ISecretHasher
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 100_000;

        public string Hash(string secret)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                secret,
                salt,
                Iterations,
                HashAlgorithmName.SHA256,
                KeySize);

            byte[] result = new byte[SaltSize + KeySize];

            Buffer.BlockCopy(salt, 0, result, 0, SaltSize);
            Buffer.BlockCopy(hash, 0, result, SaltSize, KeySize);

            return Convert.ToBase64String(result);
        }

        public bool Verify(string secret, string storedHash)
        {
            byte[] data = Convert.FromBase64String(storedHash);

            byte[] salt = new byte[SaltSize];
            Buffer.BlockCopy(data, 0, salt, 0, SaltSize);

            byte[] hash = new byte[KeySize];
            Buffer.BlockCopy(data, SaltSize, hash, 0, KeySize);

            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(
                secret,
                salt,
                Iterations,
                HashAlgorithmName.SHA256,
                KeySize);

            return CryptographicOperations.FixedTimeEquals(
                hash,
                inputHash);
        }
    }
}
