namespace ems_backend.Models.RequestModel.LoaiHopDongRequest
{
    public class Request_ThemLoaiHopDong
    {
        public string TenLoaiHopDong {  get; set; }
        public string MoTa {  get; set; }
        public int NguoiTaoId {  get; set; }
        public int NguoiCapNhatId {  get; set; }
        public bool IsActive {  get; set; }

    }
}
