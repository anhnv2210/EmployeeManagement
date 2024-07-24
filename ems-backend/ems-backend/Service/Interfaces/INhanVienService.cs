

using ems_backend.Models.ResponseModels.DataNhanVien;

namespace ems_backend.Service.Interfaces
{
    public interface INhanVienService
    {
        Task<IEnumerable<DataResponseNhanVien>> LayTatCaNhanVien();
    }
}
