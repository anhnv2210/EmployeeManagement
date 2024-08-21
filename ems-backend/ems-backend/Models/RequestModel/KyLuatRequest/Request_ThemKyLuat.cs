namespace ems_backend.Models.RequestModel.KyLuatRequest
{
    public class Request_ThemKyLuat
    {
        public int NhanVienId { get; set; }
        public string LoaiKyLuat { get; set; }
        public DateTime NgayKyLuat { get; set; }
        public string NoiDung { get; set; }
    }
}
