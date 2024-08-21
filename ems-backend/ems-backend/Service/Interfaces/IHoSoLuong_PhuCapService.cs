using ems_backend.Models.RequestModel.HoSoLuongRequest;
using ems_backend.Models.ResponseModels.DataHoSoLuong;

namespace ems_backend.Service.Interfaces
{
    public interface IHoSoLuong_PhuCapService
    {
        Task<List<DataResponseHoSoLuongPhuCap>> GetHoSoLuong_PhuCapAsync(int hoSoLuongId);
        Task AddHoSoLuong_PhuCapAsync(List<Request_HoSoLuong_PhuCap> requests);
    }
}
