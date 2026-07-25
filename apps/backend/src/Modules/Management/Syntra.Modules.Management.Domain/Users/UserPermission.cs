using Syntra.SharedKernel.Domain;
using Syntra.SharedKernel.Abstractions;

namespace Syntra.Modules.Management.Domain.Users
{
    public sealed class UserPermission : AuditableEntity, ISoftDeleted
    {
        public Guid UserId { get; private set; }
        public Guid RoleId { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTimeOffset? DeletedAt { get; private set; }

        public UserPermission() { }

        public UserPermission(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
