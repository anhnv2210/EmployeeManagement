namespace ems_backend.Models.Entities
{
    public class KyLuat : BaseEntity
    {
        public int NhanVienId { get; set; }
        public string LoaiKyLuat { get; set; }
        public DateTime NgayKyLuat { get; set; }
        public string NoiDung { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
    }
}
