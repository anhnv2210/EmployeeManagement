namespace ems_backend.Models.Entities
{
    public class PhongBan:BaseEntity
    {
        public string TenPhongBan { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId { get; set; }
        public DateTime? NgayTao { get; set; }
        public int NguoiCapNhatId { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public NhanVien? NguoiTao { get; set; }
        public NhanVien? NguoiCapNhat { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<NhanVien>? NhanViens { get; set; }
        public virtual ICollection<ChucDanhPhongBan>? ChucDanhPhongBans { get; set; }
    }
}