namespace ems_backend.Models.Entities
{
    public class HoSoLuong_PhucLoi : BaseEntity
    {
        public int HoSoLuongId { get; set; }
        public int PhucLoiId { get; set; }
        public virtual HoSoLuong? HoSoLuong { get; set; }
        public virtual PhucLoi? PhucLoi { get; set; }
    }
}