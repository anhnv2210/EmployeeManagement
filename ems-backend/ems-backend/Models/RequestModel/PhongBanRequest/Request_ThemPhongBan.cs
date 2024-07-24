namespace ems_backend.Models.RequestModel.PhongBanRequest
{
    public class Request_ThemPhongBan
    {
        public string TenPhongBan { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public bool IsActive {  get; set; }
    }
}
