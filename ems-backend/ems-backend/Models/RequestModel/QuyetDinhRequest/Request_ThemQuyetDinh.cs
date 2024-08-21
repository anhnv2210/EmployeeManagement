namespace ems_backend.Models.RequestModel.QuyetDinhRequest
{
    public class Request_ThemQuyetDinh
    {
        public int NhanVienId {  get; set; }
        public int HoSoLuongId {  get; set; }
        public DateTime NgayQuyetDinh { get; set; }
        public string NoiDung { get; set; }
    }
}
