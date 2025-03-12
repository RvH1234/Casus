using Casus.Dtos;
using Casus.Results;
using MediatR;
using System.Runtime.CompilerServices;
using IResult = Casus.Results.IResult;

namespace Casus.Commands.ProcesTextFileMutations
{


    /// <summary>
    /// Command for processing MemoryStream by preforming mutations 
    /// </summary>
    /// <param name="MemStream">MemoryStream to be processed bij command</param>
    /// <param name="ContentType">ContentType of file represented by <see cref="MemStream"/> </param>
    /// <param name="FileName">FileName</param>
    public record ProcesTextFileMutationsCommand(MemoryStream MemStream, string ContentType, string FileName ):IRequest<IResult<FileMutationResponseDto>>;

}
