namespace ems_backend.Models.ResponseModels.DataQuocGia
{
    public class DataResponseQuocGia
    {
        public int Id { get; set; }
        public string TenQuocGia { get; set; }
        public string MoTa { get; set; }
        public string NguoiTaoHoTen { get; set; }
        public string NguoiCapNhatHoTen { get; set; }
        public DateTime NgayTao {  get; set; }
        public DateTime NgayCapNhat {  get; set; }
        public bool IsActive { get; set; }
    }
}
