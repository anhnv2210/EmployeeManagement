using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.XaPhuongRequest;
using ems_backend.Models.ResponseModels.DataXaPhuong;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class XaPhuongService : IXaPhuongService
    {
        private readonly AppDbContext _context;
        public XaPhuongService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PageResult<DataResponseXaPhuong>> LayTatCaXaPhuong(int pageSize = 10, int pageNumber = 1)
        {
            var query = _context.XaPhuongs
                .Include(xp => xp.QuocGia)
                .Include(xp => xp.TinhThanh)
                .Include(xp => xp.QuanHuyen)
                .AsQueryable();
            var result = Pagination.GetPagedData(query.Select(x => XaPhuongConverter.EntityToDTO(x)), pageSize, pageNumber);

            return result;
        }

        public async Task<IEnumerable<DataResponseXaPhuong>> LayTatCaXaPhuongByQuanHuyen(int quanHuyenId)
        {
            var query = _context.XaPhuongs
                .Include(xp => xp.QuocGia)
                .Include(xp => xp.TinhThanh)
                .Include(xp => xp.QuanHuyen)
                .Where(xp => xp.QuanHuyenId == quanHuyenId)
                .AsQueryable();
            var result = query.Select(xp => XaPhuongConverter.EntityToDTO(xp));
            return result;
        }

        public async Task<DataResponseXaPhuong> LayXaPhuongTheoId(int id)
        {
            var xaPhuong = await _context.XaPhuongs
            .Include(xp => xp.QuocGia)
            .Include(xp => xp.TinhThanh)
            .Include(xp => xp.QuanHuyen)
            .FirstOrDefaultAsync(xp => xp.Id == id);
            return XaPhuongConverter.EntityToDTO(xaPhuong);
        }

        public async Task<DataResponseXaPhuong> SuaXaPhuong(int id, Request_SuaXaPhuong request)
        {
            var xaPhuong = await _context.XaPhuongs.FindAsync(id);
            if (xaPhuong == null)
            {
                return null;
            }

            xaPhuong.TenXaPhuong = request.TenXaPhuong;
            xaPhuong.QuocGiaId = request.QuocGiaId;
            xaPhuong.TinhThanhId = request.TinhThanhId;
            xaPhuong.QuanHuyenId = request.QuanHuyenId;
            xaPhuong.MoTa = request.MoTa;

            await _context.SaveChangesAsync();
            return XaPhuongConverter.EntityToDTO(xaPhuong);
        }

        public async Task<DataResponseXaPhuong> ThemXaPhuong(Request_ThemXaPhuong request)
        {
            var xaPhuong = new XaPhuong()
            {
                TenXaPhuong = request.TenXaPhuong,
                QuocGiaId = request.QuocGiaId,
                TinhThanhId = request.TinhThanhId,
                QuanHuyenId = request.QuanHuyenId,
                MoTa = request.MoTa,
            };

            _context.XaPhuongs.Add(xaPhuong);
            await _context.SaveChangesAsync();
            return XaPhuongConverter.EntityToDTO(xaPhuong);
        }

        public async Task<bool> XoaXaPhuong(int id)
        {
            var xaPhuong = await _context.XaPhuongs.FindAsync(id);
            if (xaPhuong == null)
            {
                return false;
            }

            try
            {
                foreach (var nhanVien in _context.NhanViens)
                {
                    if (nhanVien.XaPhuongId == id)
                        nhanVien.XaPhuongId = null;
                }
                _context.XaPhuongs.Remove(xaPhuong);
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
