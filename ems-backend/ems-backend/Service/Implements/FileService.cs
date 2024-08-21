using ems_backend.Service.Interfaces;

namespace ems_backend.Service.Implements
{
    public class FileService : IFileService
    {
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    throw new ArgumentException("No file uploaded");

                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                if (!Directory.Exists(uploadsFolderPath))
                    Directory.CreateDirectory(uploadsFolderPath);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsFolderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return Path.Combine("uploads", fileName);
            }
            catch (Exception ex)
            {
                // Log lỗi để kiểm tra chi tiết
                return $"Internal server error: {ex.Message}";
            }
        }
    }
}
