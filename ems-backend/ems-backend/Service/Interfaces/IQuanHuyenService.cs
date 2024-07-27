using ems_backend.Models.RequestModel.QuanHuyenRequest;
using ems_backend.Models.ResponseModels.DataQuanHuyen;

namespace ems_backend.Service.Interfaces
{
    public interface IQuanHuyenService
    {
        Task<IEnumerable<DataResponseQuanHuyen>> LayTatCaQuanHuyen();
        Task<DataResponseQuanHuyen> LayQuanHuyenTheoId(int id);
        Task<DataResponseQuanHuyen> ThemQuanHuyen(Request_ThemQuanHuyen request);
        Task<DataResponseQuanHuyen> SuaQuanHuyen(int id, Request_SuaQuanHuyen request);
        Task<bool> XoaQuanHuyen(int id);
    }
}
