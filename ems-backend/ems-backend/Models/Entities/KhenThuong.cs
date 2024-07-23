namespace ems_backend.Models.Entities
{
    public class KhenThuong : BaseEntity
    {
        public int NhanVienId { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
        public string LoaiKhenThuong { get; set; }
        public DateTime NgayKhenThuong { get; set; }
    }
}
