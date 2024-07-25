using ems_backend.Models.Entities;

namespace ems_backend.Models.RequestModel.TaiSanRequest
{
    public class Request_ThemTaiSan
    {
        public string TenTaiSan { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public bool IsActive { get; set; }
    }
}
