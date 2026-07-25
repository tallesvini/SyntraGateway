using Syntra.SharedKernel.Enums;

namespace Syntra.SharedKernel.Domain
{
    public abstract class StatusEntity : AuditableEntity
    {
        public Status Status { get; protected set; }
    }
}
