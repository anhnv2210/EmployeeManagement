using ems_backend.Models.RequestModel.HoSoLuongRequest;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoSoLuong_PhuCapController : ControllerBase
    {
        private readonly IHoSoLuong_PhuCapService _service;

        public HoSoLuong_PhuCapController(IHoSoLuong_PhuCapService service)
        {
            _service = service;
        }

        [HttpGet("{hoSoLuongId}")]
        public async Task<IActionResult> GetHoSoLuong_PhuCap(int hoSoLuongId)
        {
            var result = await _service.GetHoSoLuong_PhuCapAsync(hoSoLuongId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddHoSoLuong_PhuCap([FromBody] List<Request_HoSoLuong_PhuCap> requests)
        {
            await _service.AddHoSoLuong_PhuCapAsync(requests);
            return CreatedAtAction(nameof(GetHoSoLuong_PhuCap), new { hoSoLuongId = requests.First().HoSoLuongId }, requests);
        }
    }
}
