namespace ems_backend.Models.ResponseModels.DataLoaiHopDong
{
    public class DataResponseLoaiHopDong : DataResponseBase
    {
        public string TenLoaiHopDong {  get; set; }
        public string MoTa {  get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public string NguoiTaoHoTen {  get; set; }
        public DateTime NgayTao {  get; set; }
        public string NguoiCapNhatHoTen { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public bool IsActive {  get; set; }

    }
}
