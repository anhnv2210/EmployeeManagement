using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.ChucDanhRequest;
using ems_backend.Models.ResponseModels.DataChucDanh;

namespace ems_backend.Service.Interfaces
{
    public interface IChucDanhService
    {
        Task<PageResult<DataResponseChucDanh>> LayTatCaChucDanh(bool? isActive, int pageSize, int pageNumber);
        Task<DataResponseChucDanh> LayChucDanhTheoId(int id);
        Task<DataResponseChucDanh> ThemChucDanh(Request_ThemChucDanh request);
        Task<DataResponseChucDanh> SuaChucDanh(int id,Request_SuaChucDanh request);
        Task<bool> XoaChucDanh(int id);
        Task<bool> CheckTenChucDanhExists(string tenChucDanh);
    }
}
