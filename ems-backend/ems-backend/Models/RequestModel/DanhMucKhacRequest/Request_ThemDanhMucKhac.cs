using ems_backend.Models.Entities;

namespace ems_backend.Models.RequestModel.DanhMucKhacRequest
{
    public class Request_ThemDanhMucKhac
    {
        public string TenThamSo { get; set; }
        public string GiaTri { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public bool IsActive { get; set; }
    }
}
