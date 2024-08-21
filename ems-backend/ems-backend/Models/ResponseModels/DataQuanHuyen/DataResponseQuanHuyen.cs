namespace ems_backend.Models.ResponseModels.DataQuanHuyen
{
    public class DataResponseQuanHuyen : DataResponseBase
    {
        public string TenQuanHuyen { get; set; }
        public string MoTa { get; set; }
        public int QuocGiaId {  get; set; }
        public int TinhThanhId {  get; set; }
        public string TenQuocGia { get; set; }
        public string TenTinhThanh { get; set; }
    }
}
