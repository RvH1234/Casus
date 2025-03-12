using MediatR;


namespace Casus.Commands.AddText
{
    /// <summary>
    /// Command to add text to MemoryStream
    /// </summary>
    /// <param name="MemStream">MemoryStream</param>
    /// <param name="TextToAdd">Text to add to MemStream</param>
    public record AddTextCommand (MemoryStream MemStream, string TextToAdd ) : IRequest;
}
