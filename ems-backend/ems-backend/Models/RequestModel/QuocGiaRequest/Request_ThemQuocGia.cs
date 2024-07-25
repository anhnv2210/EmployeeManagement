using ems_backend.Models.Entities;

namespace ems_backend.Models.RequestModel.QuocGiaRequest
{
    public class Request_ThemQuocGia
    {
        public string TenQuocGia { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public bool IsActive { get; set; }
    }
}
