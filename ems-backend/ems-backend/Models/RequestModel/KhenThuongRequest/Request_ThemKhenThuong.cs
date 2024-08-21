using ems_backend.Models.Entities;

namespace ems_backend.Models.RequestModel.KhenThuongRequest
{
    public class Request_ThemKhenThuong
    {
        public int NhanVienId { get; set; }
        public string LoaiKhenThuong { get; set; }
        public DateTime NgayKhenThuong { get; set; }
    }
}
