using ems_backend.Data.DataContext;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.DanhMucKhacRequest;
using ems_backend.Models.ResponseModels.DataDanhMucKhac;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class DanhMucKhacService : IDanhMucKhacService
    {
        private readonly AppDbContext _context;
        public DanhMucKhacService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DataResponseDanhMucKhac> LayDanhMucKhacTheoId(int id)
        {
            var danhMucKhac = await _context.DanhMucKhacs
            .Include(dmk => dmk.NguoiTao)
            .Include(dmk => dmk.NguoiCapNhat).FirstOrDefaultAsync(dmk => dmk.Id == id);
            return DanhMucKhacConverter.EntityToDTO(danhMucKhac);
        }

        public async Task<IEnumerable<DataResponseDanhMucKhac>> LayTatCaDanhMucKhac()
        {
            var query = _context.DanhMucKhacs
                .Include(dmk => dmk.NguoiTao)
                .Include(dmk => dmk.NguoiCapNhat)
                .AsQueryable();
            var result = query.Select(dmk => DanhMucKhacConverter.EntityToDTO(dmk));
            return result;
        }

        public async Task<DataResponseDanhMucKhac> SuaDanhMucKhac(int id, Request_SuaDanhMucKhac request)
        {
            var danhMucKhac = await _context.DanhMucKhacs.FindAsync(id);
            if (danhMucKhac == null)
            {
                return null;
            }

            danhMucKhac.TenThamSo = request.TenThamSo;
            danhMucKhac.GiaTri = request.GiaTri;
            danhMucKhac.MoTa = request.MoTa;
            danhMucKhac.NguoiCapNhatId = request.NguoiCapNhatId;
            danhMucKhac.IsActive = request.IsActive;
            danhMucKhac.NgayCapNhat = DateTime.Now;

            await _context.SaveChangesAsync();
            return DanhMucKhacConverter.EntityToDTO(danhMucKhac);
        }

        public async Task<DataResponseDanhMucKhac> ThemDanhMucKhac(Request_ThemDanhMucKhac request)
        {
            var danhMucKhac = new DanhMucKhac()
            {
                TenThamSo = request.TenThamSo,
                GiaTri = request.GiaTri,
                MoTa = request.MoTa,
                NguoiTaoId = request.NguoiTaoId,
                NguoiCapNhatId = request.NguoiCapNhatId,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                IsActive = request.IsActive
            };
            _context.DanhMucKhacs.Add(danhMucKhac);
            await _context.SaveChangesAsync();
            return DanhMucKhacConverter.EntityToDTO(danhMucKhac);
        }

        public async Task<bool> XoaDanhMucKhac(int id)
        {
            var danhMucKhac = await _context.DanhMucKhacs.FindAsync(id);
            if (danhMucKhac == null)
            {
                return false;
            }

            try
            {
                _context.DanhMucKhacs.Remove(danhMucKhac);
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
