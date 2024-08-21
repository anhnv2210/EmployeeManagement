namespace ems_backend.Models.ResponseModels.DataHoSoLuong
{
    public class DataResponseHoSoLuongPhuCap : DataResponseBase
    {
        public int HoSoLuongId { get; set; }
        public string TenPhuCap {  get; set; }
        public int PhuCapId { get; set; }
        public decimal SoTien { get; set; }
    }
}
