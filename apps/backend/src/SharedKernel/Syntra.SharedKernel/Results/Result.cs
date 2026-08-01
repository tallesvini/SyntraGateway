namespace Syntra.SharedKernel.Results
{
    public class Result
    {
        public bool IsSuccess { get; }
        public ResultError Error { get; }

        protected Result(bool isSuccess, ResultError error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, ResultError.None);
        public static Result Failure(ResultError error) => new(false, error);

        public static implicit operator Result(ResultError error) => Failure(error);

        public static Result<TValue> Success<TValue>(TValue value) => new(value, true, ResultError.None);
        public static Result<TValue> Failure<TValue>(ResultError error) => new(default, false, error);
    }

    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        protected internal Result(TValue? value, bool isSuccess, ResultError error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        public TValue Value => IsSuccess ? _value! :
            throw new InvalidOperationException("The value of a failure result can't be accessed.");

        public static implicit operator Result<TValue>(ResultError error)
            => Failure<TValue>(error);

        public static implicit operator Result<TValue>(TValue? value) => value is not null
            ? Success(value)
            : Failure<TValue>(ResultError.None);
    }
}
