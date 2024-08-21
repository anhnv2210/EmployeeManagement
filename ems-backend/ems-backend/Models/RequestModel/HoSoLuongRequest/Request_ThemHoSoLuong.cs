namespace ems_backend.Models.RequestModel.HoSoLuongRequest
{
    public class Request_ThemHoSoLuong
    {
        public int NhanVienId {  get; set; }
        public int PhongBanId {  get; set; }
        public int ChucDanhId {  get; set; }
        public string ThangLuong { get; set; }
        public string BacLuong { get; set; }
        public decimal LuongMin { get; set; }
        public decimal LuongMax { get; set; }
    }
}
