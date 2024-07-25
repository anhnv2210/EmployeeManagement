using ems_backend.Data.DataContext;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.TinhThanhRequest;
using ems_backend.Models.ResponseModels.DataTinhThanh;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class TinhThanhService : ITinhThanhService
    {
        private readonly AppDbContext _context;
        public TinhThanhService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckTenTinhThanhExists(string tenTinhThanh)
        {
            return await _context.TinhThanhs.AnyAsync(tt => tt.TenTinhThanh.ToLower() == tenTinhThanh.ToLower());
        }

        public async Task<IEnumerable<DataResponseTinhThanh>> LayTatCaTinhThanh()
        {
            var query = _context.TinhThanhs
                .Include(tt => tt.QuocGia)
                .Include(qg => qg.NguoiTao)
                .Include(qg => qg.NguoiCapNhat)
                .AsQueryable();
            var result = query.Select(tt => TinhThanhConverter.EntityToDTO(tt));
            return result;
        }

        public async Task<DataResponseTinhThanh> LayTinhThanhTheoId(int id)
        {
            var tinhThanh = await _context.TinhThanhs
            .Include(tt => tt.QuocGia)
            .Include(tt => tt.NguoiTao)
            .Include(tt => tt.NguoiCapNhat).FirstOrDefaultAsync(tt => tt.Id == id);
            return TinhThanhConverter.EntityToDTO(tinhThanh);
        }

        public async Task<DataResponseTinhThanh> SuaTinhThanh(int id, Request_SuaTinhThanh request)
        {
            var tinhThanh = await _context.TinhThanhs.FindAsync(id);
            if (tinhThanh == null)
            {
                return null;
            }

            tinhThanh.TenTinhThanh = request.TenTinhThanh;
            tinhThanh.MoTa = request.MoTa;
            tinhThanh.NguoiCapNhatId = request.NguoiCapNhatId;
            tinhThanh.IsActive = request.IsActive;
            tinhThanh.NgayCapNhat = DateTime.Now;

            await _context.SaveChangesAsync();
            return TinhThanhConverter.EntityToDTO(tinhThanh);
        }
    

        public async Task<DataResponseTinhThanh> ThemTinhThanh(Request_ThemTinhThanh request)
        {
            var tinhThanh = new TinhThanh()
            {
                TenTinhThanh = request.TenTinhThanh,
                QuocGiaId = request.QuocGiaId,
                MoTa = request.MoTa,
                NguoiTaoId = request.NguoiTaoId,
                NguoiCapNhatId = request.NguoiCapNhatId,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                IsActive = request.IsActive
            };

            _context.TinhThanhs.Add(tinhThanh);
            await _context.SaveChangesAsync();
            return TinhThanhConverter.EntityToDTO(tinhThanh);
        }

        public async Task<bool> XoaTinhThanh(int id)
        {
            var tinhThanh = await _context.TinhThanhs.FindAsync(id);
            if (tinhThanh == null)
            {
                return false;
            }

            try
            {
                _context.TinhThanhs.Remove(tinhThanh);
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
