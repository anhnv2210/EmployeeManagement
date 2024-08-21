using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.DanhMucKhacRequest;
using ems_backend.Models.ResponseModels.DataDanhMucKhac;

namespace ems_backend.Service.Interfaces
{
    public interface IDanhMucKhacService
    {
        Task<PageResult<DataResponseDanhMucKhac>> LayTatCaDanhMucKhac(bool? isActive, int pageSize = 10, int pageNumber = 1);
        Task<DataResponseDanhMucKhac> LayDanhMucKhacTheoId(int id);
        Task<DataResponseDanhMucKhac> ThemDanhMucKhac(Request_ThemDanhMucKhac request);
        Task<DataResponseDanhMucKhac> SuaDanhMucKhac(int id, Request_SuaDanhMucKhac request);
        Task<bool> XoaDanhMucKhac(int id);
    }
}
