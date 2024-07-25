namespace ems_backend.Models.RequestModel.TinhThanhRequest
{
    public class Request_SuaTinhThanh
    {
        public int Id { get; set; }
        public string TenTinhThanh { get; set; }
        public string MoTa { get; set; }
        public int QuocGiaId { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public bool IsActive { get; set; }
    }
}
