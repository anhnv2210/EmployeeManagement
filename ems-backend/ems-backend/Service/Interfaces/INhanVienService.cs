using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.NhanVienRequest;
using ems_backend.Models.ResponseModels.DataNhanVien;

namespace ems_backend.Service.Interfaces
{
    public interface INhanVienService
    {
        // phân trang, tìm kiếm theo tên hoặc theo trạng thái, 
        Task<PageResult<DataResponseNhanVien>> LayTatCaNhanVien(string? trangThai,int pageSize = 10, int pageNumber = 1);
        Task<DataResponseNhanVien> LayNhanVienTheoId(int id);
        Task<DataResponseNhanVien> ThemNhanVien(Request_ThemNhanVien request);
        Task<DataResponseNhanVien> SuaNhanVien(int id, Request_SuaNhanVien request);
        //Task<bool> XoaNhanVien(int id);
        Task<bool> CheckEmailExists(string email);
        Task<bool> CheckSoDienThoaiExists(string soDienThoai);


    }
}
