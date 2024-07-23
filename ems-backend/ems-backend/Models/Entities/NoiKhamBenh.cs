namespace ems_backend.Models.Entities
{
    public class NoiKhamBenh : BaseEntity
    {
        public string TenNoiKhamBenh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string GhiChu { get; set; }
        public int NguoiTaoId { get; set; }
        public DateTime? NgayTao { get; set; }
        public int NguoiCapNhatId { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public NhanVien? NguoiTao { get; set; }
        public NhanVien? NguoiCapNhat { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<NhanVien>? NhanViens { get; set; }
    }
}