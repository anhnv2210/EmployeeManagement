using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.TinhThanhRequest;
using ems_backend.Models.ResponseModels.DataTinhThanh;

namespace ems_backend.Service.Interfaces
{
    public interface ITinhThanhService
    {
        Task<PageResult<DataResponseTinhThanh>> LayTatCaTinhThanh(int pageSize = 10, int pageNumber = 1);
        Task<DataResponseTinhThanh> LayTinhThanhTheoId(int id);
        Task<DataResponseTinhThanh> ThemTinhThanh(Request_ThemTinhThanh request);
        Task<DataResponseTinhThanh> SuaTinhThanh(int id, Request_SuaTinhThanh request);
        Task<bool> XoaTinhThanh(int id);
        Task<bool> CheckTenTinhThanhExists(string tenTinhThanh);
        Task<IEnumerable<DataResponseTinhThanh>> GetTinhThanhByQuocGiaAsync(long quocGiaId);
    }
}
