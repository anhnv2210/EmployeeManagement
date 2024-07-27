namespace ems_backend.Models.RequestModel.XaPhuongRequest
{
    public class Request_SuaXaPhuong
    {
        public int Id { get; set; }
        public string TenXaPhuong { get; set; }
        public string MoTa { get; set; }
        public int QuocGiaId { get; set; }
        public int TinhThanhId { get; set; }
        public int QuanHuyenId { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public bool IsActive { get; set; }
    }
}
