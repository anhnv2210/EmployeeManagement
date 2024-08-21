using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.KyLuatRequest;
using ems_backend.Models.ResponseModels.DataKyLuat;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class KyLuatService : IKyLuatService
    {
        private readonly AppDbContext _context;
        public KyLuatService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DataResponseKyLuat> LayKyLuatTheoId(int id)
        {
            var result = await _context.KyLuats
            .Include(x => x.NhanVien).FirstOrDefaultAsync(x => x.Id == id);
            return KyLuatConverter.EntityToDTO(result);
        }

        public async Task<PageResult<DataResponseKyLuat>> LayTatCaKyLuat(int pageSize, int pageNumber)
        {
            var query = _context.KyLuats
            .Include(x => x.NhanVien)
                .AsQueryable();
            var result = Pagination.GetPagedData(query.Select(x => KyLuatConverter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        public async Task<DataResponseKyLuat> SuaKyLuat(int id, Request_SuaKyLuat request)
        {
            var result = await _context.KyLuats.FindAsync(id);
            if (result == null)
            {
                return null;
            }

            result.NhanVienId = request.NhanVienId;
            result.LoaiKyLuat = request.LoaiKyLuat;
            result.NgayKyLuat = request.NgayKyLuat;
            result.NoiDung = request.NoiDung;

            await _context.SaveChangesAsync();
            return KyLuatConverter.EntityToDTO(result);
        }

        public async Task<DataResponseKyLuat> ThemKyLuat(Request_ThemKyLuat request)
        {
            var result = new KyLuat()
            {
                NhanVienId = request.NhanVienId,
                LoaiKyLuat = request.LoaiKyLuat,
                NgayKyLuat = request.NgayKyLuat,
                NoiDung = request.NoiDung
            };
            _context.KyLuats.Add(result);
            await _context.SaveChangesAsync();
            return KyLuatConverter.EntityToDTO(result);
        }

        public async Task<bool> XoaKyLuat(int id)
        {
            var result = await _context.KyLuats.FindAsync(id);
            if (result == null)
            {
                return false;
            }

            try
            {
               
                _context.KyLuats.Remove(result);
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
