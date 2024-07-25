using ems_backend.Models.RequestModel.TaiSanRequest;
using ems_backend.Models.ResponseModels.DataTaiSan;

namespace ems_backend.Service.Interfaces
{
    public interface ITaiSanService
    {
        Task<IEnumerable<DataResponseTaiSan>> LayTatCaTaiSan();
        Task<DataResponseTaiSan> LayTaiSanTheoId(int id);
        Task<DataResponseTaiSan> ThemTaiSan(Request_ThemTaiSan request);
        Task<DataResponseTaiSan> SuaTaiSan(int id, Request_SuaTaiSan request);
        Task<bool> XoaTaiSan(int id);
        Task<bool> CheckTenTaiSanExists(string tenTaiSan);
    }
}
