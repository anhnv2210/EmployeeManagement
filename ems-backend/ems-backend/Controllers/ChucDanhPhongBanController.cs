using ems_backend.Models.ResponseModels.DataChucDanhPhongBan;
using ems_backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ems_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucDanhPhongBanController : ControllerBase
    {
        private readonly IChucDanhTheoPhongBanService _service;
        public ChucDanhPhongBanController(IChucDanhTheoPhongBanService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataResponseChucDanhPhongBan>>> GetChucDanhTheoPhongBan()
        {
            var result = await _service.GetChucDanhTheoPhongBanAsync();
            return Ok(result);
        }
    }
}
