using Syntra.Modules.Authentication.Domain.Common;
using Syntra.SharedKernel.Domain;

namespace Syntra.Modules.Authentication.Domain.RefreshToken
{
    public sealed class RefreshToken : StatusEntity
    {
        public Guid ApiSessionId { get; private set; }
        public string HashToken { get; private set; }
        public int ExpiresIn { get; private set; }
        public DateTimeOffset ExpiresAt { get; private set; }
        public TokenStatus TokenStatus { get; private set; }
        public DateTimeOffset? RevokedAt { get; set; }
    }
}
