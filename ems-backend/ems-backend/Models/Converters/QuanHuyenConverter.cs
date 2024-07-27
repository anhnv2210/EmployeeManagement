using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataQuanHuyen;

namespace ems_backend.Models.Converters
{
    public class QuanHuyenConverter
    {
        public static DataResponseQuanHuyen EntityToDTO(QuanHuyen quanHuyen)
        {
            return new DataResponseQuanHuyen()
            {
                Id = quanHuyen.Id,
                TenQuanHuyen = quanHuyen.TenQuanHuyen,
                MoTa = quanHuyen.MoTa,
                TenQuocGia = quanHuyen.QuocGia?.TenQuocGia,
                TenTinhThanh = quanHuyen.TinhThanh?.TenTinhThanh,
                TenNguoiTao = quanHuyen.NguoiTao?.Hoten,
                NgayTao = (DateTime)quanHuyen.NgayTao,
                TenNguoiCapNhat = quanHuyen.NguoiCapNhat?.Hoten,
                NgayCapNhat = (DateTime)quanHuyen.NgayCapNhat,
                IsActive = quanHuyen.IsActive,
            };
        }
    }
}
