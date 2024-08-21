using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.TaiSanRequest;
using ems_backend.Models.ResponseModels.DataTaiSan;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class TaiSanService : ITaiSanService
    {
        private readonly AppDbContext _context;
        public TaiSanService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckTenTaiSanExists(string tenTaiSan)
        {
            return await _context.TaiSans.AnyAsync(ts => ts.TenTaiSan.ToLower() == tenTaiSan.ToLower());
        }

        public async Task<DataResponseTaiSan> LayTaiSanTheoId(int id)
        {
            var taiSan = await _context.TaiSans
              .Include(ts => ts.NguoiTao)
              .Include(ts => ts.NguoiCapNhat).FirstOrDefaultAsync(ts => ts.Id == id);
            return TaiSanConverter.EntityToDTO(taiSan);
        }
        public async Task<PageResult<DataResponseTaiSan>> LayTatCaTaiSan(bool? isActive, int pageSize = 10, int pageNumber = 1)
        {
            var query = _context.TaiSans
                 .Include(pl => pl.NguoiTao)
                 .Include(pl => pl.NguoiCapNhat)
                 .AsQueryable();
            if (isActive.HasValue)
            {
                query = query.Where(ts => ts.IsActive == isActive.Value);
            }
            var result = Pagination.GetPagedData(query.Select(x => TaiSanConverter.EntityToDTO(x)), pageSize, pageNumber);

            return result;
        }

        public async Task<DataResponseTaiSan> SuaTaiSan(int id, Request_SuaTaiSan request)
        {
            var taiSan = await _context.TaiSans.FindAsync(id);
            if (taiSan == null)
            {
                return null;
            }

            taiSan.TenTaiSan = request.TenTaiSan;
            taiSan.MoTa = request.MoTa;
            taiSan.NguoiCapNhatId = request.NguoiCapNhatId;
            taiSan.IsActive = request.IsActive;
            taiSan.NgayCapNhat = DateTime.Now;

            await _context.SaveChangesAsync();
            return TaiSanConverter.EntityToDTO(taiSan);
        }

        public async Task<DataResponseTaiSan> ThemTaiSan(Request_ThemTaiSan request)
        {
            var taiSan = new TaiSan()
            {
                TenTaiSan = request.TenTaiSan,
                MoTa = request.MoTa,
                NguoiTaoId = request.NguoiTaoId,
                NguoiCapNhatId = request.NguoiCapNhatId,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                IsActive = request.IsActive
            };

            _context.TaiSans.Add(taiSan);
            await _context.SaveChangesAsync();
            return TaiSanConverter.EntityToDTO(taiSan);
        }

        public async Task<bool> XoaTaiSan(int id)
        {
            var taiSan = await _context.TaiSans.FindAsync(id);
            if (taiSan == null)
            {
                return false;
            }

            try
            {
                _context.TaiSans.Remove(taiSan);
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
