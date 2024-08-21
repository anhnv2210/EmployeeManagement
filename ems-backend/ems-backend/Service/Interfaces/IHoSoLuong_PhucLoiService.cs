using ems_backend.Models.RequestModel.HoSoLuongRequest;
using ems_backend.Models.ResponseModels.DataHoSoLuong;

namespace ems_backend.Service.Interfaces
{
    public interface IHoSoLuong_PhucLoiService
    {
        Task<List<DataResponseHoSoLuongPhucLoi>> GetHoSoLuong_PhucLoiAsync(int hoSoLuongId);
        Task AddHoSoLuong_PhucLoiAsync(List<Request_HoSoLuong_PhucLoi> requests);
    }
}
