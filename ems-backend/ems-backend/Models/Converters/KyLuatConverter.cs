using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataKyLuat;

namespace ems_backend.Models.Converters
{
    public class KyLuatConverter
    {
        public static DataResponseKyLuat EntityToDTO(KyLuat kyLuat)
        {
            return new DataResponseKyLuat()
            {
                Id = kyLuat.Id,
                NhanVienId = kyLuat.NhanVienId,
                HoTenNhanVien = kyLuat.NhanVien?.Hoten,
                LoaiKyLuat = kyLuat.LoaiKyLuat,
                NgayKyLuat = kyLuat.NgayKyLuat,
                NoiDung = kyLuat.NoiDung,
            };
        }
    }
}
