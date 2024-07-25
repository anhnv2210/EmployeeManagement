namespace ems_backend.Models.RequestModel.NoiKhamBenhRequest
{
    public class Request_SuaNoiKhamBenh
    {
        public int Id { get; set; }
        public string TenNoiKhamBenh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string GhiChu { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public bool IsActive { get; set; }
    }
}
