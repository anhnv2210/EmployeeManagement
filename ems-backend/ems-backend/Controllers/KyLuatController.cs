using ems_backend.Models.RequestModel.KyLuatRequest;
using ems_backend.Models.ResponseModels.DataKyLuat;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KyLuatController : ControllerBase
    {
        private readonly IKyLuatService _service;
        public KyLuatController(IKyLuatService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> LayDanhSachKyLuat(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _service.LayTatCaKyLuat(pageSize, pageNumber));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseKyLuat>> GetKyLuat(int id)
        {
            var result = await _service.LayKyLuatTheoId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> ThemKyLuat([FromBody] Request_ThemKyLuat request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.ThemKyLuat(request);
            return CreatedAtAction(nameof(GetKyLuat), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaKyLuat(int id, Request_SuaKyLuat request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaKyLuat(id, request);
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
        public async Task<IActionResult> XoaKyLuat(int id)
        {
            var result = await _service.XoaKyLuat(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
