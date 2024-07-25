using ems_backend.Common.HandleExceptions;
using ems_backend.Data.DataContext;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.ChiNhanhNganHang;
using ems_backend.Models.ResponseModels.DataChiNhanhNganHang;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class ChiNhanhNganHangService : IChiNhanhNganHangService
    {
        private readonly AppDbContext _context;
        public ChiNhanhNganHangService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            if (!await _context.ChiNhanhNganHangs.AnyAsync(cnnh => cnnh.Email.ToLower() == email.ToLower()) || HandleValidationException.ValidateEmail(email))
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CheckSoDienThoaiExists(string soDienThoai)
        {
            if (!await _context.ChiNhanhNganHangs.AnyAsync(cnnh => cnnh.SDT == soDienThoai) || HandleValidationException.ValidatePhoneNumber(soDienThoai))
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CheckTenChiNhanhNganHangExists(string tenChiNhanhNganHang, int nganHangId)
        {
            return await _context.ChiNhanhNganHangs.AnyAsync(cnnh => cnnh.TenChiNhanhNganHang.ToLower() == tenChiNhanhNganHang.ToLower() && cnnh.NganHangId == nganHangId);
        } 

        public async Task<DataResponseChiNhanhNganHang> LayChiNhanhNganHangTheoId(int id)
        {
            var chiNhanh = await _context.ChiNhanhNganHangs
              .Include(cnnh => cnnh.NguoiTao)
              .Include(cnnh => cnnh.NguoiCapNhat)
              .Include(cnnh => cnnh.NganHang)
              .FirstOrDefaultAsync(nh => nh.Id == id);
            return ChiNhanhNganHangConverter.EntityToDTO(chiNhanh);
        }

        public async Task<IEnumerable<DataResponseChiNhanhNganHang>> LayTatCaChiNhanhNganHang()
        {
            var query = _context.ChiNhanhNganHangs
                  .Include(cnnh => cnnh.NguoiTao)
                  .Include(cnnh => cnnh.NguoiCapNhat)
                  .Include(cnnh => cnnh.NganHang)
                  .AsQueryable();
            var result = query.Select(cnnh => ChiNhanhNganHangConverter.EntityToDTO(cnnh));
            return result;
        }
        public async Task<DataResponseChiNhanhNganHang> SuaChiNhanhNganHang(int id, Request_SuaChiNhanhNganHang request)
        {
            var chiNhanh = await _context.ChiNhanhNganHangs.FindAsync(id);
            if (chiNhanh == null)
            {
                return null;
            }

            chiNhanh.TenChiNhanhNganHang = request.TenChiNhanhNganHang;
            chiNhanh.DiaChi = request.DiaChi;
            chiNhanh.Email = request.Email;
            chiNhanh.SDT = request.SoDienThoai;
            chiNhanh.MoTa = request.MoTa;
            chiNhanh.NguoiCapNhatId = request.NguoiCapNhatId;
            chiNhanh.IsActive = request.IsActive;
            chiNhanh.NgayCapNhat = DateTime.Now;

            await _context.SaveChangesAsync();
            return ChiNhanhNganHangConverter.EntityToDTO(chiNhanh);
        }

        public async Task<DataResponseChiNhanhNganHang> ThemChiNhanhNganHang(Request_ThemChiNhanhNganHang request)
        {
            var chiNhanh = new ChiNhanhNganHang()
            {
                TenChiNhanhNganHang = request.TenChiNhanhNganHang,
                Email = request.Email,
                DiaChi = request.DiaChi,
                SDT = request.SoDienThoai,
                MoTa = request.MoTa,
                NguoiTaoId = request.NguoiTaoId,
                NguoiCapNhatId = request.NguoiCapNhatId,
                NganHangId = request.NganHangId,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                IsActive = request.IsActive
            };

            _context.ChiNhanhNganHangs.Add(chiNhanh);
            await _context.SaveChangesAsync();
            return ChiNhanhNganHangConverter.EntityToDTO(chiNhanh);
        }

        public async Task<bool> XoaChiNhanhNganHang(int id)
        {
            var chiNhanh = await _context.ChiNhanhNganHangs.FindAsync(id);
            if (chiNhanh == null)
            {
                return false;
            }

            try
            {
                _context.ChiNhanhNganHangs.Remove(chiNhanh);
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
