using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.ResponsePhuCap;

namespace ems_backend.Models.Converters
{
    public class PhuCapConverter
    {
        public static DataResponsePhuCap EntityToDTO(PhuCap phuCap)
        {
            return new DataResponsePhuCap()
            {
                Id = phuCap.Id,
                TenPhuCap = phuCap.TenPhuCap,
                MoTa = phuCap.MoTa,
                NguoiTaoId = phuCap.NguoiTaoId,
                NguoiCapNhatId = phuCap.NguoiCapNhatId,
                NguoiTaoHoTen = phuCap.NguoiTao?.Hoten,
                NgayTao = (DateTime)phuCap.NgayTao,
                NguoiCapNhatHoTen = phuCap.NguoiCapNhat?.Hoten,
                NgayCapNhat = (DateTime)phuCap.NgayCapNhat,
                IsActive = phuCap.IsActive,
            };
        }
    }
}
