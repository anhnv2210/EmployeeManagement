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
                NgaySinh = nhanVien.NgaySinh,
                SoDienThoai = nhanVien.SoDienThoai,
                Email = nhanVien.Email,
                XaPhuongId = nhanVien.XaPhuongId,
                QuanHuyenId =  nhanVien.QuanHuyenId,
                TinhThanhId = nhanVien.TinhThanhId,
                QuocGiaId = nhanVien.QuocGiaId,
                PhongBanId = nhanVien.PhongBanId,
                ChucDanhId = nhanVien.ChucDanhId,
                NganHangId = nhanVien.NganHangId,
                ChiNhanhNganHangId =  nhanVien.ChiNhanhNganHangId,
                NoiKhamBenhId = nhanVien.NoiKhamBenhId,
                NguoiTaoId = nhanVien.NguoiTaoId,
                NguoiCapNhatId =  nhanVien.NguoiCapNhatId,
                TenXaPhuong = nhanVien.XaPhuong?.TenXaPhuong,
                TenQuanHuyen = nhanVien.QuanHuyen?.TenQuanHuyen,
                TenTinhThanh = nhanVien.TinhThanh?.TenTinhThanh,
                TenQuocGia = nhanVien.QuocGia?.TenQuocGia,
                TenPhongBan = nhanVien.PhongBan?.TenPhongBan,
                TenChucDanh = nhanVien.ChucDanh?.TenChucDanh,
                TenNganHang = nhanVien.NganHang?.TenNganHang,
                TenChiNhanhNganHang = nhanVien.ChiNhanhNganHang?.TenChiNhanhNganHang,
                TenNoiKhamBenh = nhanVien.NoiKhamBenh?.TenNoiKhamBenh,
                NguoiTaoTen = nhanVien.NguoiTao?.Hoten,
                NgayTao = nhanVien.NgayTao,
                NguoiCapNhatTen = nhanVien.NguoiCapNhat?.Hoten,
                NgayCapNhat = (DateTime) nhanVien.NgayCapNhat,
                NgayBatDauLamViec = (DateTime) nhanVien.NgayBatDauLamViec,
                NgayKetThucLamViec = (DateTime)nhanVien.NgayKetThucLamViec,
                AnhDaiDien = nhanVien.AnhDaiDien,
                TrangThai = nhanVien.TrangThai
            };
        }
    }
}
