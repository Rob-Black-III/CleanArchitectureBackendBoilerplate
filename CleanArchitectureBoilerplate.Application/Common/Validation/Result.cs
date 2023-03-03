using System.Diagnostics.Contracts;

namespace CleanArchitectureBoilerplate.Application.Common.Validation
{
    public static class ResultFactory
    {
        public static Result<TValue> From<TValue>(TValue value)
        {
            return value;
        }
    }

    public static class Result
    {
        public static Result<TValue> From<TValue>(TValue value)
        {
            return value;
        }
    }

    public readonly record struct Result<TValue>
    {
        private readonly bool isSuccessful = false;
        public readonly TValue Value;
        
        public readonly Error Error;

        // Public Getters, extracted away from internal data
        [Pure]
        public bool IsSuccessful => isSuccessful == true;
        [Pure]
        public bool IsFaulted => isSuccessful == false;

        public Result(TValue value)
        {
            Value = value;
            isSuccessful = true;
        }

        public Result(Error error)
        {
            Error = error;
            isSuccessful = false;
        }

        // Implicit conversion operators for return types.
        [Pure]
        public static implicit operator Result<TValue>(TValue value) => new Result<TValue>(value);

        [Pure]
        public static implicit operator Result<TValue>(Error error) => new Result<TValue>(error);

        public void Switch(Action<TValue> onValue, Action<Error> onError)
        {
            if (IsFaulted)
            {
                onError(Error);
                return;
            }

            onValue(Value);
        }

        public async Task SwitchAsync(Func<TValue, Task> onValue, Func<Error, Task> onError)
        {
            if (IsFaulted)
            {
                await onError(Error).ConfigureAwait(false);
                return;
            }

            await onValue(Value).ConfigureAwait(false);
        }

        public TResult Match<TResult>(Func<TValue, TResult> onValue, Func<Error, TResult> onError)
        {
            if (IsFaulted)
            {
                return onError(Error);
            }

            return onValue(Value);
        }

        public async Task<TResult> MatchAsync<TResult>(Func<TValue, Task<TResult>> onValue, Func<Error, Task<TResult>> onError)
        {
            if (IsFaulted)
            {
                return await onError(Error).ConfigureAwait(false);
            }

            return await onValue(Value).ConfigureAwait(false);
        }
    }
}