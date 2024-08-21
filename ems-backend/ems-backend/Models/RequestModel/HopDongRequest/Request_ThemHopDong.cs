namespace ems_backend.Models.RequestModel.HopDongRequest
{
    public class Request_ThemHopDong
    {
        public int NhanVienId { get; set; }
        public int LoaiHopDongId { get; set; }
        public int QuyetDinhId { get; set; }
        public int HoSoLuongId { get; set; }
        public string ChiTietHopDong { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
    }
}
