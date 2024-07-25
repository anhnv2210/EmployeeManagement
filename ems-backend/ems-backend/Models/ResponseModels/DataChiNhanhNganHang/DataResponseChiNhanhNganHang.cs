namespace ems_backend.Models.ResponseModels.DataChiNhanhNganHang
{
    public class DataResponseChiNhanhNganHang : DataResponseBase
    {
        public string TenChiNhanhNganHang { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string MoTa { get; set; }
        public string NguoiTaoHoTen { get; set; }
        public string NguoiCapNhatHoTen { get; set; }
        public string NganHangTen { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public bool IsActive { get; set; }
    }
}
