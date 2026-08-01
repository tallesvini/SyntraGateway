using Syntra.SharedKernel.Domain;
using Syntra.SharedKernel.Results;

namespace Syntra.Modules.Authentication.Domain.ApiSession.ValueObjects
{
    public sealed class ApiSessionOrigin : ValueObject
    {
        public string? IpAddress { get; }
        public string? UserAgent { get; }
        public string? Device { get; }
        public string? OperationSystem { get; }

        public ApiSessionOrigin() { }

        public ApiSessionOrigin(string? ipAddress, string? userAgent, string? device, string? operationSystem)
        {
            IpAddress = ipAddress;
            UserAgent = userAgent;
            Device = device;
            OperationSystem = operationSystem;
        }

        public static Result<ApiSessionOrigin> Create(string? ipAddress, string? userAgent, string? device, string? operationSystem)
        {
            return new ApiSessionOrigin(ipAddress, userAgent, device, operationSystem);
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return IpAddress;
        }
    }
}
