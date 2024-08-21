using ems_backend.Models.RequestModel.CapPhatTaiSanRequest;
using ems_backend.Models.ResponseModels.DataCapPhatTaiSan;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapPhatTaiSanController : ControllerBase
    {
        private readonly ICapPhatTaiSanService _service;
        public CapPhatTaiSanController(ICapPhatTaiSanService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> LayDanhSachCapPhatTaiSan(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _service.LayTatCaCapPhatTaiSan(pageSize, pageNumber));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseCapPhatTaiSan>> GetCapPhatTaiSan(int id)
        {
            var result = await _service.LayCapPhatTaiSanTheoId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> ThemCapPhatTaiSan([FromBody] Request_ThemCapPhatTaiSan request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.ThemCapPhatTaiSan(request);
            return CreatedAtAction(nameof(GetCapPhatTaiSan), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaCapPhatTaiSan(int id, Request_SuaCapPhatTaiSan request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaCapPhatTaiSan(id, request);
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
        public async Task<IActionResult> XoaCapPhatTaiSan(int id)
        {
            var result = await _service.XoaCapPhatTaiSan(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

    }
}
