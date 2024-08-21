using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.KhenThuongRequest;
using ems_backend.Models.ResponseModels.DataKhenThuong;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class KhenThuongService : IKhenThuongService
    {
        private readonly AppDbContext _context;
        public KhenThuongService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DataResponseKhenThuong> LayKhenThuongTheoId(int id)
        {
            var result = await _context.KhenThuongs
            .Include(x => x.NhanVien).FirstOrDefaultAsync(x => x.Id == id);
            return KhenThuongConverter.EntityToDTO(result);
        }

        public async Task<PageResult<DataResponseKhenThuong>> LayTatCaKhenThuong(int pageSize, int pageNumber)
        {
            var query = _context.KhenThuongs
            .Include(x => x.NhanVien)
                .AsQueryable();
            var result = Pagination.GetPagedData(query.Select(x => KhenThuongConverter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        public async Task<DataResponseKhenThuong> SuaKhenThuong(int id, Request_SuaKhenThuong request)
        {
            var result = await _context.KhenThuongs.FindAsync(id);
            if (result == null)
            {
                return null;
            }

            result.NhanVienId = request.NhanVienId;
            result.LoaiKhenThuong = request.LoaiKhenThuong;
            result.NgayKhenThuong = request.NgayKhenThuong;

            await _context.SaveChangesAsync();
            return KhenThuongConverter.EntityToDTO(result);
        }

        public async Task<DataResponseKhenThuong> ThemKhenThuong(Request_ThemKhenThuong request)
        {
            var res = new KhenThuong()
            {
                NhanVienId = request.NhanVienId,
                LoaiKhenThuong = request.LoaiKhenThuong,
                NgayKhenThuong = request.NgayKhenThuong
            };

            _context.KhenThuongs.Add(res);
            await _context.SaveChangesAsync();
            return KhenThuongConverter.EntityToDTO(res);
        }

        public async Task<bool> XoaKhenThuong(int id)
        {
            var result = await _context.KhenThuongs.FindAsync(id);
            if (result == null)
            {
                return false;
            }

            try
            {

                _context.KhenThuongs.Remove(result);
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
