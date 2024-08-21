using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.RequestModel.KyLuatRequest;
using ems_backend.Models.RequestModel.NghiViecRequest;
using ems_backend.Models.ResponseModels.DataKyLuat;
using ems_backend.Models.ResponseModels.DataNghiViec;

namespace ems_backend.Service.Interfaces
{
    public interface INghiViecService
    {
        Task<PageResult<DataResponseNghiViec>> LayTatCaNghiViec(int pageSize, int pageNumber);
        Task<DataResponseNghiViec> LayNghiViecTheoId(int id);
        Task<DataResponseNghiViec> ThemNghiViec(Request_ThemNghiViec request);
        Task<DataResponseNghiViec> SuaNghiViec(int id, Request_SuaNghiViec request);
        Task<bool> XoaNghiViec(int id);
    }
}
