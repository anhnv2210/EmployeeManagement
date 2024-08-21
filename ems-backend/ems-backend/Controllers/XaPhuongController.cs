using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.XaPhuongRequest;
using ems_backend.Models.ResponseModels.DataXaPhuong;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XaPhuongController : ControllerBase
    {
        private readonly IXaPhuongService _service;
        public XaPhuongController(IXaPhuongService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponseXaPhuong>>> LayDanhSachXaPhuong( int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _service.LayTatCaXaPhuong(pageSize, pageNumber));
        }
        [HttpGet("byQuanHuyen/{quanHuyenId}")]
        public async Task<ActionResult<IEnumerable<QuanHuyen>>> GetXaPhuongByQuanHuyen(int quanHuyenId)
        {
            var quanHuyens = await _service.LayTatCaXaPhuongByQuanHuyen(quanHuyenId);
            return Ok(quanHuyens);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseXaPhuong>> GetXaPhuong(int id)
        {
            var xaPhuong = await _service.LayXaPhuongTheoId(id);
            if (xaPhuong == null)
            {
                return NotFound();
            }
            return Ok(xaPhuong);
        }
        [HttpPost]
        public async Task<IActionResult> ThemXaPhuong([FromBody] Request_ThemXaPhuong request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.ThemXaPhuong(request);
            return CreatedAtAction(nameof(GetXaPhuong), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaXaPhuong(int id, Request_SuaXaPhuong request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaXaPhuong(id, request);
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
        public async Task<IActionResult> XoaXaPhuong(int id)
        {
            var result = await _service.XoaXaPhuong(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
