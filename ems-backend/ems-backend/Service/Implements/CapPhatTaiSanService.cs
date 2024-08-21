using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.CapPhatTaiSanRequest;
using ems_backend.Models.ResponseModels.DataCapPhatTaiSan;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class CapPhatTaiSanService : ICapPhatTaiSanService
    {
        private readonly AppDbContext _context;
        public CapPhatTaiSanService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DataResponseCapPhatTaiSan> LayCapPhatTaiSanTheoId(int id)
        {
            var result = await _context.CapPhatTaiSans
            .Include(x => x.NhanVien)
            .Include(x => x.TaiSan).FirstOrDefaultAsync(x => x.Id == id);
            return CapPhatTaiSanConverter.EntityToDTO(result);
        }

        public async Task<PageResult<DataResponseCapPhatTaiSan>> LayTatCaCapPhatTaiSan(int pageSize, int pageNumber)
        {
            var query = _context.CapPhatTaiSans
            .Include(x => x.NhanVien)
            .Include(x => x.TaiSan)
                .AsQueryable();
            var result = Pagination.GetPagedData(query.Select(x => CapPhatTaiSanConverter.EntityToDTO(x)), pageSize, pageNumber);

            return result;
        }

        public async Task<DataResponseCapPhatTaiSan> SuaCapPhatTaiSan(int id, Request_SuaCapPhatTaiSan request)
        {
            var capPhatTaiSan = await _context.CapPhatTaiSans.FindAsync(id);
            if (capPhatTaiSan == null)
            {
                return null;
            }

            capPhatTaiSan.NhanVienId = request.NhanVienId;
            capPhatTaiSan.TaiSanId = request.TaiSanId;
            capPhatTaiSan.NgayCapPhat = request.NgayCapPhat;
            capPhatTaiSan.NgayTraLai = request.NgayTraLai;
            capPhatTaiSan.TinhTrang = request.TinhTrang;

            await _context.SaveChangesAsync();
            return CapPhatTaiSanConverter.EntityToDTO(capPhatTaiSan);
        }

        public async Task<DataResponseCapPhatTaiSan> ThemCapPhatTaiSan(Request_ThemCapPhatTaiSan request)
        {
            var capPhatTaiSan = new CapPhatTaiSan()
            {
                NhanVienId = request.NhanVienId,
                TaiSanId = request.TaiSanId,
                NgayCapPhat = request.NgayCapPhat,
                NgayTraLai = request.NgayTraLai,
                TinhTrang = request.TinhTrang,
            };
            _context.CapPhatTaiSans.Add(capPhatTaiSan);
            await _context.SaveChangesAsync();
            return CapPhatTaiSanConverter.EntityToDTO(capPhatTaiSan);
        }

        public async Task<bool> XoaCapPhatTaiSan(int id)
        {
            var result = await _context.CapPhatTaiSans.FindAsync(id);
            if (result == null)
            {
                return false;
            }

            try
            {
                _context.CapPhatTaiSans.Remove(result);
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
