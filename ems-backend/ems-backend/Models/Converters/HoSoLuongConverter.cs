using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataHoSoLuong;

namespace ems_backend.Models.Converters
{
    public class HoSoLuongConverter
    {
        public static DataResponseHoSoLuong EntityToDTO(HoSoLuong hoSoLuong)
        {
            return new DataResponseHoSoLuong()
            {
                Id = hoSoLuong.Id,
                NhanVienId = hoSoLuong.NhanVienId,
                PhongBanId = hoSoLuong.PhongBanId,
                ChucDanhId = hoSoLuong.ChucDanhId,
                ThangLuong = hoSoLuong.ThangLuong,
                BacLuong = hoSoLuong.BacLuong,
                LuongMax = hoSoLuong.LuongMax,
                LuongMin = hoSoLuong.LuongMin,
                HoTenNhanVien = hoSoLuong.NhanVien?.Hoten,
                TenPhongBan = hoSoLuong.PhongBan?.TenPhongBan,
                TenChucDanh = hoSoLuong.ChucDanh?.TenChucDanh,
                TenNhanVienKemChucDanh = hoSoLuong.NhanVien?.Hoten + " - " + hoSoLuong.ChucDanh?.TenChucDanh
            };
        } 
    }
}
