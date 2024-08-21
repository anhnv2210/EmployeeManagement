using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.QuocGiaRequest;
using ems_backend.Models.ResponseModels.DataQuocGia;

namespace ems_backend.Service.Interfaces
{
    public interface IQuocGiaService
    {
        Task<PageResult<DataResponseQuocGia>> LayTatCaQuocGia(int pageSize = 10, int pageNumber = 1);
        Task<DataResponseQuocGia> LayQuocGiaTheoId(int id);
        Task<DataResponseQuocGia> ThemQuocGia(Request_ThemQuocGia request);
        Task<DataResponseQuocGia> SuaQuocGia(int id, Request_SuaQuocGia request);
        Task<bool> XoaQuocGia(int id);
        Task<bool> CheckTenQuocGiaExists(string tenQuocGia);
    }
}
