using Casus.Results;
using MediatR;
using IResult = Casus.Results.IResult;

namespace Casus.Commands.ProcesTextFileMutations
{
    /// <summary>
    /// Command to proces the commands in the list of mutations
    /// </summary>
    /// <param name="Mutations">List commands to execute</param>
    public record ProcesTextFileMutationsCommand(List<IRequest> Mutations):IRequest<IResult>;
   
}
