﻿namespace ems_backend.Models.RequestModel.ChucDanhRequest
{
    public class Request_ThemChucDanh
    {
        public string TenChucDanh {  get; set; }
        public string MoTa {  get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId {  get; set; }
        public bool IsActive { get; set; }

    }
}
