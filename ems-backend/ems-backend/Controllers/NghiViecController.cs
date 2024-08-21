using ems_backend.Models.RequestModel.NghiViecRequest;
using ems_backend.Models.ResponseModels.DataNghiViec;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NghiViecController : ControllerBase
    {
        private readonly INghiViecService _service;
        public NghiViecController(INghiViecService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> LayDanhSachNghiViec(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _service.LayTatCaNghiViec(pageSize, pageNumber));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseNghiViec>> GetNghiViec(int id)
        {
            var result = await _service.LayNghiViecTheoId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> ThemNghiViec([FromBody] Request_ThemNghiViec request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.ThemNghiViec(request);
            return CreatedAtAction(nameof(GetNghiViec), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaNghiViec(int id, Request_SuaNghiViec request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaNghiViec(id, request);
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
        public async Task<IActionResult> XoaNghiViec(int id)
        {
            var result = await _service.XoaNghiViec(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
