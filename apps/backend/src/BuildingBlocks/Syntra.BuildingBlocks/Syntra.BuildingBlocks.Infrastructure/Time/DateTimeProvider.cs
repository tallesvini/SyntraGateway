using Syntra.SharedKernel.Abstractions;

namespace Syntra.BuildingBlocks.Infrastructure.Time
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}
