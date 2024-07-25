namespace ems_backend.Models.RequestModel.TaiSanRequest
{
    public class Request_SuaTaiSan
    {
        public int Id { get; set; }
        public string TenTaiSan { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public bool IsActive { get; set; }
    }
}
