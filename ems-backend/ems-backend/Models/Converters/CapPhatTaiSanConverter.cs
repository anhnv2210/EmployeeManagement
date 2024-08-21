using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataCapPhatTaiSan;

namespace ems_backend.Models.Converters
{
    public class CapPhatTaiSanConverter
    {
        public static DataResponseCapPhatTaiSan EntityToDTO(CapPhatTaiSan capPhatTaiSan)
        {
            return new DataResponseCapPhatTaiSan()
            {
                Id = capPhatTaiSan.Id,
                NhanVienId = capPhatTaiSan.NhanVienId,
                HoTenNhanVien = capPhatTaiSan.NhanVien?.Hoten,
                TaiSanId = capPhatTaiSan.TaiSanId,
                TenTaiSan = capPhatTaiSan.TaiSan?.TenTaiSan,
                NgayCapPhat = capPhatTaiSan.NgayCapPhat,
                NgayTraLai = capPhatTaiSan.NgayTraLai,
                TinhTrang = capPhatTaiSan.TinhTrang
            };
        }
    }
}
