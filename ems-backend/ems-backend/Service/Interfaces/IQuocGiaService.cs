using ems_backend.Models.RequestModel.QuocGiaRequest;
using ems_backend.Models.ResponseModels.DataQuocGia;

namespace ems_backend.Service.Interfaces
{
    public interface IQuocGiaService
    {
        Task<IEnumerable<DataResponseQuocGia>> LayTatCaQuocGia();
        Task<DataResponseQuocGia> LayQuocGiaTheoId(int id);
        Task<DataResponseQuocGia> ThemQuocGia(Request_ThemQuocGia request);
        Task<DataResponseQuocGia> SuaQuocGia(int id, Request_SuaQuocGia request);
        Task<bool> XoaQuocGia(int id);
        Task<bool> CheckTenQuocGiaExists(string tenQuocGia);
    }
}
