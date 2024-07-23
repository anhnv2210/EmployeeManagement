namespace ems_backend.Models.Entities
{
    public class NguoiThanNhanVien : BaseEntity
    {
        public int NhanVienId { get; set; }
        public string TenNguoiThan { get; set; }
        public string QuanHe { get; set; }
        public DateTime NgaySinh { get; set; }
        public decimal GiamTruGiaCanh { get; set; }
        public DateTime NgayBatDauGiaGiam { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
    }
}
