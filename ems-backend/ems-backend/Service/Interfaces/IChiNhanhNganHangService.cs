using ems_backend.Models.RequestModel.ChiNhanhNganHang;
using ems_backend.Models.ResponseModels.DataChiNhanhNganHang;

namespace ems_backend.Service.Interfaces
{
    public interface IChiNhanhNganHangService
    {
        Task<IEnumerable<DataResponseChiNhanhNganHang>> LayTatCaChiNhanhNganHang();
        Task<DataResponseChiNhanhNganHang> LayChiNhanhNganHangTheoId(int id);
        Task<DataResponseChiNhanhNganHang> ThemChiNhanhNganHang(Request_ThemChiNhanhNganHang request);
        Task<DataResponseChiNhanhNganHang> SuaChiNhanhNganHang(int id, Request_SuaChiNhanhNganHang request);
        Task<bool> XoaChiNhanhNganHang(int id);
        Task<bool> CheckTenChiNhanhNganHangExists(string tenChiNhanhNganHang, int nganHangId);
        Task<bool> CheckEmailExists(string email);
        Task<bool> CheckSoDienThoaiExists(string soDienThoai);
    }
}
