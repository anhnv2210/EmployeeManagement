using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataXaPhuong;

namespace ems_backend.Models.Converters
{
    public class XaPhuongConverter
    {
        public static DataResponseXaPhuong EntityToDTO(XaPhuong xaPhuong)
        {
            return new DataResponseXaPhuong()
            {
                Id = xaPhuong.Id,
                MoTa = xaPhuong.MoTa,
                TenXaPhuong = xaPhuong.TenXaPhuong,
                TenQuanHuyen = xaPhuong.QuanHuyen?.TenQuanHuyen,
                TenTinhThanh = xaPhuong.TinhThanh?.TenTinhThanh,
                TenQuocGia = xaPhuong.QuocGia?.TenQuocGia,
                TenNguoiTao = xaPhuong.NguoiTao?.Hoten,
                TenNguoiCapNhat = xaPhuong.NguoiCapNhat?.Hoten,
                NgayTao = (DateTime) xaPhuong.NgayTao,
                NgayCapNhat = (DateTime)xaPhuong.NgayCapNhat,
                IsActive = xaPhuong.IsActive,
            };
        }
    }
}
