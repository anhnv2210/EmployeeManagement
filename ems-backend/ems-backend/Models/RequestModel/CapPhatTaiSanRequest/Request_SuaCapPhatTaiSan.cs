﻿namespace ems_backend.Models.RequestModel.CapPhatTaiSanRequest
{
    public class Request_SuaCapPhatTaiSan
    {
        public int Id {  get; set; }
        public int NhanVienId { get; set; }
        public int TaiSanId { get; set; }
        public DateTime NgayCapPhat { get; set; }
        public DateTime NgayTraLai { get; set; }
        public string TinhTrang { get; set; }
    }
}
