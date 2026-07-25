using Syntra.SharedKernel.Domain;
using Syntra.SharedKernel.Abstractions;

namespace Syntra.Modules.Management.Domain.Users
{
    public sealed class User : StatusEntity, ITenantEntity
    {
        public Guid TenantId { get; private set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public bool IsVerified { get; private set; }

        private User() { }

        public User(Guid tenantId, string name, string username, string email, string passwordHash)
        {
            Name = name;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            IsVerified = false;
        }
    }
}
