using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.KhenThuongRequest;
using ems_backend.Models.ResponseModels.DataKhenThuong;

namespace ems_backend.Service.Interfaces
{
    public interface IKhenThuongService
    {
        Task<PageResult<DataResponseKhenThuong>> LayTatCaKhenThuong(int pageSize, int pageNumber);
        Task<DataResponseKhenThuong> LayKhenThuongTheoId(int id);
        Task<DataResponseKhenThuong> ThemKhenThuong(Request_ThemKhenThuong request);
        Task<DataResponseKhenThuong> SuaKhenThuong(int id, Request_SuaKhenThuong request);
        Task<bool> XoaKhenThuong(int id);
    }
}
