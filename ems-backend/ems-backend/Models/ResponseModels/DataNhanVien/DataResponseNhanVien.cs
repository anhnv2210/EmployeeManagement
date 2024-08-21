namespace ems_backend.Models.ResponseModels.DataNhanVien
{
    public class DataResponseNhanVien : DataResponseBase
    {
        public string HoTen {  get; set; }
        public bool GioiTinh {  get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoDienThoai {  get; set; }
        public string Email {  get; set; }
        public int? PhongBanId {  get; set; }
        public string? TenPhongBan {  get; set; }
        public int? ChucDanhId {  get; set; }
        public string? TenChucDanh {  get; set; }
        public int? XaPhuongId {  get; set; }
        public string? TenXaPhuong { get; set; }
        public int? QuanHuyenId {  get; set; }
        public string? TenQuanHuyen { get; set; }
        public int? TinhThanhId {  get; set; }
        public string? TenTinhThanh { get; set; }
        public int? QuocGiaId { get; set; }
        public string? TenQuocGia {  get; set; }
        public int? NganHangId {  get; set; }
        public string? TenNganHang { get; set; }
        public int? ChiNhanhNganHangId { get; set; }
        public string? TenChiNhanhNganHang { get; set; }
        public int? NoiKhamBenhId {  get; set; }
        public string? TenNoiKhamBenh { get; set; }
        public int? NguoiTaoId {  get; set; }
        public string? NguoiTaoTen { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? NguoiCapNhatId {  get; set; }
        public string? NguoiCapNhatTen { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public DateTime? NgayBatDauLamViec {  get; set; }
        public string? AnhDaiDien {  get; set; }
        public string TrangThai {  get; set; }
        public DateTime? NgayKetThucLamViec { get; set; }
    }
}
