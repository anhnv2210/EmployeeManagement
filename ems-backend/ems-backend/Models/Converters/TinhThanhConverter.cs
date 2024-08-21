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
                QuocGiaId = tinhThanh.QuocGiaId,
                TenQuocGia = tinhThanh.QuocGia?.TenQuocGia,
                MoTa = tinhThanh.MoTa
            };
        }
    }
}
