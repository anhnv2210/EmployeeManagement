using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.QuanHuyenRequest;
using ems_backend.Models.RequestModel.TinhThanhRequest;
using ems_backend.Models.ResponseModels.DataQuanHuyen;
using ems_backend.Models.ResponseModels.DataTinhThanh;
using ems_backend.Service.Implements;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanHuyenController : ControllerBase
    {
        private readonly IQuanHuyenService _service;
        public QuanHuyenController(IQuanHuyenService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponseQuanHuyen>>> LayDanhSachQuanHuyen(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _service.LayTatCaQuanHuyen(pageSize, pageNumber));
        }
        [HttpGet("byTinhThanh/{tinhThanhId}")]
        public async Task<ActionResult<IEnumerable<QuanHuyen>>> GetQuanHuyenByTinhThanh(int tinhThanhId)
        {
            var quanHuyens = await _service.LayTatCaQuanHuyenByTinhThanh(tinhThanhId);
            return Ok(quanHuyens);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponseQuanHuyen>> GetQuanHuyen(int id)
        {
            var quanHuyen = await _service.LayQuanHuyenTheoId(id);
            if (quanHuyen == null)
            {
                return NotFound();
            }
            return Ok(quanHuyen);
        }
        [HttpPost]
        public async Task<IActionResult> ThemQuanHuyen([FromBody] Request_ThemQuanHuyen request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var result = await _service.ThemQuanHuyen(request);
            return CreatedAtAction(nameof(GetQuanHuyen), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaQuanHuyen(int id, Request_SuaQuanHuyen request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.SuaQuanHuyen(id, request);
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
        public async Task<IActionResult> XoaQuanHuyen(int id)
        {
            var result = await _service.XoaQuanHuyen(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
