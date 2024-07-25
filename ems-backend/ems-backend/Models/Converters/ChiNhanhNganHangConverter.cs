using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataChiNhanhNganHang;

namespace ems_backend.Models.Converters
{
    public class ChiNhanhNganHangConverter
    {
        public static DataResponseChiNhanhNganHang EntityToDTO(ChiNhanhNganHang chiNhanh)
        {
            return new DataResponseChiNhanhNganHang()
            {
                Id = chiNhanh.Id,
                TenChiNhanhNganHang = chiNhanh.TenChiNhanhNganHang,
                Email = chiNhanh.Email,
                SoDienThoai = chiNhanh.SDT,
                DiaChi = chiNhanh.DiaChi,
                MoTa = chiNhanh.MoTa,
                NganHangTen = chiNhanh.NganHang?.TenNganHang,
                NguoiTaoHoTen = chiNhanh.NguoiTao?.Hoten,
                NguoiCapNhatHoTen = chiNhanh.NguoiCapNhat?.Hoten,
                NgayTao = (DateTime)chiNhanh.NgayTao,
                NgayCapNhat = (DateTime)chiNhanh.NgayCapNhat,
                IsActive = chiNhanh.IsActive
            };
        }
    }
}
