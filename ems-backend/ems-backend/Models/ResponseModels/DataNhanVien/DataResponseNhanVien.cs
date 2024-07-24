namespace ems_backend.Models.ResponseModels.DataNhanVien
{
    public class DataResponseNhanVien : DataResponseBase
    {
        public string HoTen {  get; set; }
        public bool GioiTinh {  get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoDienThoai {  get; set; }
        public string Email {  get; set; }
        public string PhongBanTen {  get; set; }
        public string ChucDanhTen {  get; set; }
        public string XaPhuongTen { get; set; }
        public string QuanHuyenTen { get; set; }
        public string TinhThanhTen { get; set; }
        public string NganHangTen { get; set; }
        public string ChiNhanhTen { get; set; }
        public string NoiKhamBenhTen { get; set; }
        public string NguoiTaoTen { get; set; }
        public DateTime NgayTao { get; set; }
        public string NguoiCapNhatTen { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string TrangThai {  get; set; }
    }
}
