using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataDanhMucKhac;

namespace ems_backend.Models.Converters
{
    public class DanhMucKhacConverter
    {
        public static DataResponseDanhMucKhac EntityToDTO(DanhMucKhac danhMucKhac)
        {
            return new DataResponseDanhMucKhac()
            {
                Id = danhMucKhac.Id,
                TenThamSo = danhMucKhac.TenThamSo,
                GiaTri = danhMucKhac.GiaTri,
                MoTa = danhMucKhac.MoTa,
                NguoiTaoId = danhMucKhac.NguoiTaoId,
                NguoiCapNhatId = danhMucKhac.NguoiCapNhatId,
                NguoiTaoHoTen = danhMucKhac.NguoiTao?.Hoten,
                NgayTao = (DateTime)danhMucKhac.NgayTao,
                NguoiCapNhatHoTen = danhMucKhac.NguoiCapNhat?.Hoten,
                NgayCapNhat = (DateTime)danhMucKhac.NgayCapNhat,
                IsActive = danhMucKhac.IsActive,
            };
        }
    }
}
