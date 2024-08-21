namespace ems_backend.Models.Entities
{
    public class QuanHuyen : BaseEntity
    {
        public string TenQuanHuyen { get; set; }
        public string MoTa { get; set; }
        public int QuocGiaId { get; set; }
        public virtual QuocGia? QuocGia { get; set; }
        public int TinhThanhId { get; set; }
        public virtual TinhThanh? TinhThanh { get; set; }
        public virtual ICollection<XaPhuong>? XaPhuongs { get; set; }
        public virtual ICollection<NhanVien>? NhanViens { get; set; }
    }
}