using Casus.Commands.ProcesTextFileMutations;

namespace Casus.Dtos
{
    /// <summary>
    /// Dto for response of the <see cref="ProcesTextFileMutationsCommandHandler" /> 
    /// </summary>
    /// <param name="FileContent">FileContent</param>
    /// <param name="FileName">FileName</param>
    public record FileMutationResponseDto(byte[] FileContent,  string FileName);
}
