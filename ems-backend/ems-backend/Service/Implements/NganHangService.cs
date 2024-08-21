using ems_backend.Common.HandleExceptions;
using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.NganHangRequest;
using ems_backend.Models.ResponseModels.DataNganHang;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class NganHangService : INganHangService
    {
        private readonly AppDbContext _context;
        public NganHangService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            if (!await _context.NganHangs.AnyAsync(nh => nh.Email.ToLower() == email.ToLower()) || HandleValidationException.ValidateEmail(email))
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CheckSoDienThoaiExists(string soDienThoai)
        {
            if (!await _context.NganHangs.AnyAsync(nh => nh.SDT == soDienThoai) || HandleValidationException.ValidatePhoneNumber(soDienThoai))
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CheckTenNganHangExists(string tenNganHang)
        {
            return await _context.NganHangs.AnyAsync(nh => nh.TenNganHang.ToLower() == tenNganHang.ToLower());
        }

        public async Task<DataResponseNganHang> LayNganHangTheoId(int id)
        {
            var nganHang = await _context.NganHangs
              .Include(nh => nh.NguoiTao)
              .Include(nh => nh.NguoiCapNhat).FirstOrDefaultAsync(nh => nh.Id == id);
            return NganHangConverter.EntityToDTO(nganHang);
        }

        public async Task<PageResult<DataResponseNganHang>> LayTatCaNganHang(bool? isActive, int pageSize = 10, int pageNumber = 1)
        {
            var query = _context.NganHangs
                  .Include(nh => nh.NguoiTao)
                  .Include(nh => nh.NguoiCapNhat)
                  .AsQueryable();
            if (isActive.HasValue)
            {
                query = query.Where(nh => nh.IsActive == isActive.Value);
            }
            var result = Pagination.GetPagedData(query.Select(x => NganHangConverter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        public async Task<DataResponseNganHang> SuaNganHang(int id, Request_SuaNganHang request)
        {
            var nganHang = await _context.NganHangs.FindAsync(id);
            if (nganHang == null)
            {
                return null;
            }

            nganHang.TenNganHang = request.TenNganHang;
            nganHang.DiaChi = request.DiaChi;
            nganHang.Email = request.Email;
            nganHang.SDT = request.SDT;
            nganHang.MoTa = request.MoTa;
            nganHang.NguoiCapNhatId = request.NguoiCapNhatId;
            nganHang.IsActive = request.IsActive;
            nganHang.NgayCapNhat = DateTime.Now;

            await _context.SaveChangesAsync();
            return NganHangConverter.EntityToDTO(nganHang);
        }

        public async Task<DataResponseNganHang> ThemNganHang(Request_ThemNganHang request)
        {
            var nganHang = new NganHang()
            {
                TenNganHang = request.TenNganHang,
                Email = request.Email,
                DiaChi = request.DiaChi,
                SDT = request.SDT,
                MoTa = request.MoTa,
                NguoiTaoId = request.NguoiTaoId,
                NguoiCapNhatId = request.NguoiCapNhatId,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                IsActive = request.IsActive
            };

            _context.NganHangs.Add(nganHang);
            await _context.SaveChangesAsync();
            return NganHangConverter.EntityToDTO(nganHang);
        }

        public async Task<bool> XoaNganHang(int id)
        {
            var nganHang = await _context.NganHangs.FindAsync(id);
            if (nganHang == null)
            {
                return false;
            }

            try
            {
                foreach (var nhanVien in _context.NhanViens)
                {
                    if (nhanVien.NganHangId == id)
                        nhanVien.NganHangId = null;
                }
                _context.NganHangs.Remove(nganHang);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                throw;
            }
        }
    }
}
