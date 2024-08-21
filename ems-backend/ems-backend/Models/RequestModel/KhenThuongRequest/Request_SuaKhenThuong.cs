namespace ems_backend.Models.RequestModel.KhenThuongRequest
{
    public class Request_SuaKhenThuong
    {
        public int Id { get; set; }
        public int NhanVienId { get; set; }
        public string LoaiKhenThuong { get; set; }
        public DateTime NgayKhenThuong { get; set; }
    }
}
