using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.QuyetDinhRequest;
using ems_backend.Models.ResponseModels.DataHopDongLaoDong;

namespace ems_backend.Service.Interfaces
{
    public interface IQuyetDinhService
    {
        Task<PageResult<DataResponseQuyetDinh>> LayTatCaQuyetDinh(int pageSize = 10, int pageNumber = 1);
        Task<DataResponseQuyetDinh> LayQuyetDinhTheoId(int id);
        Task<DataResponseQuyetDinh> ThemQuyetDinh(Request_ThemQuyetDinh request);
        Task<DataResponseQuyetDinh> SuaQuyetDinh(int id, Request_SuaQuyetDinh request);
        Task<bool> XoaQuyetDinh(int id);
    }
}
