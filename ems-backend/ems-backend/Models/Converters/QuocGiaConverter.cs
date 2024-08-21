using ems_backend.Models.Entities;
using ems_backend.Models.ResponseModels.DataQuocGia;

namespace ems_backend.Models.Converters
{
    public class QuocGiaConverter
    {
        public static DataResponseQuocGia EntityToDTO(QuocGia quocGia)
        {
            return new DataResponseQuocGia()
            {
                Id = quocGia.Id,
                TenQuocGia = quocGia.TenQuocGia,
                MoTa = quocGia.MoTa,
            };
        }
    }
}
