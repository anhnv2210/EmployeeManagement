namespace ems_backend.Models.ResponseModels.DataPhucLoi
{
    public class DataResponsePhucLoi : DataResponseBase
    {
        public string TenPhucLoi {  get; set; }
        public string MoTa {  get; set; }
        public string NguoiTaoHoTen {  get; set; }
        public DateTime NgayTao {  get; set; }
        public string NguoiCapNhatHoTen {  get; set; }
        public DateTime NgayCapNhat {  get; set; }
        public bool IsActive {  get; set; }
    }
}
