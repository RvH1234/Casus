using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using System.Runtime.InteropServices;

namespace Casus.Services
{
    /// <summary>
    /// Represents a container for file state, including file name, content type, and content data.
    /// This service is used to handle file data in memory. 
    /// Instance can only be created via static Create function
    /// </summary>
    public class FileStateContainerService : IFileStateContainerService
    {
        private FileStateContainerService()
        {
        }
  
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[] FileContent { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// Creates an instance of <see cref="FileStateContainerService"/> from an <see cref="IFormFile"/>.
        /// </summary>
        /// <param name="formFile">The uploaded file.</param>
        /// <returns>A new instance of <see cref="FileStateContainerService"/> populated with file data.</returns>
        public static FileStateContainerService Create(IFormFile formFile)
        {
            var stream = new MemoryStream();
            formFile.CopyTo(stream);
  
            return
                 new FileStateContainerService
                 {
                     ContentType = formFile.ContentType,
                     FileContent = stream.ToArray(),
                     FileName = GetFileNameFromContentDisposition(formFile)
                 };

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
