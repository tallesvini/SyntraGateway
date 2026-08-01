namespace Syntra.SharedKernel.Domain
{
    public abstract class AuditableEntity : Entity
    {
        public DateTimeOffset CreatedAt { get; protected set; }
        public Guid CreatedBy { get; protected set; }
        public DateTimeOffset? UpdatedAt { get; protected set; }
        public Guid? UpdatedBy { get; protected set; }
    }
}
