using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.ChiNhanhNganHang;
using ems_backend.Models.RequestModel.NganHangRequest;
using ems_backend.Models.ResponseModels.DataChiNhanhNganHang;
using ems_backend.Models.ResponseModels.DataNganHang;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiNhanhNganHangController : ControllerBase
    {
        private readonly IChiNhanhNganHangService _service;
        public ChiNhanhNganHangController(IChiNhanhNganHangService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponseChiNhanhNganHang>>> LayDanhSachChiNhanhNganHang(bool? isActive, int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _service.LayTatCaChiNhanhNganHang(isActive, pageSize, pageNumber));
        }
        [HttpGet("byNganHang/{nganHangId}")]
        public async Task<ActionResult<IEnumerable<QuanHuyen>>> GetChiNhanhNganHangByNganHang(int nganHangId)
        {
            var result = await _service.LayTatCaChiNhanhNganHangByNganHang(nganHangId);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseChiNhanhNganHang>> GetChiNhanhNganHang(int id)
        {
            var nganHang = await _service.LayChiNhanhNganHangTheoId(id);
            if (nganHang == null)
            {
                return NotFound();
            }
            return Ok(nganHang);
        }
        [HttpPost]
        public async Task<IActionResult> ThemChiNhanhNganHang([FromBody] Request_ThemChiNhanhNganHang request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existsEmail = await _service.CheckEmailExists(request.Email);
            if (existsEmail)
            {
                return Conflict("Email của chi nhánh ngân hàng đã tồn tại.");
            }
            var existsSDT = await _service.CheckSoDienThoaiExists(request.SoDienThoai);
            if (existsSDT)
            {
                return Conflict("Số điện thoại của chi nhánh ngân hàng đã tồn tại.");
            }
            var chiNhanhNganHang = await _service.ThemChiNhanhNganHang(request);
            return CreatedAtAction(nameof(GetChiNhanhNganHang), new { id = chiNhanhNganHang.Id }, chiNhanhNganHang);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaChiNhanhNganHang(int id, Request_SuaChiNhanhNganHang request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaChiNhanhNganHang(id, request);
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaChiNhanhNganHang(int id)
        {
            var result = await _service.XoaChiNhanhNganHang(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
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
