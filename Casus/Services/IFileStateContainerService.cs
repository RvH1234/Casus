namespace Casus.Services
{
    /// <summary>
    /// Defines the contract for a file state container service including file name, content type, and content data
    /// </summary>
    public interface IFileStateContainerService
    {
        string ContentType { get; set; }
        byte[] FileContent { get; set; }
        string FileName { get; set; }
    }
}