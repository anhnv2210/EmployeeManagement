namespace ems_backend.Models.ResponseModels.DataKhenThuong
{
    public class DataResponseKhenThuong : DataResponseBase
    {
        public int NhanVienId { get; set; }
        public string HoTenNhanVien {  get; set; }
        public string LoaiKhenThuong { get; set; }
        public DateTime NgayKhenThuong { get; set; }
    }
}
