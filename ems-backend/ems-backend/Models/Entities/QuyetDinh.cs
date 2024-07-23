﻿namespace ems_backend.Models.Entities
{
    public class QuyetDinh : BaseEntity
    {
        public DateTime NgayQuyetDinh { get; set; }
        public string NoiDung { get; set; }
        public int HopDongId { get; set; }
        public virtual HopDong? HopDong { get; set; }
        public int NhanVienId { get; set; }
        public decimal TongLuong { get; set; } = 0;
        public virtual NhanVien? NhanVien { get; set; }
        public virtual HoSoLuong? HoSoLuong { get; set; }
    }
}