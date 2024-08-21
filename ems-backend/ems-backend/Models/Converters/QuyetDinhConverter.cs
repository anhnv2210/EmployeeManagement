using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataHopDongLaoDong;

namespace ems_backend.Models.Converters
{
    public class QuyetDinhConverter
    {
        public static DataResponseQuyetDinh EntityToDTO(QuyetDinh quyetDinh)
        {
            return new DataResponseQuyetDinh() { 
                Id = quyetDinh.Id,
                NhanVienId = quyetDinh.NhanVienId,
                HoTenNhanVien = quyetDinh.NhanVien?.Hoten,
                HoSoLuongId = quyetDinh.HoSoLuongId,
                TenNhanVienKemChucDanh = quyetDinh.NhanVien?.Hoten +" - " +quyetDinh.NhanVien?.ChucDanh?.TenChucDanh,
                NgayQuyetDinh = quyetDinh.NgayQuyetDinh,
                NoiDung = quyetDinh.NoiDung
            };
        }
    }
}
