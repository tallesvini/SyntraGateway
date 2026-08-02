using Syntra.SharedKernel.Results;

namespace Syntra.Modules.Authentication.Domain.ApiSessions
{
    public static class ApiSessionError
    {
        public static readonly ResultError InvalidJti =
            new(
                "ApiSession.InvalidJti",
                "JTI must not be empty.", 
                ResultErrorType.Validation);

        public static readonly ResultError InvalidClientId =
            new(
                "ApiSession.InvalidClientId",
                "ClientId is invalid or cannot be empty.",
                ResultErrorType.Validation);

        public static readonly ResultError InvalidExpirationDate =
            new(
                "ApiSession.InvalidExpirationDate",
                "ExpirationDate is invalid.",
                ResultErrorType.Validation);
    }
}
