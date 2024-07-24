using ems_backend.Data.DataContext;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.ChucDanhRequest;
using ems_backend.Models.ResponseModels.DataChucDanh;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class ChucDanhService : IChucDanhService
    {
        private readonly AppDbContext _context;
        public ChucDanhService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckTenChucDanhExists(string tenChucDanh)
        {
            return await _context.ChucDanhs.AnyAsync(c => c.TenChucDanh.ToLower() == tenChucDanh.ToLower());
        }
        public async Task<DataResponseChucDanh> LayChucDanhTheoId(int id)
        {
            var chucDanh = await _context.ChucDanhs
            .Include(cd => cd.NguoiTao)
            .Include(cd => cd.NguoiCapNhat).FirstOrDefaultAsync(cd => cd.Id == id);
            return ChucDanhConverter.EntityToDTO(chucDanh);
        }

        public async Task<IEnumerable<DataResponseChucDanh>> LayTatCaChucDanh()
        {
            var query = _context.ChucDanhs
                .Include(x => x.NguoiTao)
                .Include(x => x.NguoiCapNhat)
                .AsQueryable();
            var result = query.Select(x =>ChucDanhConverter.EntityToDTO(x));
            return result;
        }

        public async Task<DataResponseChucDanh> SuaChucDanh(int id, Request_SuaChucDanh request)
        {
            var chucDanh = await _context.ChucDanhs.FindAsync(id);
            if (chucDanh == null)
            {
                return null;
            }

            chucDanh.TenChucDanh = request.TenChucDanh;
            chucDanh.MoTa = request.MoTa;
            chucDanh.NguoiCapNhatId = request.NguoiCapNhatId;
            chucDanh.IsActive = request.IsActive;
            chucDanh.NgayCapNhat = DateTime.Now;

            await _context.SaveChangesAsync();
            return ChucDanhConverter.EntityToDTO(chucDanh);
        }

        public async Task<DataResponseChucDanh> ThemChucDanh(Request_ThemChucDanh request)
        {
            var chucDanh = new ChucDanh()
            {
                TenChucDanh = request.TenChucDanh,
                MoTa = request.MoTa,
                NguoiTaoId = request.NguoiTaoId,
                NguoiCapNhatId = request.NguoiCapNhatId,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                IsActive = request.IsActive
            };

            _context.ChucDanhs.Add(chucDanh);
            await _context.SaveChangesAsync();
            return ChucDanhConverter.EntityToDTO(chucDanh);
        }

        public async Task<bool> XoaChucDanh(int id)
        {
            var chucDanh = await _context.ChucDanhs.FindAsync(id);
            if (chucDanh == null)
            {
                return false;
            }

            try
            {
                _context.ChucDanhs.Remove(chucDanh);
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
