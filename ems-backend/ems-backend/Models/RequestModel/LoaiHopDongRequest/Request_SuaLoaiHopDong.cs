namespace ems_backend.Models.RequestModel.LoaiHopDongRequest
{
    public class Request_SuaLoaiHopDong
    {
        public int Id { get; set; }
        public string TenLoaiHopDong { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public bool IsActive { get; set; }
    }
}
