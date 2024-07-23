using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataChucDanh;

namespace ems_backend.Models.Converters
{
    public class ChucDanhConverter
    {
        public static DataResponseChucDanh EntityToDTO(ChucDanh chucDanh)
        {
            return new DataResponseChucDanh()
            {
                Id = chucDanh.Id,
                TenChucDanh = chucDanh.TenChucDanh,
                MoTa = chucDanh.MoTa,
                NguoiTaoHoTen = chucDanh.NguoiTao?.Hoten,
                NguoiCapNhatHoTen = chucDanh.NguoiCapNhat?.Hoten,
                NgayTao = chucDanh.NgayTao,
                NgayCapNhat = chucDanh.NgayCapNhat,
                IsActive = chucDanh.IsActive
            };
        }
    }
}
