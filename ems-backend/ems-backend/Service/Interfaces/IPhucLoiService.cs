using ems_backend.Models.RequestModel.PhucLoiRequest;
using ems_backend.Models.ResponseModels.DataPhucLoi;

namespace ems_backend.Service.Interfaces
{
    public interface IPhucLoiService
    {
        Task<IEnumerable<DataResponsePhucLoi>> LayTatCaPhucLoi();
        Task<DataResponsePhucLoi> LayPhucLoiTheoId(int id);
        Task<DataResponsePhucLoi> ThemPhucLoi(Request_ThemPhucLoi request);
        Task<DataResponsePhucLoi> SuaPhucLoi(int id, Request_SuaPhucLoi request);
        Task<bool> XoaPhucLoi(int id);
        Task<bool> CheckTenPhucLoiExists(string tenPhucLoi);
    }
}
