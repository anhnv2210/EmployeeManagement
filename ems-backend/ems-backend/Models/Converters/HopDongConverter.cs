using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataHopDongLaoDong;

namespace ems_backend.Models.Converters
{
    public class HopDongConverter
    {
        public static DataResponseHopDong EntityToDTO(HopDong entity)
        {
            return new DataResponseHopDong
            {
                Id = entity.Id,
                NhanVienId = entity.NhanVienId,
                HoSoLuongId = entity.HoSoLuongId,
                HoTenNhanVien = entity.NhanVien?.Hoten,
                LoaiHopDongId = entity.LoaiHopDongId,
                TenLoaiHopDong = entity.LoaiHopDong?.TenLoaiHopDong,
                ChiTietHopDong = entity.ChiTietHopDong,
                TenNhanVienKemChucDanh = entity.NhanVien?.Hoten + " - " + entity.NhanVien?.ChucDanh?.TenChucDanh,
                NgayBatDau = entity.NgayBatDau,
                NgayKetThuc = entity.NgayKetThuc
            };
        }
    }
}
