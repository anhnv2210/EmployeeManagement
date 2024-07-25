
using ems_backend.Models.RequestModel.TaiSanRequest;
using ems_backend.Models.ResponseModels.DataPhucLoi;
using ems_backend.Models.ResponseModels.DataTaiSan;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiSanController : ControllerBase
    {
        private readonly ITaiSanService _service;
        public TaiSanController(ITaiSanService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponsePhucLoi>>> LayDanhSachTaiSan()
        {
            return Ok(await _service.LayTatCaTaiSan());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseTaiSan>> GetTaiSan(int id)
        {
            var phucLoi = await _service.LayTaiSanTheoId(id);
            if (phucLoi == null)
            {
                return NotFound();
            }
            return Ok(phucLoi);
        }
        [HttpPost]
        public async Task<IActionResult> ThemTaiSan([FromBody] Request_ThemTaiSan request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exists = await _service.CheckTenTaiSanExists(request.TenTaiSan);
            if (exists)
            {
                return Conflict("Tên tai san đã tồn tại.");
            }
            var result = await _service.ThemTaiSan(request);
            return CreatedAtAction(nameof(GetTaiSan), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaTaiSan(int id, Request_SuaTaiSan request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaTaiSan(id, request);
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
        public async Task<IActionResult> XoaTaiSan(int id)
        {
            var result = await _service.XoaTaiSan(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
        [HttpGet("check-ten")]
        public async Task<IActionResult> CheckTenTaiSan([FromQuery] string tenTaiSan)
        {
            var exists = await _service.CheckTenTaiSanExists(tenTaiSan);
            return Ok(new { exists });
        }
    }
}
