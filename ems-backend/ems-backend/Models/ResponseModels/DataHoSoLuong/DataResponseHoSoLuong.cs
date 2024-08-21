namespace ems_backend.Models.ResponseModels.DataHoSoLuong
{
    public class DataResponseHoSoLuong : DataResponseBase
    {
        public int NhanVienId { get; set; }
        public string HoTenNhanVien {  get; set; }
        public string TenNhanVienKemChucDanh { get; set; }
        public int PhongBanId { get; set; }
        public string TenPhongBan {  get; set; }
        public int ChucDanhId { get; set; }
        public string TenChucDanh {  get; set; }
        public string ThangLuong { get; set; }
        public string BacLuong { get; set; }
        public decimal LuongMin { get; set; }
        public decimal LuongMax { get; set; }
    }
}
