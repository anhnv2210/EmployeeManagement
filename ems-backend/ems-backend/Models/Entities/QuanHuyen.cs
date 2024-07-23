namespace ems_backend.Models.Entities
{
    public class QuanHuyen : BaseEntity
    {
        public string TenQuanHuyen { get; set; }
        public int TinhThanhId { get; set; }
        public virtual TinhThanh? TinhThanh { get; set; }
        public int NguoiTaoId { get; set; }
        public DateTime? NgayTao { get; set; }
        public int NguoiCapNhatId { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public NhanVien? NguoiTao { get; set; }
        public NhanVien? NguoiCapNhat { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<XaPhuong>? XaPhuongs { get; set; }
        public virtual ICollection<NhanVien>? NhanVien { get; set; }
    }
}