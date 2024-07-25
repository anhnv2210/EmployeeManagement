using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataTaiSan;

namespace ems_backend.Models.Converters
{
    public class TaiSanConverter
    {
        public static DataResponseTaiSan EntityToDTO(TaiSan taiSan)
        {
            return new DataResponseTaiSan()
            {
                Id = taiSan.Id,
                TenTaiSan = taiSan.TenTaiSan,
                MoTa = taiSan.MoTa,
                NguoiTaoHoTen = taiSan.NguoiTao?.Hoten,
                NguoiCapNhatHoTen = taiSan.NguoiCapNhat?.Hoten,
                NgayTao = (DateTime)taiSan.NgayTao,
                NgayCapNhat = (DateTime)taiSan.NgayCapNhat,
                IsActive = taiSan.IsActive
            };
        }
    }
}
