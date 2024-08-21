namespace ems_backend.Models.Entities
{
    public class Reminder : BaseEntity
    {
        public int NhanVienId { get; set; }
        public string HoTenNhanVien { get; set; } 
        public string LoaiSuKien { get; set; }
        public DateTime NgayCuThe { get; set; }
    }
}
