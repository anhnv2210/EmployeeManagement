using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataPhucLoi;

namespace ems_backend.Models.Converters
{
    public class PhucLoiConverter
    {
        public static DataResponsePhucLoi EntityToDTO(PhucLoi phucLoi)
        {
            return new DataResponsePhucLoi()
            {
                Id = phucLoi.Id,
                TenPhucLoi = phucLoi.TenPhucLoi,
                MoTa = phucLoi.MoTa,
                NguoiTaoId = phucLoi.NguoiTaoId,
                NguoiCapNhatId = phucLoi.NguoiCapNhatId,
                NguoiTaoHoTen = phucLoi.NguoiTao?.Hoten,
                NgayTao = (DateTime)phucLoi.NgayTao,
                NguoiCapNhatHoTen = phucLoi.NguoiCapNhat?.Hoten,
                NgayCapNhat = (DateTime)phucLoi.NgayCapNhat,
                IsActive = phucLoi.IsActive
            };
        }
    }
}
