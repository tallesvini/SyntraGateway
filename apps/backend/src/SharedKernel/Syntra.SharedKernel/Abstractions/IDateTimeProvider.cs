namespace Syntra.SharedKernel.Abstractions
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
