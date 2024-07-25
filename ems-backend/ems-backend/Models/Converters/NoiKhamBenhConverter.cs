using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataNoiKhamBenh;

namespace ems_backend.Models.Converters
{
    public class NoiKhamBenhConverter
    {
        public static DataResponseNoiKhamBenh EntityToDTO(NoiKhamBenh noiKhamBenh)
        {
            return new DataResponseNoiKhamBenh() { 
                Id = noiKhamBenh.Id,
                TenNoiKhamBenh = noiKhamBenh.TenNoiKhamBenh,
                DiaChi = noiKhamBenh.DiaChi,
                Email = noiKhamBenh.Email,
                SDT = noiKhamBenh.SDT,
                GhiChu = noiKhamBenh.GhiChu,
                NguoiTaoHoTen = noiKhamBenh.NguoiTao?.Hoten,
                NgayTao = (DateTime)noiKhamBenh.NgayTao,
                NguoiCapNhatHoTen = noiKhamBenh.NguoiCapNhat?.Hoten,
                NgayCapNhat = (DateTime)noiKhamBenh.NgayCapNhat,
                IsActive = noiKhamBenh.IsActive,
            };
        }
    }
}
