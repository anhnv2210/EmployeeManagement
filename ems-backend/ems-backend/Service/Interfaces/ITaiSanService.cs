using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.TaiSanRequest;
using ems_backend.Models.ResponseModels.DataTaiSan;

namespace ems_backend.Service.Interfaces
{
    public interface ITaiSanService
    {
        Task<PageResult<DataResponseTaiSan>> LayTatCaTaiSan(bool? isActive,int pageSize = 10, int pageNumber = 1);
        Task<DataResponseTaiSan> LayTaiSanTheoId(int id);
        Task<DataResponseTaiSan> ThemTaiSan(Request_ThemTaiSan request);
        Task<DataResponseTaiSan> SuaTaiSan(int id, Request_SuaTaiSan request);
        Task<bool> XoaTaiSan(int id);
        Task<bool> CheckTenTaiSanExists(string tenTaiSan);
    }
}
