namespace ems_backend.Models.Entities
{
    public class CapPhatTaiSan : BaseEntity
    {
        public int NhanVienId { get; set; }
        public int TaiSanId { get; set; }
        public DateTime NgayCapPhat { get; set; }
        public DateTime NgayTraLai { get; set; }
        public string TinhTrang { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
        public virtual TaiSan? TaiSan { get; set; }
    }
}
