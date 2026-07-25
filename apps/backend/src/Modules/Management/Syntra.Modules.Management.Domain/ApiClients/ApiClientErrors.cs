using Syntra.SharedKernel.Results;

namespace Syntra.Modules.Management.Domain.ApiClients
{
    public static class ApiClientErrors
    {
        public static readonly ResultError NameRequired =
            new(
                "ApiClient.NameRequired",
                "Name is required.",
                ResultErrorType.Validation);

        public static readonly ResultError PasswordRequired =
            new(
                "ApiClient.DescriptionRequired",
                "Description is required.",
                ResultErrorType.Validation);

        public static readonly ResultError NameTooLong =
            new(
                "ApiClient.NameTooLong",
                "Name must not exceed 128 characters.",
                ResultErrorType.Validation);

        public static ResultError NotFound(string fieldName) 
            => new ("ApiClient.NotFound", $"The '{fieldName}' field was not found.", ResultErrorType.NotFound);
    }
}
