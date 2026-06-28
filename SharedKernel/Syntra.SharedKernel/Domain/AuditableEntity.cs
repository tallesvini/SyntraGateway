namespace Syntra.SharedKernel.Domain
{
    public abstract class AuditableEntity : Entity
    {
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
