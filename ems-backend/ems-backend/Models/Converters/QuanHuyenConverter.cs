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
                QuocGiaId = quanHuyen.QuocGiaId,
                TinhThanhId = quanHuyen.TinhThanhId

            };
        }
    }
}
