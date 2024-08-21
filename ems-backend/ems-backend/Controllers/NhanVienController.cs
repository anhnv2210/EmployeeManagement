using ems_backend.Models.RequestModel.NhanVienRequest;
using ems_backend.Models.ResponseModels.DataNhanVien;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NhanVienController : ControllerBase
    {
        //private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
        private readonly INhanVienService _service;
        public NhanVienController(INhanVienService service)
        {
            _service = service;
            //if (!Directory.Exists(_storagePath))
            //{
            //    Directory.CreateDirectory(_storagePath);
            //}
        }
        [HttpGet]
        public async Task<IActionResult> LayDanhSachChucDanh(string? trangThai, int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _service.LayTatCaNhanVien(trangThai,pageSize, pageNumber));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseNhanVien>> GetNhanVien(int id)
        {
            var nhanVien = await _service.LayNhanVienTheoId(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            return Ok(nhanVien);
        }
        [HttpPost]
        public async Task<IActionResult> ThemNhanVien([FromForm] Request_ThemNhanVien request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existsEmail = await _service.CheckEmailExists(request.Email);
            if (!existsEmail)
            {
                return Conflict("Email của nhân viên đã tồn tại.");
            }
            var existsSDT = await _service.CheckSoDienThoaiExists(request.SoDienThoai);
            if (!existsSDT)
            {
                return Conflict("Số điện thoại của nhân viên đã tồn tại.");
            }
            var result = await _service.ThemNhanVien(request);
            return CreatedAtAction(nameof(GetNhanVien), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaNhanVien(int id, [FromForm] Request_SuaNhanVien request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existsEmail = await _service.CheckEmailExists(request.Email);
                if (existsEmail)
                {
                    return Conflict("Email của nhân viên đã tồn tại.");
                }
                var existsSDT = await _service.CheckSoDienThoaiExists(request.SoDienThoai);
                if (existsSDT)
                {
                    return Conflict("Số điện thoại của nhân viên đã tồn tại.");
                }
                var result = await _service.SuaNhanVien(id, request);
                if (result == null)
                {
                    return StatusCode(500, "A problem happened while handling your request.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }
        [HttpGet("check-email")]
        public async Task<IActionResult> CheckEmail([FromQuery] string email)
        {
            var exists = await _service.CheckEmailExists(email);
            return Ok(new { exists });
        }
        [HttpGet("check-sodienthoai")]
        public async Task<IActionResult> CheckSoDienThoai([FromQuery] string soDienThoai)
        {
            var exists = await _service.CheckSoDienThoaiExists(soDienThoai);
            return Ok(new { exists });
        }
        
    }
    
}
