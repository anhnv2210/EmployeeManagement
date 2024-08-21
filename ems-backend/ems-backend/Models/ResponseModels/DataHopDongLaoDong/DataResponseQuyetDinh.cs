namespace ems_backend.Models.ResponseModels.DataHopDongLaoDong
{
    public class DataResponseQuyetDinh : DataResponseBase
    {
        public int NhanVienId {  get; set; }
        public string HoTenNhanVien {  get; set; }
        public int HoSoLuongId {  get; set; }
        public string TenNhanVienKemChucDanh {  get; set; }
        public DateTime NgayQuyetDinh {  get; set; }
        public string NoiDung {  get; set; }
    }
}
