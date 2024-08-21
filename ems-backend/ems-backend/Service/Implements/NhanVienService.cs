using ems_backend.Common.HandleExceptions;
using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.NhanVienRequest;
using ems_backend.Models.ResponseModels.DataNhanVien;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ems_backend.Service.Implements
{
    public class NhanVienService : INhanVienService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public NhanVienService(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            if (!await _context.NhanViens.AnyAsync(nv => nv.Email.ToLower() == email.ToLower()) || HandleValidationException.ValidateEmail(email))
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CheckSoDienThoaiExists(string soDienThoai)
        {
            if (!await _context.NhanViens.AnyAsync(nv => nv.SoDienThoai == soDienThoai) || HandleValidationException.ValidatePhoneNumber(soDienThoai))
            {
                return false;
            }
            return true;
        }

        public async Task<DataResponseNhanVien> LayNhanVienTheoId(int id)
        {
            var nhanVien = await _context.NhanViens
                .Include(nv => nv.PhongBan)
                .Include(nv => nv.ChucDanh)
                .Include(nv => nv.XaPhuong)
                .Include(nv => nv.QuanHuyen)
                .Include(nv => nv.TinhThanh)
                .Include(nv => nv.QuocGia)
                .Include(nv => nv.NganHang)
                .Include(nv => nv.ChiNhanhNganHang)
                .Include(nv => nv.NoiKhamBenh)
                .Include(nv => nv.NguoiTao)
                .Include(nv => nv.NguoiCapNhat).FirstOrDefaultAsync(nv => nv.Id == id);
            return NhanVienConverter.EntityToDTO(nhanVien);
        }

        public async Task<PageResult<DataResponseNhanVien>> LayTatCaNhanVien(string? trangThai, int pageSize = 10, int pageNumber = 1)
        {
            var query = _context.NhanViens
                .Include(nv => nv.PhongBan)
                .Include(nv => nv.ChucDanh)
                .Include(nv => nv.XaPhuong)
                .Include(nv => nv.QuanHuyen)
                .Include(nv => nv.TinhThanh)
                .Include(nv => nv.QuocGia)
                .Include(nv => nv.NganHang)
                .Include(nv => nv.ChiNhanhNganHang)
                .Include(nv => nv.NoiKhamBenh)
                .Include(nv => nv.NguoiTao)
                .Include(nv => nv.NguoiCapNhat)
                .AsQueryable();
            if (!string.IsNullOrEmpty(trangThai))
            {
                if (trangThai == "Đã làm việc")
                    query = query.Where(nv => nv.TrangThai == "Đã làm việc");
                else if (trangThai == "Không còn làm việc")
                    query = query.Where(nv => nv.TrangThai == "Không còn làm việc");
            }

            var result = Pagination.GetPagedData(query.Select(x => NhanVienConverter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        public async Task<DataResponseNhanVien> SuaNhanVien(int id, Request_SuaNhanVien request)
        {
            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return null;
            }

            nhanVien.Hoten = request.Hoten;
            nhanVien.NgaySinh = request.NgaySinh;
            nhanVien.GioiTinh = request.GioiTinh;
            nhanVien.SoDienThoai = request.SoDienThoai;
            nhanVien.Email = request.Email;
            nhanVien.XaPhuongId = request.XaPhuongId;
            nhanVien.QuanHuyenId = request.QuanHuyenId;
            nhanVien.TinhThanhId = request.TinhThanhId;
            nhanVien.QuocGiaId = request.QuocGiaId;
            nhanVien.PhongBanId = request.PhongBanId;
            nhanVien.ChucDanhId = request.ChucDanhId;
            nhanVien.NoiKhamBenhId = request.NoiKhamBenhId;
            nhanVien.NganHangId = request.NganHangId;
            nhanVien.ChiNhanhNganHangId = request.ChiNhanhNganHangId;
            if (!request.NgayKetThucLamViec.HasValue)
            {
                nhanVien.NgayKetThucLamViec = null;
            }
            else
            {
                nhanVien.NgayKetThucLamViec = request.NgayKetThucLamViec;
            }
            nhanVien.NguoiCapNhatId = request.NguoiCapNhatId;
            nhanVien.NgayCapNhat = DateTime.Now;
            if (request.AnhDaiDien != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(request.AnhDaiDien.FileName);
                var extension = Path.GetExtension(request.AnhDaiDien.FileName);
                var newFileName = $"{fileName}_{Guid.NewGuid()}{extension}";
                var path = Path.Combine("Web/ems-frontend/public/images", newFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await request.AnhDaiDien.CopyToAsync(stream);
                }

                nhanVien.AnhDaiDien = $"/images/{newFileName}";
            }
            if (nhanVien.NgayKetThucLamViec <= DateTime.Now)
            {
                nhanVien.TrangThai = "Không còn làm việc";
            }
            else
            {
                nhanVien.TrangThai = "Đã làm việc";
            }

            if(!_context.ChucDanhPhongBans.Any(cdpb => cdpb.PhongBanId == nhanVien.PhongBanId && cdpb.ChucDanhId == nhanVien.ChucDanhId))
            {
                ChucDanhPhongBan cdpbMoi = new ChucDanhPhongBan()
                {
                    PhongBanId = (int)nhanVien.PhongBanId,
                    ChucDanhId = (int)nhanVien.ChucDanhId
                };
                _context.ChucDanhPhongBans.Add(cdpbMoi);
                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
            return NhanVienConverter.EntityToDTO(nhanVien);
        }

        public async Task<DataResponseNhanVien> ThemNhanVien(Request_ThemNhanVien request)
        {
          
            var nhanVien = new NhanVien()
            {
                Hoten = request.Hoten,
                NgaySinh = request.NgaySinh,
                GioiTinh = request.GioiTinh,
                SoDienThoai = request.SoDienThoai,
                Email = request.Email,
                XaPhuongId = request.XaPhuongId,
                QuanHuyenId = request.QuanHuyenId,
                TinhThanhId = request.TinhThanhId,
                PhongBanId = request.PhongBanId,
                QuocGiaId = request.QuocGiaId,
                ChucDanhId = request.ChucDanhId,
                NoiKhamBenhId = request.NoiKhamBenhId,
                NganHangId = request.NganHangId,
                ChiNhanhNganHangId = request.ChiNhanhNganHangId,
                NgayBatDauLamViec = request.NgayBatDauLamViec,
                NgayKetThucLamViec = request.NgayKetThucLamViec,
                NguoiTaoId = request.NguoiTaoId,
                NguoiCapNhatId = request.NguoiCapNhatId,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                TrangThai = "Đã làm việc"
            };

            if (request.AnhDaiDien != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(request.AnhDaiDien.FileName);
                var extension = Path.GetExtension(request.AnhDaiDien.FileName);
                var newFileName = $"{fileName}_{Guid.NewGuid()}{extension}";
                var path = Path.Combine("Web/ems-frontend/public/images", newFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await request.AnhDaiDien.CopyToAsync(stream);
                }

                nhanVien.AnhDaiDien = $"/images/{newFileName}";
            }

            _context.NhanViens.Add(nhanVien);
            await _context.SaveChangesAsync();

            if (!_context.ChucDanhPhongBans.Any(cdpb => cdpb.PhongBanId == nhanVien.PhongBanId && cdpb.ChucDanhId == nhanVien.ChucDanhId))
            {
                ChucDanhPhongBan cdpbMoi = new ChucDanhPhongBan()
                {
                    PhongBanId = (int)nhanVien.PhongBanId,
                    ChucDanhId = (int)nhanVien.ChucDanhId
                };
                _context.ChucDanhPhongBans.Add(cdpbMoi);
                await _context.SaveChangesAsync();
            }

            return NhanVienConverter.EntityToDTO(nhanVien);
        }
    }
}
