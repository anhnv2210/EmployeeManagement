
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.PhuCapRequest;
using ems_backend.Models.ResponseModels.ResponsePhuCap;

namespace ems_backend.Service.Interfaces
{
    public interface IPhuCapService
    {
        Task<PageResult<DataResponsePhuCap>> LayTatCaPhuCap(bool? isActive, int pageSize = 10, int pageNumber = 1);
        Task<DataResponsePhuCap> LayPhuCapTheoId(int id);
        Task<DataResponsePhuCap> ThemPhuCap(Request_ThemPhuCap request);
        Task<DataResponsePhuCap> SuaPhuCap(int id, Request_SuaPhuCap request);
        Task<bool> XoaPhuCap(int id);
        Task<bool> CheckTenPhuCapExists(string tenPhuCap);
    }
}
