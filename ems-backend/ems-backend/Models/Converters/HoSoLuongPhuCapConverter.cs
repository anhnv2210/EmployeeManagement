using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels;
using ems_backend.Models.ResponseModels.DataHoSoLuong;

namespace ems_backend.Models.Converters
{
    public class HoSoLuongPhuCapConverter
    {
        public static DataResponseHoSoLuongPhuCap EntityToDTO(HoSoLuong_PhuCap entiTy)
        {
            return new DataResponseHoSoLuongPhuCap()
            {
                Id = entiTy.Id,
                PhuCapId = entiTy.PhuCapId,
                HoSoLuongId = entiTy.HoSoLuongId,
                TenPhuCap = entiTy.PhuCap?.TenPhuCap,
                SoTien = entiTy.SoTien
            };
        }
    }
}
