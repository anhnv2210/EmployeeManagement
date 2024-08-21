namespace ems_backend.Models.ResponseModels.DataNghiViec
{
    public class DataResponseNghiViec : DataResponseBase
    {
        public int NhanVienId { get; set; }
        public string HoTenNhanVien {  get; set; }
        public DateTime NgayNghiViec { get; set; }
        public string LyDo { get; set; }
    }
}
