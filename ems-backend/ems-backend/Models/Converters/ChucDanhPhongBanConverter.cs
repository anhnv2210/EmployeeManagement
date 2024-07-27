using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataChucDanhPhongBan;

namespace ems_backend.Models.Converters
{
    public class ChucDanhPhongBanConverter
    {
        public static DataResponseChucDanhPhongBan EntityToDTO(ChucDanhPhongBan chucDanhPhongBan)
        {
            return new DataResponseChucDanhPhongBan()
            {
                Id = chucDanhPhongBan.Id,
                TenPhongBan = chucDanhPhongBan.PhongBan?.TenPhongBan,
                TenChucDanh = chucDanhPhongBan.ChucDanh?.TenChucDanh,
            };
        }
    }
}
