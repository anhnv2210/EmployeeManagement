using ems_backend.Models.RequestModel.HopDongRequest;
using ems_backend.Models.ResponseModels.DataHopDongLaoDong;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HopDongController : ControllerBase
    {
        private readonly IHopDongService _service;
        public HopDongController(IHopDongService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponseHopDong>>> LayDanhSachHopDong(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _service.LayTatCaHopDong(pageSize, pageNumber));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseHopDong>> GetHopDong(int id)
        {
            var result = await _service.LayHopDongTheoId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> ThemHopDong([FromBody] Request_ThemHopDong request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.ThemHopDong(request);
            return CreatedAtAction(nameof(GetHopDong), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaHopDong(int id, Request_SuaHopDong request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaHopDong(id, request);
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
        public async Task<IActionResult> XoaHopDong(int id)
        {
            var result = await _service.XoaHopDong(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
