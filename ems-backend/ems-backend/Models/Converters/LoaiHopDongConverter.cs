using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataLoaiHopDong;

namespace ems_backend.Models.Converters
{
    public class LoaiHopDongConverter
    {
        public static DataResponseLoaiHopDong EntityToDTO(LoaiHopDong loaiHopDong)
        {
            return new DataResponseLoaiHopDong()
            {
                Id = loaiHopDong.Id,
                TenLoaiHopDong = loaiHopDong.TenLoaiHopDong,
                MoTa = loaiHopDong.MoTa,
                NguoiTaoId = loaiHopDong.NguoiTaoId,
                NguoiCapNhatId = loaiHopDong.NguoiCapNhatId,
                NguoiTaoHoTen = loaiHopDong.NguoiTao?.Hoten,
                NgayTao = (DateTime)loaiHopDong.NgayTao,
                NguoiCapNhatHoTen = loaiHopDong.NguoiCapNhat?.Hoten,
                NgayCapNhat = (DateTime)loaiHopDong.NgayCapNhat,
                IsActive = loaiHopDong.IsActive,
            };
        }
    }
}
