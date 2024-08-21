using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.NoiKhamBenhRequest;
using ems_backend.Models.ResponseModels.DataNoiKhamBenh;

namespace ems_backend.Service.Interfaces
{
    public interface INoiKhamBenhService
    {
        Task<PageResult<DataResponseNoiKhamBenh>> LayTatCaNoiKhamBenh(bool? isActive, int pageSize = 10, int pageNumber = 1);
        Task<DataResponseNoiKhamBenh> LayNoiKhamBenhTheoId(int id);
        Task<DataResponseNoiKhamBenh> ThemNoiKhamBenh(Request_ThemNoiKhamBenh request);
        Task<DataResponseNoiKhamBenh> SuaNoiKhamBenh(int id, Request_SuaNoiKhamBenh request);
        Task<bool> XoaNoiKhamBenh(int id);
        Task<bool> CheckEmailExists(string email);
        Task<bool> CheckSoDienThoaiExists(string soDienThoai);
    }
}
