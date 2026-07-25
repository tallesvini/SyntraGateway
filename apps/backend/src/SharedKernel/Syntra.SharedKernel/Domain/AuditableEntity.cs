namespace Syntra.SharedKernel.Domain
{
    public abstract class AuditableEntity : Entity
    {
        public DateTime CreatedAt { get; protected set; }
        public Guid CreatedBy { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
        public Guid? UpdatedBy { get; protected set; }
    }
}
