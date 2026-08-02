using Syntra.SharedKernel.Domain;
using Syntra.SharedKernel.Results;
using Syntra.Modules.Authentication.Domain.Common;
using Syntra.Modules.Authentication.Domain.ApiSessions.ValueObjects;

namespace Syntra.Modules.Authentication.Domain.ApiSessions
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
        public Guid? RevokedBy { get; private set; }

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

        public static Result<ApiSession> Create(Guid clientId, Guid jti, DateTimeOffset createdAt, DateTimeOffset expiresAt, ApiSessionOrigin? origin = null)
        {
            if (expiresAt <= createdAt)
                return ApiSessionError.InvalidExpirationDate;

            var apiSessionClientResult = ApiSessionClientId.Create(clientId); 
            if (!apiSessionClientResult.IsSuccess) 
                return apiSessionClientResult.Error;

            var jtiResult = ApiSessionJti.Create(jti);
            if (!jtiResult.IsSuccess) 
                return ApiSessionError.InvalidJti;

            return new ApiSession(apiSessionClientResult.Value, jtiResult.Value, createdAt, expiresAt, origin);
        }

        public bool IsExpired(DateTimeOffset now) =>
            ExpiresAt <= now;

        public void Revoke(DateTimeOffset revokedAt, Guid revokedBy)
        {
            if (TokenStatus == TokenStatus.Revoked) return;

            TokenStatus = TokenStatus.Revoked;
            RevokedAt = revokedAt;
            RevokedBy = revokedBy;
        }

        public void RegisterAccess(DateTimeOffset accessedAt)
        {
            LastAccessAt = accessedAt;
        }
    }
}
