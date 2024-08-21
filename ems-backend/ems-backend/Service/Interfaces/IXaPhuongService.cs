using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.XaPhuongRequest;
using ems_backend.Models.ResponseModels.DataXaPhuong;

namespace ems_backend.Service.Interfaces
{
    public interface IXaPhuongService
    {
        Task<PageResult<DataResponseXaPhuong>> LayTatCaXaPhuong(int pageSize = 10, int pageNumber = 1);
        Task<IEnumerable<DataResponseXaPhuong>> LayTatCaXaPhuongByQuanHuyen(int quanHuyenId);
        Task<DataResponseXaPhuong> LayXaPhuongTheoId(int id);
        Task<DataResponseXaPhuong> ThemXaPhuong(Request_ThemXaPhuong request);
        Task<DataResponseXaPhuong> SuaXaPhuong(int id, Request_SuaXaPhuong request);
        Task<bool> XoaXaPhuong(int id);
    }
}
