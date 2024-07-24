namespace ems_backend.Models.RequestModel.PhuCapRequest
{
    public class Request_SuaPhuCap
    {
        public int Id { get; set; }
        public string TenPhuCap { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public bool IsActive { get; set; }
    }
}
