using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataTinhThanh;

namespace ems_backend.Models.Converters
{
    public class TinhThanhConverter
    {
        public static DataResponseTinhThanh EntityToDTO(TinhThanh tinhThanh)
        {
            return new DataResponseTinhThanh()
            {
                Id = tinhThanh.Id,
                TenTinhThanh = tinhThanh.TenTinhThanh,
                TenQuocGia = tinhThanh.QuocGia?.TenQuocGia,
                TenNguoiTao = tinhThanh.NguoiTao?.Hoten,
                NgayTao = (DateTime)tinhThanh.NgayTao,
                TenNguoiCapNhat = tinhThanh.NguoiCapNhat?.Hoten,
                NgayCapNhat = (DateTime)tinhThanh.NgayCapNhat,
                IsActive = tinhThanh.IsActive,
            };
        }
    }
}
