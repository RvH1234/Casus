namespace Casus.Results
{
    /// <summary>
    /// Used for indicating a succeeded or failed result with ErrorMessage
    /// </summary>
    public class Result : IResult
    {
        public bool Succeeded { get; protected set; }
        public string? ErrorMessage { get;protected set; }

        /// <summary>
        /// Indicating successfull result
        /// </summary>
        /// <returns>A succeeded <see cref="IResult"/></returns>
        public static Result Success() => new Result { Succeeded = true };


        /// <summary>
        /// Indicating as failed result
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        /// <returns>A failed result <see cref="IResult"/> with ErrorMessage</returns>
        public static Result Failure(string errorMessage) => new Result { Succeeded = false, ErrorMessage = errorMessage };
    }

    /// <summary>
    /// Represents a result with a value indicating success or failure and an optional error message.
    /// </summary>
    /// <typeparam name="T">The type of the value returned in case of success.</typeparam>
    public class Result<T> : Result, IResult<T>
    {
        /// <summary>
        /// Gets the value if the operation succeeded.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Indicating successfull result with a value
        /// </summary>
        /// <param name="value">Concret value of type T</param>
        /// <returns>A success result <see cref="Result"/> of <typeparamref name="T"/> with concrete value of <typeparamref name="T"/></returns>
        public static Result<T> Success(T value) => new Result<T> { Succeeded = true, Value = value };

        /// <summary>
        /// Indicating failed result
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        /// <returns>A failed result <see cref="Result"/> of <typeparamref name="T"/> with error message</returns>
        public static new Result<T> Failure(string errorMessage) => new Result<T> { Succeeded = false, ErrorMessage = errorMessage };
    }
}
