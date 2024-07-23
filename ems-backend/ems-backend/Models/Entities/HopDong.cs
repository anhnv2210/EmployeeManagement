namespace ems_backend.Models.Entities
{
    public class HopDong : BaseEntity
    {
        public int NhanVienId { get; set; }
        public int LoaiHopDongId { get; set; }
        public int QuyetDinhId { get; set; }
        public int HoSoLuongId { get; set; }
        public string ChiTietHopDong { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public virtual LoaiHopDong? LoaiHopDong { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
        public virtual QuyetDinh? QuyetDinh { get; set; }
        public virtual HoSoLuong? HoSoLuong { get; set; }
    }
}
