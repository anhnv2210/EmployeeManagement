using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
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

        public async Task<IEnumerable<DataResponseTinhThanh>> GetTinhThanhByQuocGiaAsync(long quocGiaId)
        {
            var query = _context.TinhThanhs
                .Include(tt => tt.QuocGia)
                .Where(tt => tt.QuocGiaId == quocGiaId) 
                .AsQueryable();
            var result = query.Select(tt => TinhThanhConverter.EntityToDTO(tt));
            return result;
        }

        public async Task<PageResult<DataResponseTinhThanh>> LayTatCaTinhThanh(int pageSize = 10, int pageNumber = 1)
        {
            var query = _context.TinhThanhs
                .Include(tt => tt.QuocGia)
                .AsQueryable();
            var result = Pagination.GetPagedData(query.Select(x => TinhThanhConverter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        public async Task<DataResponseTinhThanh> LayTinhThanhTheoId(int id)
        {
            var tinhThanh = await _context.TinhThanhs
            .Include(tt => tt.QuocGia).FirstOrDefaultAsync(tt => tt.Id == id);
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
                foreach (var nhanVien in _context.NhanViens)
                {
                    if (nhanVien.TinhThanhId == id)
                        nhanVien.TinhThanhId = null;
                }
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
