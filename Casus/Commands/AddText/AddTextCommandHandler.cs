using Casus.Results;
using MediatR;
using System.IO;
using System.Text;


namespace Casus.Commands.AddText
{
    /// <summary>
    /// Handles the <see cref="AddTextCommand"/> by appending text to the memorystream.
    /// </summary>
    public class AddTextCommandHandler : IRequestHandler<AddTextCommand>
    {
        /// <summary>
        /// Processes the <see cref="AddTextCommand"/> and adds text to memorystream.
        /// </summary>
        /// <param name="request">The <see cref="AddTextCommand"/> containing the memorystream and text to add.</param>
        /// <param name="cancellationToken"></param>
        public async Task Handle(AddTextCommand request, CancellationToken cancellationToken)
        {
            var memStream = request.MemStream;
            memStream.Seek(0, SeekOrigin.End);
            using (var writer = new StreamWriter(memStream, Encoding.UTF8, leaveOpen: true))
            {
                await writer.WriteAsync(Environment.NewLine + request.TextToAdd);
                await writer.FlushAsync();
            }
            memStream.Position = 0;
        }
    }
}
