using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.NghiViecRequest;
using ems_backend.Models.ResponseModels.DataNghiViec;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class NghiViecService : INghiViecService
    {
        private readonly AppDbContext _context;
        public NghiViecService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DataResponseNghiViec> LayNghiViecTheoId(int id)
        {
            var result = await _context.NghiViecs
             .Include(x => x.NhanVien).FirstOrDefaultAsync(x => x.Id == id);
            return NghiViecConverter.EntityToDTO(result);
        }

        public async Task<PageResult<DataResponseNghiViec>> LayTatCaNghiViec(int pageSize, int pageNumber)
        {
            var query = _context.NghiViecs
            .Include(x => x.NhanVien)
                .AsQueryable();
            var result = Pagination.GetPagedData(query.Select(x => NghiViecConverter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        public async Task<DataResponseNghiViec> SuaNghiViec(int id, Request_SuaNghiViec request)
        {
            var result = await _context.NghiViecs.FindAsync(id);
            if (result == null)
            {
                return null;
            }

            result.NhanVienId = request.NhanVienId;
            result.NgayNghiViec = request.NgayNghiViec;
            result.LyDo = request.LyDo;

            await _context.SaveChangesAsync();
            return NghiViecConverter.EntityToDTO(result);
        }

        public async Task<DataResponseNghiViec> ThemNghiViec(Request_ThemNghiViec request)
        {
            var result = new NghiViec()
            {
                NhanVienId = request.NhanVienId,
                NgayNghiViec = request.NgayNghiViec,
                LyDo = request.LyDo,
            };

            _context.NghiViecs.Add(result);
            await _context.SaveChangesAsync();
            return NghiViecConverter.EntityToDTO(result);
        }


        public async Task<bool> XoaNghiViec(int id)
        {
            var result = await _context.NghiViecs.FindAsync(id);
            if (result == null)
            {
                return false;
            }

            try
            {

                _context.NghiViecs.Remove(result);
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
