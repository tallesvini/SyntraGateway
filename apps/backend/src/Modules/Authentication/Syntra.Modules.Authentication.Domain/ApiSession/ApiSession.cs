using Syntra.SharedKernel.Domain;
using Syntra.SharedKernel.Results;
using Syntra.Modules.Authentication.Domain.Common;
using Syntra.Modules.Authentication.Domain.ApiSession.ValueObjects;

namespace Syntra.Modules.Authentication.Domain.ApiSession
{
    public sealed class ApiSession : StatusEntity
    {
        public ApiSessionClientId ApiClientId { get; private set; }
        public ApiSessionJti Jti { get; private set; }
        public ApiSessionOrigin? Origin { get; private set; }
        public TokenStatus TokenStatus { get; private set; }
        public DateTimeOffset ExpiresAt { get; private set; }
        public DateTimeOffset? LastAccessAt { get; private set; }
        public DateTimeOffset? RevokedAt { get; private set; }

        private ApiSession() { }

        private ApiSession(ApiSessionClientId apiClientId, ApiSessionJti jti, DateTimeOffset createdAt, DateTimeOffset expiresAt, ApiSessionOrigin? origin)
        {
            ApiClientId = apiClientId;
            Jti = jti;
            Origin = origin;
            TokenStatus = TokenStatus.Active;
            ExpiresAt = expiresAt;
            CreatedAt = createdAt;
        }

        public static Result<ApiSession> Create(ApiSessionClientId clientId, ApiSessionJti jti, DateTimeOffset createdAt, DateTimeOffset expiresAt, ApiSessionOrigin? origin = null)
        {
            if (expiresAt <= createdAt)
                return ApiSessionError.InvalidExpirationDate;

            return new ApiSession(clientId, jti, createdAt, expiresAt, origin);
        }

        public bool IsExpired(DateTimeOffset now) =>
            ExpiresAt <= now;

        public void Revoke(DateTimeOffset revokedAt)
        {
            if (TokenStatus == TokenStatus.Revoked) return;

            TokenStatus = TokenStatus.Revoked;
            RevokedAt = revokedAt;
        }

        public void RegisterAccess(DateTimeOffset accessedAt)
        {
            LastAccessAt = accessedAt;
        }
    }
}
