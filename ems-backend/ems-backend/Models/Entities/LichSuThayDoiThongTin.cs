namespace ems_backend.Models.Entities
{
    public class LichSuThayDoiThongTin : BaseEntity
    {
        public int NhanVienId {  get; set; }
        public virtual NhanVien? NhanVien { get; set; }
        public string TenThuocTinh {  get; set; }
        public string GiaTriCu { get; set; }
        public string GiaTriMoi {  get; set; }
        public DateTime NgayThayDoi {  get; set; }
        public string LyDoThayDoi { get; set; }

    }
}
