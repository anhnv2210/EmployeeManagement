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
                NganHangId = chiNhanh.NganHangId,
                NganHangTen = chiNhanh.NganHang?.TenNganHang,
                NguoiTaoId = chiNhanh.NguoiTaoId,
                NguoiCapNhatId = chiNhanh.NguoiCapNhatId,
                NguoiTaoHoTen = chiNhanh.NguoiTao?.Hoten,
                NguoiCapNhatHoTen = chiNhanh.NguoiCapNhat?.Hoten,
                NgayTao = (DateTime)chiNhanh.NgayTao,
                NgayCapNhat = (DateTime)chiNhanh.NgayCapNhat,
                IsActive = chiNhanh.IsActive
            };
        }
    }
}
