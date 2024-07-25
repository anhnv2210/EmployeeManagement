namespace ems_backend.Models.Entities
{
    public class XaPhuong : BaseEntity
    {
        public string TenXaPhuong { get; set; }
        public string MoTa { get; set; }
        public int QuocGiaId { get; set; }
        public virtual QuocGia? QuocGia { get; set; }
        public int TinhThanhId { get; set; }
        public virtual TinhThanh? TinhThanh { get; set; }
        public int QuanHuyenId { get; set; }
        public virtual QuanHuyen? QuanHuyen { get; set; }
        public int NguoiTaoId { get; set; }
        public DateTime? NgayTao { get; set; }
        public int NguoiCapNhatId { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public NhanVien? NguoiTao { get; set; }
        public NhanVien? NguoiCapNhat { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<NhanVien>? NhanViens { get; set; }
    }
}