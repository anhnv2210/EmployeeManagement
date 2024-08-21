namespace ems_backend.Models.RequestModel.KyLuatRequest
{
    public class Request_SuaKyLuat
    {
        public int Id { get; set; }
        public int NhanVienId { get; set; }
        public string LoaiKyLuat { get; set; }
        public DateTime NgayKyLuat { get; set; }
        public string NoiDung { get; set; }
    }
}
