using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.PhongBanRequest;
using ems_backend.Models.ResponseModels.DataPhongBan;

namespace ems_backend.Service.Interfaces
{
    public interface IPhongBanService
    {
        Task<PageResult<DataResponsePhongBan>> LayTatCaPhongBan(bool? isActive, int pageSize, int pageNumber);
        Task<DataResponsePhongBan> LayPhongBanTheoId(int id);
        Task<DataResponsePhongBan> ThemPhongBan(Request_ThemPhongBan request);
        Task<DataResponsePhongBan> SuaPhongBan(int id, Request_SuaPhongBan request);
        Task<bool> XoaPhongBan(int id);
        Task<bool> CheckTenPhongBanExists(string tenPhongBan);
    }
}
