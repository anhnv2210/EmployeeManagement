namespace ems_backend.Models.Entities
{
    public class ChiNhanhNganHang : BaseEntity
    {
        public string TenChiNhanhNganHang { get; set; }
        public int NganHangId { set; get; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId { get; set; }
        public DateTime? NgayTao { get; set; }
        public int NguoiCapNhatId { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public NhanVien? NguoiTao { get; set; }
        public NhanVien? NguoiCapNhat { get; set; }
        public bool IsActive { get; set; }
        public virtual NganHang? NganHang { get; set; }
        public virtual ICollection<NhanVien>? NhanViens { get; set; }
    }
}
