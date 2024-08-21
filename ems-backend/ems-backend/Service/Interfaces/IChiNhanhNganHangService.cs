using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.ChiNhanhNganHang;
using ems_backend.Models.ResponseModels.DataChiNhanhNganHang;
using ems_backend.Models.ResponseModels.DataXaPhuong;

namespace ems_backend.Service.Interfaces
{
    public interface IChiNhanhNganHangService
    {
        Task<PageResult<DataResponseChiNhanhNganHang>> LayTatCaChiNhanhNganHang(bool? isActive, int pageSize = 10, int pageNumber = 1);
        Task<DataResponseChiNhanhNganHang> LayChiNhanhNganHangTheoId(int id);
        Task<IEnumerable<DataResponseChiNhanhNganHang>> LayTatCaChiNhanhNganHangByNganHang(int nganHangId);
        Task<DataResponseChiNhanhNganHang> ThemChiNhanhNganHang(Request_ThemChiNhanhNganHang request);
        Task<DataResponseChiNhanhNganHang> SuaChiNhanhNganHang(int id, Request_SuaChiNhanhNganHang request);
        Task<bool> XoaChiNhanhNganHang(int id);
        Task<bool> CheckEmailExists(string email);
        Task<bool> CheckSoDienThoaiExists(string soDienThoai);
    }
}
