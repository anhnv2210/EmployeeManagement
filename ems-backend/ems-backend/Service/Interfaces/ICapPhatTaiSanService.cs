using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.CapPhatTaiSanRequest;
using ems_backend.Models.RequestModel.ChucDanhRequest;
using ems_backend.Models.ResponseModels.DataCapPhatTaiSan;
using ems_backend.Models.ResponseModels.DataChucDanh;

namespace ems_backend.Service.Interfaces
{
    public interface ICapPhatTaiSanService
    {
        Task<PageResult<DataResponseCapPhatTaiSan>> LayTatCaCapPhatTaiSan(int pageSize, int pageNumber);
        Task<DataResponseCapPhatTaiSan> LayCapPhatTaiSanTheoId(int id);
        Task<DataResponseCapPhatTaiSan> ThemCapPhatTaiSan(Request_ThemCapPhatTaiSan request);
        Task<DataResponseCapPhatTaiSan> SuaCapPhatTaiSan(int id, Request_SuaCapPhatTaiSan request);
        Task<bool> XoaCapPhatTaiSan(int id);
    }
}
