﻿namespace ems_backend.Models.Entities
{
    public class LoaiHopDong : BaseEntity
    {
        public string TenLoaiHopDong { get; set; }
        public string MoTa { get; set; }
        public int NguoiTaoId { get; set; }
        public DateTime? NgayTao { get; set; }
        public int NguoiCapNhatId { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public NhanVien? NguoiTao { get; set; }
        public NhanVien? NguoiCapNhat { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<HopDong> HopDongs { get; set; }
    }
}