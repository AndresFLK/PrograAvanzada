using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Result
    {
        protected Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None ||
                !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error.", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }

        public Error Error { get; }

        public bool IsFailure => !IsSuccess;

        public static Result Success() => new(true, Error.None);

        public static Result Failure(Error error) => new(false, error);

        public static Result<T> Success<T>(T value) => new Result<T>(true, Error.None, value);

        public static Result<T> Failure<T>(Error error) => new (false, error, default(T));
    }

    public sealed class Result<T> : Result
    {
        internal Result(bool isSuccess, Error error, T value) 
            : base(isSuccess, error)
        {
            Value = value;
        }

        public T Value { get; }
    }
}
