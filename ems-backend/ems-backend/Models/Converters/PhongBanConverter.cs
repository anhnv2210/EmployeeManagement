using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataPhongBan;

namespace ems_backend.Models.Converters
{
    public class PhongBanConverter
    {
        public static DataResponsePhongBan EntityToDTO(PhongBan phongBan)
        {
            return new DataResponsePhongBan()
            {
                Id = phongBan.Id,
                TenPhongBan = phongBan.TenPhongBan,
                MoTa = phongBan.MoTa,
                NguoiTaoId = phongBan.NguoiTaoId,
                NguoiCapNhatId = phongBan.NguoiCapNhatId,
                NguoiTaoHoTen = phongBan.NguoiTao?.Hoten,
                NgayTao = (DateTime) phongBan.NgayTao,
                NguoiCapNhatHoTen = phongBan.NguoiCapNhat?.Hoten,
                NgayCapNhat = (DateTime)phongBan.NgayCapNhat,
                IsActive = phongBan.IsActive,
            };
        }
    }
}
