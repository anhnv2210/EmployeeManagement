namespace ems_backend.Models.Entities
{
    public class ChucDanhPhongBan:BaseEntity
    {
        public int PhongBanId { get; set; }
        public int ChucDanhId { get; set; }
        public virtual PhongBan? PhongBan { get; set; }
        public virtual ChucDanh? ChucDanh { get; set; }
        public virtual ICollection<NhanVien>? NhanViens { get; set; }
    }
}