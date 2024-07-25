using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataNganHang;

namespace ems_backend.Models.Converters
{
    public class NganHangConverter
    {
        public static DataResponseNganHang EntityToDTO (NganHang nganHang)
        {
            return new DataResponseNganHang()
            {
                Id = nganHang.Id,
                TenNganHang = nganHang.TenNganHang,
                DiaChi = nganHang.DiaChi,
                Email = nganHang.Email,
                SDT = nganHang.SDT,
                MoTa = nganHang.MoTa,
                NguoiTaoHoTen = nganHang.NguoiTao?.Hoten,
                NguoiCapNhatHoTen = nganHang.NguoiCapNhat?.Hoten,
                NgayTao = (DateTime)nganHang.NgayTao,
                NgayCapNhat = (DateTime)nganHang.NgayCapNhat,
                IsActive = nganHang.IsActive,
            };
        }
    }
}
