using ems_backend.Models.RequestModel.TinhThanhRequest;
using ems_backend.Models.ResponseModels.DataTinhThanh;

namespace ems_backend.Service.Interfaces
{
    public interface ITinhThanhService
    {
        Task<IEnumerable<DataResponseTinhThanh>> LayTatCaTinhThanh();
        Task<DataResponseTinhThanh> LayTinhThanhTheoId(int id);
        Task<DataResponseTinhThanh> ThemTinhThanh(Request_ThemTinhThanh request);
        Task<DataResponseTinhThanh> SuaTinhThanh(int id, Request_SuaTinhThanh request);
        Task<bool> XoaTinhThanh(int id);
        Task<bool> CheckTenTinhThanhExists(string tenTinhThanh);
    }
}
