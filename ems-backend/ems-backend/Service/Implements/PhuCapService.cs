using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.PhuCapRequest;
using ems_backend.Models.ResponseModels.ResponsePhuCap;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class PhuCapService : IPhuCapService
    {
        private readonly AppDbContext _context;
        public PhuCapService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckTenPhuCapExists(string tenPhuCap)
        {
            return await _context.PhuCaps.AnyAsync(pc => pc.TenPhuCap.ToLower() == tenPhuCap.ToLower());
        }

        public async Task<DataResponsePhuCap> LayPhuCapTheoId(int id)
        {
            var phuCap = await _context.PhuCaps
             .Include(pc => pc.NguoiTao)
             .Include(pc => pc.NguoiCapNhat).FirstOrDefaultAsync(pc => pc.Id == id);
            return PhuCapConverter.EntityToDTO(phuCap);
        }

        public async Task<PageResult<DataResponsePhuCap>> LayTatCaPhuCap(bool? isActive, int pageSize = 10, int pageNumber = 1)
        {
            var query = _context.PhuCaps
                 .Include(pc => pc.NguoiTao)
                 .Include(pc => pc.NguoiCapNhat)
                 .AsQueryable();
            if (isActive.HasValue)
            {
                query = query.Where(pc => pc.IsActive == isActive.Value);
            }
            var result = Pagination.GetPagedData(query.Select(x => PhuCapConverter.EntityToDTO(x)), pageSize, pageNumber);

            return result;
        }

        public async Task<DataResponsePhuCap> SuaPhuCap(int id, Request_SuaPhuCap request)
        {
            var phuCap = await _context.PhuCaps.FindAsync(id);
            if (phuCap == null)
            {
                return null;
            }

            phuCap.TenPhuCap = request.TenPhuCap;
            phuCap.MoTa = request.MoTa;
            phuCap.NguoiCapNhatId = request.NguoiCapNhatId;
            phuCap.IsActive = request.IsActive;
            phuCap.NgayCapNhat = DateTime.Now;

            await _context.SaveChangesAsync();
            return PhuCapConverter.EntityToDTO(phuCap);
        }

        public async Task<DataResponsePhuCap> ThemPhuCap(Request_ThemPhuCap request)
        {
            var phuCap = new PhuCap()
            {
                TenPhuCap = request.TenPhuCap,
                MoTa = request.MoTa,
                NguoiTaoId = request.NguoiTaoId,
                NguoiCapNhatId = request.NguoiCapNhatId,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                IsActive = request.IsActive
            };

            _context.PhuCaps.Add(phuCap);
            await _context.SaveChangesAsync();
            return PhuCapConverter.EntityToDTO(phuCap);
        }

        public async Task<bool> XoaPhuCap(int id)
        {
            var phuCap = await _context.PhuCaps.FindAsync(id);
            if (phuCap == null)
            {
                return false;
            }

            try
            {
                _context.PhuCaps.Remove(phuCap);
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
