namespace ems_backend.Models.ResponseModels.DataChucDanh
{
    public class DataResponseChucDanh : DataResponseBase
    {
        public string TenChucDanh { get; set; }
        public string MoTa { get; set; }
        public string NguoiTaoHoTen { get; set; }
        public string NguoiCapNhatHoTen { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public bool IsActive { get; set; }
    }
}
