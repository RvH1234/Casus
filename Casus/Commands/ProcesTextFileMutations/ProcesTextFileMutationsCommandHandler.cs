using Casus.Results;
using MediatR;
using IResult = Casus.Results.IResult;

namespace Casus.Commands.ProcesTextFileMutations
{
    /// <summary>
    /// Handles the <see cref="ProcesTextFileMutationsCommand"/> by executing each command in the mutations command list/>
    /// </summary>
    public class ProcesTextFileMutationsCommandHandler : IRequestHandler<ProcesTextFileMutationsCommand,IResult>
    {
        private readonly IMediator _mediator;

        public ProcesTextFileMutationsCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Processes each command in the <see cref="ProcesTextFileMutationsCommand"/> <cref >  
        /// </summary>
        /// <param name="request">Command containing the list of commands to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns>an <see cref="IResult"/> </returns>
        public async Task<IResult> Handle(ProcesTextFileMutationsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var mut in request.Mutations)
                {
                    await _mediator.Send(mut, cancellationToken);
                }

                return Result.Success();
            }
            catch (Exception ex)
            {

                return Result.Failure($"Error processing file: {ex.Message}");
            }
           

        }
    }
}
