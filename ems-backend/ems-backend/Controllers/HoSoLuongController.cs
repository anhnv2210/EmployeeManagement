using ems_backend.Models.RequestModel.HoSoLuongRequest;
using ems_backend.Models.ResponseModels.DataHoSoLuong;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoSoLuongController : ControllerBase
    {
        private readonly IHoSoLuongService _service;
        public HoSoLuongController(IHoSoLuongService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> LayDanhSachHoSoLuong( int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _service.LayTatCaHoSoLuong(pageSize, pageNumber));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseHoSoLuong>> GetHoSoLuong(int id)
        {
            var result = await _service.LayHoSoLuongTheoId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> ThemHoSoLuong([FromBody] Request_ThemHoSoLuong request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          
            var result = await _service.ThemHoSoLuong(request);
            return CreatedAtAction(nameof(GetHoSoLuong), new { id = result.Id }, result);
        }
    }
}
