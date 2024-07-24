using ems_backend.Data.DataContext;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.PhongBanRequest;
using ems_backend.Models.ResponseModels.DataPhongBan;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class PhongBanService : IPhongBanService
    {
        private readonly AppDbContext _context;
        public PhongBanService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckTenPhongBanExists(string tenPhongBan)
        {
            return await _context.PhongBans.AnyAsync(pb => pb.TenPhongBan.ToLower() == tenPhongBan.ToLower());
        }

        public async Task<DataResponsePhongBan> LayPhongBanTheoId(int id)
        {
            var phongBan = await _context.PhongBans
            .Include(pb => pb.NguoiTao)
            .Include(pb => pb.NguoiCapNhat).FirstOrDefaultAsync(pb => pb.Id == id);
            return PhongBanConverter.EntityToDTO(phongBan);
        }

        public async Task<IEnumerable<DataResponsePhongBan>> LayTatCaPhongBan()
        {
            var query = _context.PhongBans
                .Include(pb => pb.NguoiTao)
                .Include(pb => pb.NguoiCapNhat)
                .AsQueryable();
            var result = query.Select(pb => PhongBanConverter.EntityToDTO(pb));
            return result;
        }

        public async Task<DataResponsePhongBan> SuaPhongBan(int id, Request_SuaPhongBan request)
        {
            var phongBan = await _context.PhongBans.FindAsync(id);
            if (phongBan == null)
            {
                return null;
            }

            phongBan.TenPhongBan = request.TenPhongBan;
            phongBan.MoTa = request.MoTa;
            phongBan.NguoiCapNhatId = request.NguoiCapNhatId;
            phongBan.IsActive = request.IsActive;
            phongBan.NgayCapNhat = DateTime.Now;

            await _context.SaveChangesAsync();
            return PhongBanConverter.EntityToDTO(phongBan);
        }

        public async Task<DataResponsePhongBan> ThemPhongBan(Request_ThemPhongBan request)
        {
            var phongBan = new PhongBan()
            {
                TenPhongBan = request.TenPhongBan,
                MoTa = request.MoTa,
                NguoiTaoId = request.NguoiTaoId,
                NguoiCapNhatId = request.NguoiCapNhatId,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                IsActive = request.IsActive
            };

            _context.PhongBans.Add(phongBan);
            await _context.SaveChangesAsync();
            return PhongBanConverter.EntityToDTO(phongBan);
        }

        public async Task<bool> XoaPhongBan(int id)
        {
            var phongBan = await _context.PhongBans.FindAsync(id);
            if (phongBan == null)
            {
                return false;
            }

            try
            {
                _context.PhongBans.Remove(phongBan);
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
