using ems_backend.Models.RequestModel.DanhMucKhacRequest;
using ems_backend.Models.ResponseModels.DataDanhMucKhac;

namespace ems_backend.Service.Interfaces
{
    public interface IDanhMucKhacService
    {
        Task<IEnumerable<DataResponseDanhMucKhac>> LayTatCaDanhMucKhac();
        Task<DataResponseDanhMucKhac> LayDanhMucKhacTheoId(int id);
        Task<DataResponseDanhMucKhac> ThemDanhMucKhac(Request_ThemDanhMucKhac request);
        Task<DataResponseDanhMucKhac> SuaDanhMucKhac(int id, Request_SuaDanhMucKhac request);
        Task<bool> XoaDanhMucKhac(int id);
    }
}
