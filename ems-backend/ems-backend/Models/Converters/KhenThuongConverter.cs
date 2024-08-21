using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataKhenThuong;

namespace ems_backend.Models.Converters
{
    public class KhenThuongConverter
    {
        public static DataResponseKhenThuong EntityToDTO(KhenThuong khenThuong)
        {
            return new DataResponseKhenThuong()
            {
                Id = khenThuong.Id,
                NhanVienId = khenThuong.NhanVienId,
                HoTenNhanVien = khenThuong.NhanVien?.Hoten,
                LoaiKhenThuong = khenThuong.LoaiKhenThuong,
                NgayKhenThuong = khenThuong.NgayKhenThuong
            };
        }
    }
}
