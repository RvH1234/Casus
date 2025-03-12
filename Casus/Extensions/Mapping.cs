using Casus.Commands.ProcesTextFileMutations;
using System.Net.Mime;

namespace Casus.Extensions
{
    public class Mapping
    {
        /// <summary>
        /// Maps <see cref="IFormFile"/>  to <see cref="ProcesTextFileMutationsCommand"/> 
        /// </summary>
        /// <param name="formFile">FormFile to map</param>
        /// <returns></returns>
        public static async Task<ProcesTextFileMutationsCommand> MapToCommandAsync(IFormFile formFile)
        {
            var stream = new MemoryStream();
            await formFile.CopyToAsync(stream);
            stream.Position = 0;

            return new ProcesTextFileMutationsCommand(stream, formFile.ContentType, GetFileNameFromContentDisposition(formFile));
        }


        /// <summary>
        /// Extracts the original filename from the Content-Disposition header.
        /// If unavailable, the default filename from <see cref="IFormFile"/> is returned.
        /// </summary>
        /// <param name="formFile">The uploaded file.</param>
        /// <returns>The extracted filename as a string.</returns>
        private static string GetFileNameFromContentDisposition(IFormFile formFile)
        {
            ContentDisposition contentDisposition = new ContentDisposition(formFile.ContentDisposition);
            string fileName = contentDisposition.FileName ?? formFile.FileName;
            return fileName;
        }

    }
}
