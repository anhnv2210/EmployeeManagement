namespace ems_backend.Models.RequestModel.PhucLoiRequest
{
    public class Request_SuaPhucLoi
    {
        public int Id {  get; set; }
        public string TenPhucLoi { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public bool IsActive { get; set; }
    }
}
