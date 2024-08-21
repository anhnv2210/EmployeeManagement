namespace ems_backend.Models.ResponseModels.DataHopDongLaoDong
{
    public class DataResponseHopDong : DataResponseBase
    {
        public int NhanVienId { get; set; }
        public string HoTenNhanVien { get; set; }
        public int HoSoLuongId { get; set; }
        public string TenNhanVienKemChucDanh { get; set; }
        public int LoaiHopDongId { get; set; }
        public string TenLoaiHopDong {  get; set; }
        public int QuyetDinhId { get; set; }
        public string ChiTietHopDong { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
    }
}
