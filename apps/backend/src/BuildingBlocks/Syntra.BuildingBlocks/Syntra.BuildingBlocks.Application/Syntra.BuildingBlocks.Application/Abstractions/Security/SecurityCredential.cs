namespace Syntra.BuildingBlocks.Application.Abstractions.Security
{
    public sealed record SecurityCredential(string ClientId, string ClientSecret, string SecretHash);
}
