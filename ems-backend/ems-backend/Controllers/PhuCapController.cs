using ems_backend.Models.RequestModel.PhongBanRequest;
using ems_backend.Models.RequestModel.PhuCapRequest;
using ems_backend.Models.ResponseModels.DataPhongBan;
using ems_backend.Models.ResponseModels.ResponsePhuCap;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhuCapController : ControllerBase
    {
        private readonly IPhuCapService _service;
        public PhuCapController (IPhuCapService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponsePhuCap>>> LayDanhSachPhuCap()
        {
            return Ok(await _service.LayTatCaPhuCap());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponsePhuCap>> GetPhuCap(int id)
        {
            var phuCap = await _service.LayPhuCapTheoId(id);
            if (phuCap == null)
            {
                return NotFound();
            }
            return Ok(phuCap);
        }
        [HttpPost]
        public async Task<IActionResult> ThemPhuCap([FromBody] Request_ThemPhuCap request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exists = await _service.CheckTenPhuCapExists(request.TenPhuCap);
            if (exists)
            {
                return Conflict("Tên phụ cấp đã tồn tại.");
            }
            var phuCap = await _service.ThemPhuCap(request);
            return CreatedAtAction(nameof(GetPhuCap), new { id = phuCap.Id }, phuCap);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaPhuCap(int id, Request_SuaPhuCap request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaPhuCap(id, request);
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
        public async Task<IActionResult> XoaPhuCap(int id)
        {
            var result = await _service.XoaPhuCap(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
        [HttpGet("check-ten")]
        public async Task<IActionResult> CheckTenPhuCap([FromQuery] string tenPhuCap)
        {
            var exists = await _service.CheckTenPhuCapExists(tenPhuCap);
            return Ok(new { exists });
        }
    }
}
