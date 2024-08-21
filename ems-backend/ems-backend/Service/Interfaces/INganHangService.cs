using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.NganHangRequest;
using ems_backend.Models.ResponseModels.DataNganHang;

namespace ems_backend.Service.Interfaces
{
    public interface INganHangService
    {
        Task<PageResult<DataResponseNganHang>> LayTatCaNganHang(bool? isActive, int pageSize = 10, int pageNumber = 1);
        Task<DataResponseNganHang> LayNganHangTheoId(int id);
        Task<DataResponseNganHang> ThemNganHang(Request_ThemNganHang request);
        Task<DataResponseNganHang> SuaNganHang(int id, Request_SuaNganHang request);
        Task<bool> XoaNganHang(int id);
        Task<bool> CheckTenNganHangExists(string tenNganHang);
        Task<bool> CheckEmailExists(string email);
        Task<bool> CheckSoDienThoaiExists(string soDienThoai);
    }
}
