namespace ems_backend.Models.RequestModel.NganHangRequest
{
    public class Request_SuaNganHang
    {
        public int Id { get; set; }
        public string TenNganHang {  get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId {  get; set; }
        public int NguoiCapNhatId { get; set; }
        public bool IsActive {  get; set; }
    }
}
