using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.TinhThanhRequest;
using ems_backend.Models.ResponseModels.DataTinhThanh;
using ems_backend.Service.Implements;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinhThanhController : ControllerBase
    {
        private readonly ITinhThanhService _service;
        public TinhThanhController(ITinhThanhService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponseTinhThanh>>> LayDanhSachTinhThanh(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _service.LayTatCaTinhThanh(pageSize, pageNumber));
        }
        [HttpGet("byQuocGia/{quocGiaId}")]
        public async Task<ActionResult<IEnumerable<TinhThanh>>> GetTinhThanhByQuocGia(long quocGiaId)
        {
            var tinhThanhs = await _service.GetTinhThanhByQuocGiaAsync(quocGiaId);
            return Ok(tinhThanhs);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseTinhThanh>> GetTinhThanh(int id)
        {
            var tinhThanh = await _service.LayTinhThanhTheoId(id);
            if (tinhThanh == null)
            {
                return NotFound();
            }
            return Ok(tinhThanh);
        }
        [HttpPost]
        public async Task<IActionResult> ThemTinhThanh([FromBody] Request_ThemTinhThanh request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exists = await _service.CheckTenTinhThanhExists(request.TenTinhThanh);
            if (exists)
            {
                return Conflict("Tên tinh thanh đã tồn tại.");
            }
            var tinhThanh = await _service.ThemTinhThanh(request);
            return CreatedAtAction(nameof(GetTinhThanh), new { id = tinhThanh.Id }, tinhThanh);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaTinhThanh(int id, Request_SuaTinhThanh request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaTinhThanh(id, request);
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
        public async Task<IActionResult> XoaTinhThanh(int id)
        {
            var result = await _service.XoaTinhThanh(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
        [HttpGet("check-ten")]
        public async Task<IActionResult> CheckTenTinhThanh([FromQuery] string tenTinhThanh)
        {
            var exists = await _service.CheckTenTinhThanhExists(tenTinhThanh);
            return Ok(new { exists });
        }
    }
}
