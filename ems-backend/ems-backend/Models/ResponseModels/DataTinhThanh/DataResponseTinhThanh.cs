namespace ems_backend.Models.ResponseModels.DataTinhThanh
{
    public class DataResponseTinhThanh : DataResponseBase
    {
        public string TenTinhThanh { get; set; }
        public string MoTa { get; set; }
        public string TenQuocGia { get; set; }
        public string TenNguoiTao { get; set; }
        public string TenNguoiCapNhat { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public bool IsActive { get; set; }
    }
}
