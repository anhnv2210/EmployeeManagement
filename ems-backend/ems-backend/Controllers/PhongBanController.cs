using ems_backend.Models.RequestModel.PhongBanRequest;
using ems_backend.Models.ResponseModels.DataPhongBan;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongBanController : ControllerBase
    {
        private readonly IPhongBanService _service;
        public PhongBanController(IPhongBanService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponsePhongBan>>> LayDanhSachPhongBan()
        {
            return Ok(await _service.LayTatCaPhongBan());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponsePhongBan>> GetPhongBan(int id)
        {
            var phongBan = await _service.LayPhongBanTheoId(id);
            if (phongBan == null)
            {
                return NotFound();
            }
            return Ok(phongBan);
        }
        [HttpPost]
        public async Task<IActionResult> ThemPhongBan([FromBody] Request_ThemPhongBan request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exists = await _service.CheckTenPhongBanExists(request.TenPhongBan);
            if (exists)
            {
                return Conflict("Tên phòng ban đã tồn tại.");
            }
            var phongBan = await _service.ThemPhongBan(request);
            return CreatedAtAction(nameof(GetPhongBan), new { id = phongBan.Id }, phongBan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaPhongBan(int id, Request_SuaPhongBan request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaPhongBan(id, request);
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
        public async Task<IActionResult> XoaPhongBan(int id)
        {
            var result = await _service.XoaPhongBan(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
        [HttpGet("check-ten")]
        public async Task<IActionResult> CheckTenPhongBan([FromQuery] string tenPhongBan)
        {
            var exists = await _service.CheckTenPhongBanExists(tenPhongBan);
            return Ok(new { exists });
        }
    }
}
