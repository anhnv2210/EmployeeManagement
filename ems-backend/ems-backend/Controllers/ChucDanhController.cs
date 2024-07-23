using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.ChucDanhRequest;
using ems_backend.Models.ResponseModels.DataChucDanh;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucDanhController : ControllerBase
    {
        private readonly IChucDanhService _service;
        public ChucDanhController(IChucDanhService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponseChucDanh>>> LayDanhSachChucDanh()
        {
            return Ok(await _service.LayTatCaChucDanh());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseChucDanh>> GetChucDanh(int id)
        {
            var chucDanh = await _service.LayChucDanhTheoId(id);
            if (chucDanh == null)
            {
                return NotFound();
            }
            return Ok(chucDanh);
        }
        [HttpPost]
        public async Task<IActionResult> ThemChucDanh([FromBody] Request_ThemChucDanh request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var chucDanh = await _service.ThemChucDanh(request);
            return CreatedAtAction(nameof(GetChucDanh), new { id = chucDanh.Id}, chucDanh);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaChucDanh(int id, Request_SuaChucDanh request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.SuaChucDanh(id, request);
            if (result == null)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaChucDanh(int id)
        {
            var result = await _service.XoaChucDanh(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
