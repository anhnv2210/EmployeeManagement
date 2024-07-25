namespace ems_backend.Models.Entities
{
    public class NhanVien:BaseEntity
    {
        public string Hoten { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public int? PhongBanId { get; set; }
        public virtual PhongBan? PhongBan { get; set; }
        public int? ChucDanhPhongBanId { get; set; }
        public virtual ChucDanhPhongBan? ChucDanhPhongBan { get; set; }
        public int? XaPhuongId { get; set; }
        public virtual XaPhuong? XaPhuong { get; set; }
        public int? QuanHuyenId { get; set; }
        public virtual QuanHuyen? QuanHuyen { get; set; }
        public int? TinhThanhId { get; set; }
        public virtual TinhThanh? TinhThanh { get; set; }
        public int? QuocGiaId { get; set; }
        public virtual QuocGia? QuocGia { get; set; }
        public int? NganHangId { get; set; }
        public virtual NganHang? NganHang { get; set; }
        public int? ChiNhanhNganHangId { get; set; }
        public virtual ChiNhanhNganHang? ChiNhanhNganHang { get; set; }
        public int? NoiKhamBenhId { get; set; }
        public virtual NoiKhamBenh? NoiKhamBenh { get; set; }
        public int? NguoiTaoId { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? NguoiCapNhatId { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public NhanVien? NguoiTao { get; set; }
        public NhanVien? NguoiCapNhat { get; set; }
        public string TrangThai { get; set; }
        public virtual ICollection<HopDong>? HopDongs { get; set; }
        public virtual ICollection<QuyetDinh>? QuyetDinhs { get; set; }
        public virtual ICollection<TapTinDinhKem>? TapTinDinhKems { get; set; }
        public virtual ICollection<NguoiThanNhanVien>? NguoiThanNhanViens { get; set; }
        public virtual ICollection<HoSoLuong>? HoSoLuongs { get; set; }
        public virtual ICollection<KyLuat>? KyLuats { get; set; }
        public virtual ICollection<KhenThuong>? KhenThuongs { get; set; }
        public virtual ICollection<NghiViec>? NghiViecs { get; set; }
        public virtual ICollection<CapPhatTaiSan>? CapPhatTaiSans { get; set; }
    }
}