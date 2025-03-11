namespace Casus.Results
{
    /// <summary>
    /// Contract for indicating a result
    /// </summary>
    public interface IResult
    {
        string? ErrorMessage { get; set; }
        bool Succeeded { get; set; }
    }
}