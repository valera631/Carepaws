using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarePaws.Domain.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public string Error { get; private set; }
        public T Value { get; private set; }

        private Result(bool isSuccess, string error, T value)
        {
            IsSuccess = isSuccess;
            Error = error;
            Value = value;
        }

        public static Result<T> Success(T value) => new(true, string.Empty, value);
        public static Result<T> Failure(string error) => new(false, error, default);
    }
}
