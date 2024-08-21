using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public UploadFileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                var filePath = await _fileService.UploadFileAsync(file);
                return Ok(new { FilePath = filePath });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
