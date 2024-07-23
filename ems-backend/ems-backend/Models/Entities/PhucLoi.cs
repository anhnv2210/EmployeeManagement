namespace ems_backend.Models.Entities
{
    public class PhucLoi : BaseEntity
    {
        public string TenPhucLoi { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId { get; set; }
        public DateTime? NgayTao { get; set; }
        public int NguoiCapNhatId { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public NhanVien? NguoiTao { get; set; }
        public NhanVien? NguoiCapNhat { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<HoSoLuong_PhucLoi> HoSoLuongPhucLois { get; set; }
    }
}