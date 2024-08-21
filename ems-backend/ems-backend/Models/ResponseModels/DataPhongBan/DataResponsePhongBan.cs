namespace ems_backend.Models.ResponseModels.DataPhongBan
{
    public class DataResponsePhongBan:DataResponseBase
    {
        public string TenPhongBan { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public string NguoiTaoHoTen { get; set; }
        public string NguoiCapNhatHoTen { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public bool IsActive { get; set; }
    }
}
