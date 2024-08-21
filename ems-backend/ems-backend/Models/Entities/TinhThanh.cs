namespace ems_backend.Models.Entities
{
    public class TinhThanh : BaseEntity
    {
        public string TenTinhThanh { get; set; }
        public string MoTa { get; set; }
        public int QuocGiaId {  get; set; }
        public QuocGia? QuocGia { get; set; }
        public virtual ICollection<QuanHuyen>? QuanHuyens { get; set; }
        public virtual ICollection<XaPhuong>? XaPhuongs { get; set; }
        public virtual ICollection<NhanVien>? NhanViens { get; set; }
    }
}