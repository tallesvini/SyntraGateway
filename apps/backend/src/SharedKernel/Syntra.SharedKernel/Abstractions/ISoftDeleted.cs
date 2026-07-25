namespace Syntra.SharedKernel.Abstractions
{
    public interface ISoftDeleted
    {
        bool IsDeleted { get; }
        DateTimeOffset? DeletedAt { get; }
    }
}
