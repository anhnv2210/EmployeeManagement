namespace ems_backend.Models.ResponseModels.DataXaPhuong
{
    public class DataResponseXaPhuong : DataResponseBase
    {
        public string TenXaPhuong { get; set; }
        public string MoTa { get; set; }
        public int QuocGiaId {  get; set; }
        public string TenQuocGia { get; set; }
        public int TinhThanhId {  get; set; }

        public string TenTinhThanh { get; set; }
        public int QuanHuyenId {  get; set; }
        public string TenQuanHuyen { get; set; }
    }
}
