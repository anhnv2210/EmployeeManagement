using ems_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Data.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<CapPhatTaiSan> CapPhatTaiSans { get; set; }
        public DbSet<PhucLoi> PhucLois { get; set; }
        public DbSet<ChiNhanhNganHang> ChiNhanhNganHangs { get; set; }
        public DbSet<ChucDanh> ChucDanhs { get; set; }
        public DbSet<ChucDanhPhongBan> ChucDanhPhongBans { get; set; }
        public DbSet<DanhMucKhac> DanhMucKhacs { get; set; }
        public DbSet<HopDong> HopDongs { get; set; }
        public DbSet<HoSoLuong> HoSoLuongs { get; set; }
        public DbSet<HoSoLuong_PhuCap> HoSoLuong_PhuCaps { get; set; }
        public DbSet<HoSoLuong_PhucLoi> HoSoLuong_PhucLois { get; set; }
        public DbSet<KhenThuong> KhenThuongs { get; set; }
        public DbSet<KyLuat> KyLuats { get; set; }
        public DbSet<LoaiHopDong> LoaiHopDongs { get; set; }
        public DbSet<NganHang> NganHangs { get; set; }
        public DbSet<NghiViec> NghiViecs { get; set; }
        public DbSet<NguoiThanNhanVien> NguoiThanNhanViens { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<NoiKhamBenh> NoiKhamBenhs { get; set; }
        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<PhuCap> PhuCaps { get; set; }
        public DbSet<QuanHuyen> QuanHuyens { get; set; }
        public DbSet<QuocGia> QuocGias { get; set; }
        public DbSet<QuyetDinh> QuyetDinhs { get; set; }
        public DbSet<TaiSan> TaiSans { get; set; }
        public DbSet<TapTinDinhKem> TapTinDinhKems { get; set; }
        public DbSet<TinhThanh> TinhThanhs { get; set; }
        public DbSet<XaPhuong> XaPhuongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CapPhatTaiSan>()
                .HasOne(c => c.TaiSan)
                .WithMany(t => t.CapPhatTaiSans)
                .HasForeignKey(c => c.TaiSanId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HopDong>()
                .HasOne(h => h.QuyetDinh)
                .WithOne(q => q.HopDong)
                .HasForeignKey<QuyetDinh>(q => q.HopDongId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChucDanh>()
                .HasOne(cd => cd.NguoiTao)
                .WithMany()
                .HasForeignKey(cd => cd.NguoiTaoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChucDanh>()
                .HasOne(cd => cd.NguoiCapNhat)
                .WithMany()
                .HasForeignKey(cd => cd.NguoiCapNhatId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChiNhanhNganHang>()
                .HasOne(c => c.NguoiCapNhat)
                .WithMany()
                .HasForeignKey(c => c.NguoiCapNhatId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ChiNhanhNganHang>()
                .HasOne(c => c.NguoiTao)
                .WithMany()
                .HasForeignKey(c => c.NguoiTaoId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<NganHang>()
                .HasOne(c => c.NguoiCapNhat)
                .WithMany()
                .HasForeignKey(c => c.NguoiCapNhatId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<NganHang>()
                .HasOne(c => c.NguoiTao)
                .WithMany()
                .HasForeignKey(c => c.NguoiTaoId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<NoiKhamBenh>()
                .HasOne(c => c.NguoiCapNhat)
                .WithMany()
                .HasForeignKey(c => c.NguoiCapNhatId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<NoiKhamBenh>()
                .HasOne(c => c.NguoiTao)
                .WithMany()
                .HasForeignKey(c => c.NguoiTaoId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PhongBan>()
                .HasOne(c => c.NguoiCapNhat)
                .WithMany()
                .HasForeignKey(c => c.NguoiCapNhatId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PhongBan>()
                .HasOne(c => c.NguoiTao)
                .WithMany()
                .HasForeignKey(c => c.NguoiTaoId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<QuocGia>()
                .HasOne(c => c.NguoiCapNhat)
                .WithMany()
                .HasForeignKey(c => c.NguoiCapNhatId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<QuocGia>()
                .HasOne(c => c.NguoiTao)
                .WithMany()
                .HasForeignKey(c => c.NguoiTaoId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TinhThanh>()
                .HasOne(c => c.NguoiCapNhat)
                .WithMany()
                .HasForeignKey(c => c.NguoiCapNhatId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TinhThanh>()
                .HasOne(c => c.NguoiTao)
                .WithMany()
                .HasForeignKey(c => c.NguoiTaoId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<QuanHuyen>()
                .HasOne(c => c.NguoiCapNhat)
                .WithMany()
                .HasForeignKey(c => c.NguoiCapNhatId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<QuanHuyen>()
                .HasOne(c => c.NguoiTao)
                .WithMany()
                .HasForeignKey(c => c.NguoiTaoId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<XaPhuong>()
                .HasOne(c => c.NguoiCapNhat)
                .WithMany()
                .HasForeignKey(c => c.NguoiCapNhatId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<XaPhuong>()
                .HasOne(c => c.NguoiTao)
                .WithMany()
                .HasForeignKey(c => c.NguoiTaoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NhanVien>()
                .HasOne(nv => nv.NguoiCapNhat)
                .WithMany()
                .HasForeignKey(nv => nv.NguoiCapNhatId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NhanVien>()
                .HasOne(nv => nv.NguoiTao)
                .WithMany()
                .HasForeignKey(nv => nv.NguoiTaoId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
