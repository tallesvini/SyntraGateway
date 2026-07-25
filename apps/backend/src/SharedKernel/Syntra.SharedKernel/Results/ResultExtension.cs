namespace Syntra.SharedKernel.Results
{
    public static class ResultExtension
    {
        public static Result<T> Tap<T>(
            this Result<T> result, 
            Action<T> action)
        {
            if (result.IsSuccess) action(result.Value!);
            return result;
        }

        public static async Task<Result<T>> Tap<T>(
            this Result<T> result, 
            Func<T, Task> action)
        {
            if (result.IsSuccess) await action(result.Value!);
            return result;
        }

        public static async Task<Result<T>> Tap<T>(
            this Task<Result<T>> resultTask, 
            Func<T, Task> action)
        {
            var result = await resultTask;

            if (result.IsSuccess) await action(result.Value!);
            return result;
        }

        public static Result<TOut> Bind<TIn, TOut>(
            this Result<TIn> result, 
            Func<TIn, Result<TOut>> func)
        {
            if (!result.IsSuccess) return Result.Failure<TOut>(result.Error);
            return func(result.Value!);
        }

        public static async Task<Result<TOut>> Bind<TIn, TOut>(
            this Task<Result<TIn>> resultTask, 
            Func<TIn, Task<Result<TOut>>> func)
        {
            var result = await resultTask;

            if (!result.IsSuccess) return Result.Failure<TOut>(result.Error);
            return await func(result.Value!);
        }

        public static async Task<Result<TOut>> Bind<TIn, TOut>(
            this Task<Result<TIn>> resultTask, 
            Func<TIn, Result<TOut>> func)
        {
            var result = await resultTask;

            if (!result.IsSuccess) return Result.Failure<TOut>(result.Error);
            return func(result.Value!);
        }

        public static async Task<Result<TOut>> Bind<TIn, TOut>(
            this Result<TIn> result,
            Func<TIn, Task<Result<TOut>>> func)
        {
            if (!result.IsSuccess) return Result.Failure<TOut>(result.Error);
            return await func(result.Value);
        }

        public static async Task<Result<TOut>> Map<TIn, TOut>(
            this Task<Result<TIn>> resultTask,
            Func<TIn, TOut> func)
        {
            var result = await resultTask;

            if (!result.IsSuccess) return Result.Failure<TOut>(result.Error);
            return Result.Success(func(result.Value!));
        }
    }
}
