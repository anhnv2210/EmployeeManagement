using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataNhanVien;

namespace ems_backend.Models.Converters
{
    public class NhanVienConverter
    {
        public static DataResponseNhanVien EntityToDTO(NhanVien nhanVien)
        {
            return new DataResponseNhanVien()
            {
                Id = nhanVien.Id,
                HoTen = nhanVien.Hoten,
                GioiTinh = nhanVien.GioiTinh,
                SoDienThoai = nhanVien.SoDienThoai,
                Email = nhanVien.Email,
                XaPhuongTen = nhanVien.XaPhuong?.TenXaPhuong,
                QuanHuyenTen = nhanVien.QuanHuyen?.TenQuanHuyen,
                TinhThanhTen = nhanVien.TinhThanh?.TenTinhThanh,
                PhongBanTen = nhanVien.PhongBan?.TenPhongBan,
                ChucDanhTen = nhanVien.ChucDanhPhongBan?.ChucDanh?.TenChucDanh,
                NganHangTen = nhanVien.NganHang?.TenNganHang,
                ChiNhanhTen = nhanVien.ChiNhanhNganHang?.TenChiNhanhNganHang,
                NoiKhamBenhTen = nhanVien.NoiKhamBenh?.TenNoiKhamBenh,
                NguoiTaoTen = nhanVien.NguoiTao?.Hoten,
                NgayTao = (DateTime)nhanVien.NgayTao,
                NguoiCapNhatTen = nhanVien.NguoiCapNhat?.Hoten,
                NgayCapNhat = (DateTime)nhanVien.NgayCapNhat,
                TrangThai = nhanVien.TrangThai
            };
        }
    }
}
