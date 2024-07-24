using ems_backend.Models.RequestModel.LoaiHopDongRequest;
using ems_backend.Models.ResponseModels.DataLoaiHopDong;

namespace ems_backend.Service.Interfaces
{
    public interface ILoaiHopDongService
    {
        Task<IEnumerable<DataResponseLoaiHopDong>> LayTatCaLoaiHopDong();
        Task<DataResponseLoaiHopDong> LayLoaiHopDongTheoId(int id);
        Task<DataResponseLoaiHopDong> ThemLoaiHopDong(Request_ThemLoaiHopDong request);
        Task<DataResponseLoaiHopDong> SuaLoaiHopDong(int id, Request_SuaLoaiHopDong request);
        Task<bool> XoaLoaiHopDong(int id);
        Task<bool> CheckTenLoaiHopDongExists(string tenLoaiHopDong);
    }
}
