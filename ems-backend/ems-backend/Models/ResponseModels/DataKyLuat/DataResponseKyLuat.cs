namespace ems_backend.Models.ResponseModels.DataKyLuat
{
    public class DataResponseKyLuat : DataResponseBase
    {
        public int NhanVienId { get; set; }
        public string HoTenNhanVien {  get; set; }
        public string LoaiKyLuat { get; set; }
        public DateTime NgayKyLuat { get; set; }
        public string NoiDung { get; set; }
    }
}
