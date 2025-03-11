

using Casus.Results;

namespace Casus.Services
{
    /// <summary>
    /// Defines the contract for a service that modifies files using mutations.
    /// </summary>
    public interface IModifierService
    {
        /// <summary>
        /// Modifies the given file state service if it is a plain text file by applying predefined mutations.
        /// </summary>
        /// <param name="fileStateService">The file state containing the filecontent to modify.</param>
        /// <returns>An <see cref="IResult"/> indicating the success or failure of the operation.</returns>
        Task<Results.IResult> ModifyAsync(IFileStateContainerService fileStateService);
    }
}