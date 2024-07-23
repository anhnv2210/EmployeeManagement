namespace ems_backend.Models.Entities
{
    public class TapTinDinhKem : BaseEntity
    {
        public int NhanVienId { get; set; }
        public string TenTapTin { get; set; }
        public string DuongDan { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
    }
}
