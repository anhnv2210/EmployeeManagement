using ems_backend.Models.RequestModel.NoiKhamBenhRequest;
using ems_backend.Models.ResponseModels.DataNoiKhamBenh;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoiKhamBenhController : ControllerBase
    {
        private readonly INoiKhamBenhService _service;
        public NoiKhamBenhController(INoiKhamBenhService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> LayDanhSachNoiKhamBenh(bool? isActive, int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _service.LayTatCaNoiKhamBenh(isActive, pageSize, pageNumber));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseNoiKhamBenh>> GetNoiKhamBenh(int id)
        {
            var nganHang = await _service.LayNoiKhamBenhTheoId(id);
            if (nganHang == null)
            {
                return NotFound();
            }
            return Ok(nganHang);
        }
        [HttpPost]
        public async Task<IActionResult> ThemNganHang([FromBody] Request_ThemNoiKhamBenh request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existsEmail = await _service.CheckEmailExists(request.Email);
            if (existsEmail)
            {
                return Conflict("Email của noi kham benh đã tồn tại.");
            }
            var existsSDT = await _service.CheckSoDienThoaiExists(request.SDT);
            if (existsSDT)
            {
                return Conflict("Số điện thoại của noi kham benh đã tồn tại.");
            }
            var result = await _service.ThemNoiKhamBenh(request);
            return CreatedAtAction(nameof(GetNoiKhamBenh), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaNoiKhamBenh(int id, Request_SuaNoiKhamBenh request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaNoiKhamBenh(id, request);
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
        public async Task<IActionResult> XoaNoiKhamBenh(int id)
        {
            var result = await _service.XoaNoiKhamBenh(id);
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
