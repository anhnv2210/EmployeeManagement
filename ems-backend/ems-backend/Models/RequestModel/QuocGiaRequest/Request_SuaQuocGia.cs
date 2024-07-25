namespace ems_backend.Models.RequestModel.QuocGiaRequest
{
    public class Request_SuaQuocGia
    {
        public int Id { get; set; }
        public string TenQuocGia { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public bool IsActive { get; set; }
    }
}
