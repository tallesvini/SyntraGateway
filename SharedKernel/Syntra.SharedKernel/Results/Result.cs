namespace Syntra.SharedKernel.Results
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }

        protected Result(bool isSuccess, string? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result<TValue> Success<TValue>(TValue value) => new(value, true, string.Empty);
        public static Result<TValue> Failure<TValue>(string error) => new(default, false, error);
    }

    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        protected internal Result(TValue? value, bool isSuccess, string error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        public TValue Value => IsSuccess ?
            _value! :
            throw new InvalidOperationException("The value of a failure result can't be accessed.");

        public static implicit operator Result<TValue>(TValue? value) =>
            value is not null
                ? Success(value)
                : Failure<TValue>("Value cannot be null.");
    }
}
