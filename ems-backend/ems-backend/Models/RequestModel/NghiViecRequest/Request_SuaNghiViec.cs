namespace ems_backend.Models.RequestModel.NghiViecRequest
{
    public class Request_SuaNghiViec
    {
        public int Id { get; set; }
        public int NhanVienId { get; set; }
        public DateTime NgayNghiViec { get; set; }
        public string LyDo { get; set; }
    }
}
