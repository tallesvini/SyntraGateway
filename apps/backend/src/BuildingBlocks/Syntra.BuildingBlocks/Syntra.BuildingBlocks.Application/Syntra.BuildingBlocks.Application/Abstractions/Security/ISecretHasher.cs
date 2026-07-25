namespace Syntra.BuildingBlocks.Application.Abstractions.Security
{
    public interface ISecretHasher
    {
        string Hash(string secret);
        bool Verify(string secret, string storedHash);
    }
}
