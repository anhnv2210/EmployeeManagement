using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.HopDongRequest;
using ems_backend.Models.ResponseModels.DataHopDongLaoDong;

namespace ems_backend.Service.Interfaces
{
    public interface IHopDongService
    {
        Task<PageResult<DataResponseHopDong>> LayTatCaHopDong(int pageSize = 10, int pageNumber = 1);
        Task<DataResponseHopDong> LayHopDongTheoId(int id);
        Task<DataResponseHopDong> ThemHopDong(Request_ThemHopDong request);
        Task<DataResponseHopDong> SuaHopDong(int id, Request_SuaHopDong request);
        Task<bool> XoaHopDong(int id);
    }
}
