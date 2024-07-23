namespace ems_backend.Models.Entities
{
    public class HoSoLuong_PhuCap : BaseEntity
    {
        public int HoSoLuongId { get; set; }
        public int PhuCapId { get; set; }
        public decimal SoTien { get; set; }
        public virtual HoSoLuong? HoSoLuong { get; set; }
        public virtual PhuCap? PhuCap { get; set; }
    }
}