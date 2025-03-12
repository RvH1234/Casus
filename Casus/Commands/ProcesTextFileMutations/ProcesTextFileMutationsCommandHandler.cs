using Casus.Commands.AddText;
using Casus.Dtos;
using Casus.Results;
using Casus.Services;
using MediatR;
using IResult = Casus.Results.IResult;

namespace Casus.Commands.ProcesTextFileMutations
{
    /// <summary>
    /// Handles the <see cref="ProcesTextFileMutationsCommand"/> />
    /// </summary>
    public class ProcesTextFileMutationsCommandHandler : IRequestHandler<ProcesTextFileMutationsCommand, IResult<FileMutationResponseDto>>
    {
        private readonly IMediator _mediator;
        private readonly ITimeStampService _timeStampService;
        private readonly IRandomTextService _randomTextService;

        public ProcesTextFileMutationsCommandHandler(IMediator mediator, ITimeStampService timeStampService, IRandomTextService randomTextService)
        {
            _mediator = mediator;
            _timeStampService = timeStampService;
            _randomTextService = randomTextService;
        }

        /// <summary>
        /// Handles the processing of text file mutations bij adding a timestamp and a random text
        /// </summary>
        /// <param name="request">The command containing the file stream and metadata.</param>
        /// <param name="cancellationToken">Token for cancelling the asynchronous operation.</param>
        /// <returns>A <see cref="IResult"/> containing a <see cref="FileMutationResponseDto"/> with the mutated file stream or an error message.</returns>

        public async Task<IResult<FileMutationResponseDto>> Handle(ProcesTextFileMutationsCommand request, CancellationToken cancellationToken)
        {
            if (request.ContentType != "text/plain")
            {
                return Result<FileMutationResponseDto>.Failure($"Files of type '{request.ContentType}' are not supported");
            }

            try
            {
                MemoryStream stream = request.MemStream;
                stream.Position = 0;

                List<IRequest> mutations = new List<IRequest>
                {
                    new AddTextCommand(stream,_randomTextService.ToString()),
                    new AddTextCommand(stream,_timeStampService.ToString())
                };

                foreach (var mut in mutations)
                {
                    await _mediator.Send(mut);
                }
                   
                return Result<FileMutationResponseDto>.Success(new FileMutationResponseDto(stream.ToArray(), request.FileName));
            }
            catch (Exception ex)
            {
                return Result<FileMutationResponseDto>.Failure($"An error occurred: {ex.Message}");
            }



        }
    }
}
