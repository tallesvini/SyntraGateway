using Syntra.SharedKernel.Results;

namespace Syntra.SharedKernel.Guards
{
    public static class GuidGuard
    {
        public static Result NotEmpty(Guid value, ResultError error)
        {
            if (value == Guid.Empty) return error;

            return Result.Success(value);
        }
    }
}
