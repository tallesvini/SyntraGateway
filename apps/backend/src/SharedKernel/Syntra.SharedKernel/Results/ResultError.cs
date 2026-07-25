namespace Syntra.SharedKernel.Results
{
    public sealed record class ResultError(string Code, string Message, ResultErrorType Type)
    {
        public static ResultError None =
            new(string.Empty, string.Empty, ResultErrorType.None);

        public static ResultError Failure(string code, string message)
            => new(code, message, ResultErrorType.Failure);

        public static ResultError Validation(string code, string message)
            => new(code, message, ResultErrorType.Validation);

        public static ResultError NotFound(string code, string message)
            => new(code, message, ResultErrorType.NotFound);

        public static ResultError Conflict(string code, string message)
            => new(code, message, ResultErrorType.Conflit);

        public static ResultError Unauthorized(string code, string message)
            => new(code, message, ResultErrorType.Unauthorized);

        public static ResultError Forbidden(string code, string message)
            => new(code, message, ResultErrorType.Forbidden);
    }
}
