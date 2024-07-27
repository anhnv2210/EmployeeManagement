﻿namespace ems_backend.Models.RequestModel.QuanHuyenRequest
{
    public class Request_SuaQuanHuyen
    {
        public int Id { get; set; }
        public string TenQuanHuyen { get; set; }
        public string MoTa { get; set; }
        public int QuocGiaId { get; set; }
        public int TinhThanhId { get; set; }
        public int NguoiTaoId { get; set; }
        public int NguoiCapNhatId { get; set; }
        public bool IsActive { get; set; }
    }
}