using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.KyLuatRequest;
using ems_backend.Models.ResponseModels.DataKyLuat;

namespace ems_backend.Service.Interfaces
{
    public interface IKyLuatService
    {
        Task<PageResult<DataResponseKyLuat>> LayTatCaKyLuat(int pageSize, int pageNumber);
        Task<DataResponseKyLuat> LayKyLuatTheoId(int id);
        Task<DataResponseKyLuat> ThemKyLuat(Request_ThemKyLuat request);
        Task<DataResponseKyLuat> SuaKyLuat(int id, Request_SuaKyLuat request);
        Task<bool> XoaKyLuat(int id);
    }
}
