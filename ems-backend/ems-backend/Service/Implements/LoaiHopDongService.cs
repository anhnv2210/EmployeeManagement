using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.LoaiHopDongRequest;
using ems_backend.Models.ResponseModels.DataLoaiHopDong;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class LoaiHopDongService : ILoaiHopDongService
    {
        private readonly AppDbContext _context;
        public LoaiHopDongService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckTenLoaiHopDongExists(string tenLoaiHopDong)
        {
            return await _context.LoaiHopDongs.AnyAsync(c => c.TenLoaiHopDong.ToLower() == tenLoaiHopDong.ToLower());
        }

        public async Task<DataResponseLoaiHopDong> LayLoaiHopDongTheoId(int id)
        {
            var loaiHopDong = await _context.LoaiHopDongs
            .Include(lhd => lhd.NguoiTao)
            .Include(lhd => lhd.NguoiCapNhat).FirstOrDefaultAsync(lhd => lhd.Id == id);
            return LoaiHopDongConverter.EntityToDTO(loaiHopDong);
        }

        public async Task<PageResult<DataResponseLoaiHopDong>> LayTatCaLoaiHopDong(bool? isActive, int pageSize = 10, int pageNumber = 1)
        {
            var query = _context.LoaiHopDongs
                .Include(lhd => lhd.NguoiTao)
                .Include(lhd => lhd.NguoiCapNhat)
                .AsQueryable();
            if (isActive.HasValue)
            {
                query = query.Where(lhd => lhd.IsActive == isActive.Value);
            }
            var result = Pagination.GetPagedData(query.Select(x => LoaiHopDongConverter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        public async Task<DataResponseLoaiHopDong> SuaLoaiHopDong(int id, Request_SuaLoaiHopDong request)
        {
            var loaiHopDong = await _context.LoaiHopDongs.FindAsync(id);
            if (loaiHopDong == null)
            {
                return null;
            }

            loaiHopDong.TenLoaiHopDong = request.TenLoaiHopDong;
            loaiHopDong.MoTa = request.MoTa;
            loaiHopDong.NguoiCapNhatId = request.NguoiCapNhatId;
            loaiHopDong.IsActive = request.IsActive;
            loaiHopDong.NgayCapNhat = DateTime.Now;

            await _context.SaveChangesAsync();
            return LoaiHopDongConverter.EntityToDTO(loaiHopDong);
        }

        public async Task<DataResponseLoaiHopDong> ThemLoaiHopDong(Request_ThemLoaiHopDong request)
        {
            var loaiHopDong = new LoaiHopDong()
            {
                TenLoaiHopDong = request.TenLoaiHopDong,
                MoTa = request.MoTa,
                NguoiTaoId = request.NguoiTaoId,
                NguoiCapNhatId = request.NguoiCapNhatId,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                IsActive = request.IsActive
            };

            _context.LoaiHopDongs.Add(loaiHopDong);
            await _context.SaveChangesAsync();
            return LoaiHopDongConverter.EntityToDTO(loaiHopDong);
        }

        public async Task<bool> XoaLoaiHopDong(int id)
        {
            var loaiHopDong = await _context.LoaiHopDongs.FindAsync(id);
            if (loaiHopDong == null)
            {
                return false;
            }

            try
            {
                _context.LoaiHopDongs.Remove(loaiHopDong);
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
