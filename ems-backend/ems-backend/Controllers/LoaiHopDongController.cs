using ems_backend.Models.RequestModel.LoaiHopDongRequest;
using ems_backend.Models.ResponseModels.DataLoaiHopDong;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiHopDongController : ControllerBase
    {
        private ILoaiHopDongService _service;
        public LoaiHopDongController(ILoaiHopDongService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponseLoaiHopDong>>> LayDanhSachLoaiHopDong()
        {
            return Ok(await _service.LayTatCaLoaiHopDong());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseLoaiHopDong>> GetLoaiHopDong(int id)
        {
            var loaiHopDong = await _service.LayLoaiHopDongTheoId(id);
            if (loaiHopDong == null)
            {
                return NotFound();
            }
            return Ok(loaiHopDong);
        }
        [HttpPost]
        public async Task<IActionResult> ThemLoaiHopDong([FromBody] Request_ThemLoaiHopDong request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exists = await _service.CheckTenLoaiHopDongExists(request.TenLoaiHopDong);
            if (exists)
            {
                return Conflict("Tên loại hợp đồng đã tồn tại.");
            }
            var loaiHopDong = await _service.ThemLoaiHopDong(request);
            return CreatedAtAction(nameof(GetLoaiHopDong), new { id = loaiHopDong.Id }, loaiHopDong);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaLoaiHopDong(int id, Request_SuaLoaiHopDong request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaLoaiHopDong(id, request);
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
        public async Task<IActionResult> XoaLoaiHopDong(int id)
        {
            var result = await _service.XoaLoaiHopDong(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
        [HttpGet("check-ten")]
        public async Task<IActionResult> CheckTenLoaiHopDong([FromQuery] string tenLoaiHopDong)
        {
            var exists = await _service.CheckTenLoaiHopDongExists(tenLoaiHopDong);
            return Ok(new { exists });
        }
    }
}
