namespace ems_backend.Models.Entities
{
    public class TinhThanh : BaseEntity
    {
        public string TenTinhThanh { get; set; }
        public string MoTa { get; set; }
        public int? QuocGiaId {  get; set; }
        public QuocGia? QuocGia { get; set; }
        public int NguoiTaoId { get; set; }
        public DateTime? NgayTao { get; set; }
        public int NguoiCapNhatId { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public NhanVien? NguoiTao { get; set; }
        public NhanVien? NguoiCapNhat { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<QuanHuyen>? QuanHuyens { get; set; }
        public virtual ICollection<NhanVien>? NhanViens { get; set; }
    }
}