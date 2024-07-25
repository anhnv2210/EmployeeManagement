using ems_backend.Models.RequestModel.ChucDanhRequest;
using ems_backend.Models.RequestModel.DanhMucKhacRequest;
using ems_backend.Models.ResponseModels.DataChucDanh;
using ems_backend.Models.ResponseModels.DataDanhMucKhac;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucKhacController : ControllerBase
    {
        private readonly IDanhMucKhacService _service;
        public DanhMucKhacController(IDanhMucKhacService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponseDanhMucKhac>>> LayDanhSachDanhMucKhac()
        {
            return Ok(await _service.LayTatCaDanhMucKhac());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseDanhMucKhac>> GetDanhMucKhac(int id)
        {
            var danhMucKhac = await _service.LayDanhMucKhacTheoId(id);
            if (danhMucKhac == null)
            {
                return NotFound();
            }
            return Ok(danhMucKhac);
        }
        [HttpPost]
        public async Task<IActionResult> ThemDanhMucKhac([FromBody] Request_ThemDanhMucKhac request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var danhMucKhac = await _service.ThemDanhMucKhac(request);
            return CreatedAtAction(nameof(GetDanhMucKhac), new { id = danhMucKhac.Id }, danhMucKhac);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaDanhMucKhac(int id, Request_SuaDanhMucKhac request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaDanhMucKhac(id, request);
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
        public async Task<IActionResult> XoaDanhMucKhac(int id)
        {
            var result = await _service.XoaDanhMucKhac(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
