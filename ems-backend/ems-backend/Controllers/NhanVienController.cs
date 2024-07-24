using ems_backend.Models.ResponseModels.DataChucDanh;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _service;
        public NhanVienController(INhanVienService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponseChucDanh>>> LayDanhSachChucDanh()
        {
            return Ok(await _service.LayTatCaNhanVien());
        }
    }
}
