using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataChucDanhPhongBan;

namespace ems_backend.Service.Interfaces
{
    public interface IChucDanhTheoPhongBanService
    {
        Task<IEnumerable<DataResponseChucDanhPhongBan>> GetChucDanhTheoPhongBanAsync();
    }
}
