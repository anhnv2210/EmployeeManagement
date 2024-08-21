using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataHoSoLuong;

namespace ems_backend.Models.Converters
{
    public class HoSoLuongPhucLoiConverter
    {
        public static DataResponseHoSoLuongPhucLoi EntityToDTO(HoSoLuong_PhucLoi entiTy)
        {
            return new DataResponseHoSoLuongPhucLoi()
            {
                Id = entiTy.Id,
                PhucLoiId = entiTy.PhucLoiId,
                HoSoLuongId = entiTy.HoSoLuongId,
                TenPhucLoi = entiTy.PhucLoi?.TenPhucLoi,
            };
        }
    }
}
