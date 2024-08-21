using ems_backend.Models.RequestModel.QuocGiaRequest;
using ems_backend.Models.ResponseModels.DataQuocGia;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuocGiaController : ControllerBase
    {
        private readonly IQuocGiaService _service;
        public QuocGiaController(IQuocGiaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponseQuocGia>>> LayDanhSachQuocDanh(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _service.LayTatCaQuocGia(pageSize, pageNumber));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseQuocGia>> GetQuocGia(int id) { 
            var quocGia = await _service.LayQuocGiaTheoId(id);
            if (quocGia == null)
            {
                return NotFound();
            }
            return Ok(quocGia);
        }
        [HttpPost]
        public async Task<IActionResult> ThemQuocGia([FromBody] Request_ThemQuocGia request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exists = await _service.CheckTenQuocGiaExists(request.TenQuocGia);
            if (exists)
            {
                return Conflict("Tên quoc gia đã tồn tại.");
            }
            var quocGia = await _service.ThemQuocGia(request);
            return CreatedAtAction(nameof(GetQuocGia), new { id = quocGia.Id }, quocGia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaQuocGia(int id, Request_SuaQuocGia request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaQuocGia(id, request);
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
        public async Task<IActionResult> XoaQuocGia(int id)
        {
            var result = await _service.XoaQuocGia(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
        [HttpGet("check-ten")]
        public async Task<IActionResult> CheckTenQuocGia([FromQuery] string tenQuocGia)
        {
            var exists = await _service.CheckTenQuocGiaExists(tenQuocGia);
            return Ok(new { exists });
        }
    }
}
