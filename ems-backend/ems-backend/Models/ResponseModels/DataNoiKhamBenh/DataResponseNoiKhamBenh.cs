namespace ems_backend.Models.ResponseModels.DataNoiKhamBenh
{
    public class DataResponseNoiKhamBenh : DataResponseBase
    {
        public string TenNoiKhamBenh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string GhiChu { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public string NguoiTaoHoTen { get; set; }
        public string NguoiCapNhatHoTen { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public bool IsActive { get; set; }
    }
}
