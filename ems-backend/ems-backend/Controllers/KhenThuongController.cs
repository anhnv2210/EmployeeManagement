using ems_backend.Models.RequestModel.KhenThuongRequest;
using ems_backend.Models.ResponseModels.DataKhenThuong;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhenThuongController : ControllerBase
    {
        private readonly IKhenThuongService _service;
        public KhenThuongController(IKhenThuongService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> LayDanhSachKhenThuong(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _service.LayTatCaKhenThuong(pageSize, pageNumber));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseKhenThuong>> GetKhenThuong(int id)
        {
            var result = await _service.LayKhenThuongTheoId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> ThemKhenThuong([FromBody] Request_ThemKhenThuong request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.ThemKhenThuong(request);
            return CreatedAtAction(nameof(GetKhenThuong), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaKhenThuong(int id, Request_SuaKhenThuong request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaKhenThuong(id, request);
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
        public async Task<IActionResult> XoaKhenThuong(int id)
        {
            var result = await _service.XoaKhenThuong(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
