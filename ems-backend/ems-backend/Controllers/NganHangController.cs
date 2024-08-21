using ems_backend.Models.RequestModel.NganHangRequest;
using ems_backend.Models.ResponseModels.DataNganHang;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NganHangController : ControllerBase
    {
        private readonly INganHangService _service;
        public NganHangController(INganHangService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponseNganHang>>> LayDanhSachNganHang(bool? isActive, int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _service.LayTatCaNganHang(isActive, pageSize, pageNumber));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseNganHang>> GetNganHang(int id)
        {
            var nganHang = await _service.LayNganHangTheoId(id);
            if (nganHang == null)
            {
                return NotFound();
            }
            return Ok(nganHang);
        }
        [HttpPost]
        public async Task<IActionResult> ThemNganHang([FromBody] Request_ThemNganHang request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existsTen = await _service.CheckTenNganHangExists(request.TenNganHang);
            if (existsTen)
            {
                return Conflict("Tên ngân hàng đã tồn tại.");
            }
            var existsEmail = await _service.CheckEmailExists(request.Email);
            if (existsEmail)
            {
                return Conflict("Email của ngân hàng đã tồn tại.");
            }
            var existsSDT = await _service.CheckSoDienThoaiExists(request.SDT);
            if (existsSDT)
            {
                return Conflict("Số điện thoại của ngân hàng đã tồn tại.");
            }
            var nganHang = await _service.ThemNganHang(request);
            return CreatedAtAction(nameof(GetNganHang), new { id = nganHang.Id }, nganHang);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaNganHang(int id, Request_SuaNganHang request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaNganHang(id, request);
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
        public async Task<IActionResult> XoaNganHang(int id)
        {
            var result = await _service.XoaNganHang(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
        [HttpGet("check-ten")]
        public async Task<IActionResult> CheckTenNganHang([FromQuery] string tenNganHang)
        {
            var exists = await _service.CheckTenNganHangExists(tenNganHang);
            return Ok(new { exists });
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
