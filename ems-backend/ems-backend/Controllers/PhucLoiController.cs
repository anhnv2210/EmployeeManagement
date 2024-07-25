using ems_backend.Models.RequestModel.PhucLoiRequest;
using ems_backend.Models.ResponseModels.DataPhucLoi;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhucLoiController : ControllerBase
    {
        private readonly IPhucLoiService _service;
        public PhucLoiController(IPhucLoiService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponsePhucLoi>>> LayDanhSachPhucLoi()
        {
            return Ok(await _service.LayTatCaPhucLoi());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponsePhucLoi>> GetPhucLoi(int id)
        {
            var phucLoi = await _service.LayPhucLoiTheoId(id);
            if (phucLoi == null)
            {
                return NotFound();
            }
            return Ok(phucLoi);
        }
        [HttpPost]
        public async Task<IActionResult> ThemPhucLoi([FromBody] Request_ThemPhucLoi request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exists = await _service.CheckTenPhucLoiExists(request.TenPhucLoi);
            if (exists)
            {
                return Conflict("Tên phúc lợi đã tồn tại.");
            }
            var phucLoi = await _service.ThemPhucLoi(request);
            return CreatedAtAction(nameof(GetPhucLoi), new { id = phucLoi.Id }, phucLoi);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaPhucLoi(int id, Request_SuaPhucLoi request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaPhucLoi(id, request);
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
        public async Task<IActionResult> XoaPhucLoi(int id)
        {
            var result = await _service.XoaPhucLoi(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
        [HttpGet("check-ten")]
        public async Task<IActionResult> CheckTenPhucLoi([FromQuery] string tenPhucLoi)
        {
            var exists = await _service.CheckTenPhucLoiExists(tenPhucLoi);
            return Ok(new { exists });
        }
    }
}
