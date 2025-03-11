namespace Casus.Results
{
    /// <summary>
    /// Used for indicating a succeeded or failed result with ErrorMessage
    /// </summary>
    public class Result : IResult
    {
        public bool Succeeded { get; set; }
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// To indicate successfull result
        /// </summary>
        /// <returns>A succeeded <see cref="IResult"/></returns>
        public static Result Success() => new Result { Succeeded = true };


        /// <summary>
        /// To indicate as failed result
        /// </summary>
        /// <param name="error">Error message</param>
        /// <returns>A succeeded <see cref="IResult"/> with ErrorMessage</returns>
        public static Result Failure(string error) => new Result { Succeeded = false, ErrorMessage = error };
    }
}
