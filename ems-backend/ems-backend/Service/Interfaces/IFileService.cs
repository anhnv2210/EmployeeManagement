namespace ems_backend.Service.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file);
    }
}
