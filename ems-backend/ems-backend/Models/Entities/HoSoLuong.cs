namespace ems_backend.Models.Entities
{
    public class HoSoLuong : BaseEntity
    {
        public int NhanVienId { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
        public int PhongBanId { get; set; }
        public virtual PhongBan? PhongBan { get; set; }
        public int ChucDanhPhongBanId { get; set; }

        // thang lương, bậc lương, rải lương 
        public string ThangLuong { get; set; }
        public string BacLuong { get; set; }
        public decimal LuongMin { get; set; }
        public decimal LuongMax { get; set; }
        public virtual ChucDanhPhongBan? ChucDanhPhongBan { get; set; }
        public virtual ICollection<HopDong>? HopDongs { get; set; }
        public virtual ICollection<HoSoLuong_PhuCap> HoSoLuongPhuCaps { get; set; }
        public virtual ICollection<HoSoLuong_PhucLoi> HoSoLuongPhucLois { get; set; }
    }
}