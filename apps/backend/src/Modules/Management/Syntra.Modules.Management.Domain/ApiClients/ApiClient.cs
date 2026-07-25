using Syntra.SharedKernel.Domain;
using Syntra.SharedKernel.Results;
using Syntra.SharedKernel.Abstractions;
using Syntra.Modules.Management.Domain.ApiClients.ValueObjects;

namespace Syntra.Modules.Management.Domain.ApiClients
{
    public sealed class ApiClient : StatusEntity, ISoftDeleted
    {
        public ApiClientName Name { get; private set; }
        public ApiClientDescription Description { get; private set; }
        public ApiClientCredential Credential { get; private set; }
        public ApiClientType Type { get; private set; }
        public ApiClientRoleType RoleType { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTimeOffset? DeletedAt {  get; private set; }

        private ApiClient() { }

        private ApiClient(ApiClientName name, ApiClientDescription description, ApiClientCredential credential)
        {
            Name = name;
            Description = description;
            Credential = credential;
            Type = ApiClientType.Internal;
            RoleType = ApiClientRoleType.Administrator;
        }

        public static Result<ApiClient> Create(string name, string description, string clientId, string clientSecret)
        {
            var nameResult = ApiClientName.Create(name);
            if (!nameResult.IsSuccess) return nameResult.Error;

            var descriptionResult = ApiClientDescription.Create(description);
            if (!descriptionResult.IsSuccess) return descriptionResult.Error;

            var credentialResult = ApiClientCredential.Create(clientId, clientSecret);
            if (!credentialResult.IsSuccess) return credentialResult.Error;

            return new ApiClient(nameResult.Value, descriptionResult.Value, credentialResult.Value);
        }
    }
}
