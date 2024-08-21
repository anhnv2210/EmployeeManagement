using ems_backend.Models.RequestModel.HoSoLuongRequest;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoSoLuong_PhucLoiController : ControllerBase
    {
        private readonly IHoSoLuong_PhucLoiService _service;

        public HoSoLuong_PhucLoiController(IHoSoLuong_PhucLoiService service)
        {
            _service = service;
        }

        [HttpGet("{hoSoLuongId}")]
        public async Task<IActionResult> GetHoSoLuong_PhucLoi(int hoSoLuongId)
        {
            var result = await _service.GetHoSoLuong_PhucLoiAsync(hoSoLuongId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddHoSoLuong_PhucLoi([FromBody] List<Request_HoSoLuong_PhucLoi> requests)
        {
            await _service.AddHoSoLuong_PhucLoiAsync(requests);
            return CreatedAtAction(nameof(GetHoSoLuong_PhucLoi), new { hoSoLuongId = requests.First().HoSoLuongId }, requests);
        }
    }
}
