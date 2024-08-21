using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataNghiViec;

namespace ems_backend.Models.Converters
{
    public class NghiViecConverter
    {
        public static DataResponseNghiViec EntityToDTO(NghiViec nghiViec)
        {
            return new DataResponseNghiViec()
            {
                Id = nghiViec.Id,
                NhanVienId = nghiViec.NhanVienId,
                HoTenNhanVien = nghiViec.NhanVien?.Hoten,
                LyDo = nghiViec.LyDo,   
            };
        }
    }
}
