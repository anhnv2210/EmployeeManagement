using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.HoSoLuongRequest;
using ems_backend.Models.ResponseModels.DataHoSoLuong;

namespace ems_backend.Service.Interfaces
{
    public interface IHoSoLuongService
    {
        Task<PageResult<DataResponseHoSoLuong>> LayTatCaHoSoLuong( int pageSize, int pageNumber);
        Task<DataResponseHoSoLuong> LayHoSoLuongTheoId(int id);
        Task<DataResponseHoSoLuong> ThemHoSoLuong(Request_ThemHoSoLuong request);
    }
}
