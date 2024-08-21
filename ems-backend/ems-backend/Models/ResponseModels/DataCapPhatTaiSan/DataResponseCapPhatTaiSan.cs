namespace ems_backend.Models.ResponseModels.DataCapPhatTaiSan
{
    public class DataResponseCapPhatTaiSan : DataResponseBase
    {
        public int NhanVienId { get; set; }
        public string HoTenNhanVien {  get; set; }
        public int TaiSanId { get; set; }
        public string TenTaiSan {  get; set; }
        public DateTime NgayCapPhat { get; set; }
        public DateTime NgayTraLai { get; set; }
        public string TinhTrang { get; set; }
    }
}
