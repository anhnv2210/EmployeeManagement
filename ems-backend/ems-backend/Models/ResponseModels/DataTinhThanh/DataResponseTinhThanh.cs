namespace ems_backend.Models.ResponseModels.DataTinhThanh
{
    public class DataResponseTinhThanh : DataResponseBase
    {
        public string TenTinhThanh { get; set; }
        public string MoTa { get; set; }
        public int QuocGiaId { get; set; }
        public string TenQuocGia {  get; set; }
    }
}
