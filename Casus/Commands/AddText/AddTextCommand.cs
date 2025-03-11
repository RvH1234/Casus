using Casus.Services;
using MediatR;

namespace Casus.Commands.AddText
{
    /// <summary>
    /// Command to add text to an existing file content.
    /// </summary>
    /// <param name="FileStateService">The service managing the file's state.</param>
    /// <param name="TextToAdd">The text that needs to be added.</param>
    public record AddTextCommand (IFileStateContainerService FileStateService, string TextToAdd ) : IRequest;

}
