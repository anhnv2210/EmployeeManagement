using ems_backend.Models.RequestModel.QuyetDinhRequest;
using ems_backend.Models.ResponseModels.DataHopDongLaoDong;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuyetDinhController : ControllerBase
    {
        private readonly IQuyetDinhService _service;
        public QuyetDinhController(IQuyetDinhService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponseQuyetDinh>>> LayDanhSachQuyetDinh(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _service.LayTatCaQuyetDinh(pageSize, pageNumber));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseQuyetDinh>> GetQuyetDinh(int id)
        {
            var result = await _service.LayQuyetDinhTheoId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> ThemQuyetDinh([FromBody] Request_ThemQuyetDinh request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.ThemQuyetDinh(request);
            return CreatedAtAction(nameof(GetQuyetDinh), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaQuyetDinh(int id, Request_SuaQuyetDinh request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaQuyetDinh(id, request);
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
        public async Task<IActionResult> XoaQuyetDinh(int id)
        {
            var result = await _service.XoaQuyetDinh(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
