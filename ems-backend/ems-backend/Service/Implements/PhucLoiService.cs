using ems_backend.Data.DataContext;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.PhucLoiRequest;
using ems_backend.Models.ResponseModels.DataPhucLoi;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class PhucLoiService : IPhucLoiService
    {
        private readonly AppDbContext _context;
        public PhucLoiService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckTenPhucLoiExists(string tenPhucLoi)
        {
            return await _context.PhucLois.AnyAsync(pl => pl.TenPhucLoi.ToLower() == tenPhucLoi.ToLower());
        }

        public async Task<DataResponsePhucLoi> LayPhucLoiTheoId(int id)
        {
            var phucLoi = await _context.PhucLois
              .Include(pl => pl.NguoiTao)
              .Include(pl => pl.NguoiCapNhat).FirstOrDefaultAsync(pl => pl.Id == id);
            return PhucLoiConverter.EntityToDTO(phucLoi);
        }

        public async Task<IEnumerable<DataResponsePhucLoi>> LayTatCaPhucLoi()
        {
            var query = _context.PhucLois
                 .Include(pl => pl.NguoiTao)
                 .Include(pl => pl.NguoiCapNhat)
                 .AsQueryable();
            var result = query.Select(pl => PhucLoiConverter.EntityToDTO(pl));
            return result;
        }

        public async Task<DataResponsePhucLoi> SuaPhucLoi(int id, Request_SuaPhucLoi request)
        {
            var phucLoi = await _context.PhucLois.FindAsync(id);
            if (phucLoi == null)
            {
                return null;
            }

            phucLoi.TenPhucLoi = request.TenPhucLoi;
            phucLoi.MoTa = request.MoTa;
            phucLoi.NguoiCapNhatId = request.NguoiCapNhatId;
            phucLoi.IsActive = request.IsActive;
            phucLoi.NgayCapNhat = DateTime.Now;

            await _context.SaveChangesAsync();
            return PhucLoiConverter.EntityToDTO(phucLoi);
        }

        public async Task<DataResponsePhucLoi> ThemPhucLoi(Request_ThemPhucLoi request)
        {
            var phucLoi = new PhucLoi()
            {
                TenPhucLoi = request.TenPhucLoi,
                MoTa = request.MoTa,
                NguoiTaoId = request.NguoiTaoId,
                NguoiCapNhatId = request.NguoiCapNhatId,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                IsActive = request.IsActive
            };

            _context.PhucLois.Add(phucLoi);
            await _context.SaveChangesAsync();
            return PhucLoiConverter.EntityToDTO(phucLoi);
        }

        public async Task<bool> XoaPhucLoi(int id)
        {
            var phucLoi = await _context.PhucLois.FindAsync(id);
            if (phucLoi == null)
            {
                return false;
            }

            try
            {
                _context.PhucLois.Remove(phucLoi);
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
