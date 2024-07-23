namespace ems_backend.Models.Entities
{
    public class NghiViec : BaseEntity
    {
        public int NhanVienId { get; set; }
        public DateTime NgayNghiViec { get; set; }
        public string LyDo { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
    }
}
