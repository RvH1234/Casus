using Casus.Commands.AddText;
using Casus.Commands.ProcesTextFileMutations;
using Casus.Results;
using MediatR;

namespace Casus.Services
{
    /// <summary>
    /// Service responsible for modifying text files using a series of mutations.
    /// </summary>
    public class ModifierService : IModifierService
    {
        private readonly IMediator _mediator;
        public ModifierService(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Modifies the given file state service if it is a plain text file by applying predefined mutations.
        /// </summary>
        /// <param name="fileStateService">The file state service containing the file to modify.</param>
        /// <returns>An <see cref="IResult"/> indicating the success or failure of the operation.</returns>
        public async Task<Results.IResult> ModifyAsync(IFileStateContainerService fileStateService)
        {
            if (fileStateService.ContentType == "text/plain")
            {
                List<IRequest> mutations = new List<IRequest>
                {
                    new AddTextCommand(fileStateService,StringGenerator.CreateRandomString(10)),
                    new AddTextCommand(fileStateService,StringGenerator.CreateTimeStamp()),
                };

                var result = await _mediator.Send(new ProcesTextFileMutationsCommand(mutations));

                if (result.Succeeded)
                {
                    fileStateService.FileName = $"modified_{fileStateService.FileName}";
                }

                return result;
            }
            else
            {
                return Result.Failure($"Files of type '{fileStateService.ContentType}' are not supported");
            }
        }
    }
}
