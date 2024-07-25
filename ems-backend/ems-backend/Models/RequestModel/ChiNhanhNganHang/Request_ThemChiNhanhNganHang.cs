namespace ems_backend.Models.RequestModel.ChiNhanhNganHang
{
    public class Request_ThemChiNhanhNganHang
    {
        public string TenChiNhanhNganHang {  get; set; }
        public string DiaChi {  get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId {  get; set; }
        public int NguoiCapNhatId { get; set; }
        public int NganHangId {  get; set; }
        public bool IsActive {  get; set; }
    }
}
