using MediatR;
using System.Text;


namespace Casus.Commands.AddText
{
    /// <summary>
    /// Handles the <see cref="AddTextCommand"/> by prepending text to the file content.
    /// </summary>
    public class AddTextCommandHandler : IRequestHandler<AddTextCommand>
    {
        /// <summary>
        /// Processes the <see cref="AddTextCommand"/> and modifies the file content.
        /// </summary>
        /// <param name="request">The command containing the file state and text to add.</param>
        /// <param name="cancellationToken"></param>
        public Task Handle(AddTextCommand request, CancellationToken cancellationToken)
        {
            var textToAddBytes = Encoding.UTF8.GetBytes(request.TextToAdd + Environment.NewLine);
            var updatedBytes = textToAddBytes.Concat(request.FileStateService.FileContent).ToArray();

            request.FileStateService.FileContent = updatedBytes;
            return Task.CompletedTask;

        
        }
    }
}
