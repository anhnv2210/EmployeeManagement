namespace ems_backend.Models.RequestModel.NhanVienRequest
{
    public class Request_SuaNhanVien
    {
        public int Id { get; set; } 
        public string Hoten { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public IFormFile? AnhDaiDien { get; set; }
        public int PhongBanId { get; set; }
        public int ChucDanhId { get; set; }
        public int XaPhuongId { get; set; }
        public int QuanHuyenId { get; set; }
        public int TinhThanhId { get; set; }
        public int QuocGiaId { get; set; }
        public int NganHangId { get; set; }
        public int ChiNhanhNganHangId { get; set; }
        public int NoiKhamBenhId { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public DateTime? NgayKetThucLamViec { get; set; }
    }
}
