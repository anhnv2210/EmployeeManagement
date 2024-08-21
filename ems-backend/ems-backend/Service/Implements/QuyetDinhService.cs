using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.QuyetDinhRequest;
using ems_backend.Models.ResponseModels.DataHopDongLaoDong;
using ems_backend.Models.ResponseModels.DataQuanHuyen;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class QuyetDinhService : IQuyetDinhService
    {
        private readonly AppDbContext _context;
        public QuyetDinhService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DataResponseQuyetDinh> LayQuyetDinhTheoId(int id)
        {
            var result = await _context.QuyetDinhs
               .Include(qd => qd.NhanVien).ThenInclude(nv => nv.ChucDanh)
               .Include(qd => qd.HoSoLuong)
               .FirstOrDefaultAsync(qd => qd.Id == id);
            return QuyetDinhConverter.EntityToDTO(result);
        }

        public async Task<PageResult<DataResponseQuyetDinh>> LayTatCaQuyetDinh(int pageSize = 10, int pageNumber = 1)
        {
            var query = _context.QuyetDinhs
               .Include(qd => qd.NhanVien).ThenInclude(nv => nv.ChucDanh)
               .Include(qd => qd.HoSoLuong)
                .AsQueryable();
            var result = Pagination.GetPagedData(query.Select(x => QuyetDinhConverter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        public async Task<DataResponseQuyetDinh> SuaQuyetDinh(int id, Request_SuaQuyetDinh request)
        {
            var quyetDinh = await _context.QuyetDinhs.FindAsync(id);
            if (quyetDinh == null)
            {
                return null;
            }

            quyetDinh.NhanVienId = request.NhanVienId;
            quyetDinh.HoSoLuongId = request.HoSoLuongId;
            quyetDinh.NoiDung = request.NoiDung;
            quyetDinh.NgayQuyetDinh = request.NgayQuyetDinh;

            await _context.SaveChangesAsync();
            return QuyetDinhConverter.EntityToDTO(quyetDinh);
        }

        public async Task<DataResponseQuyetDinh> ThemQuyetDinh(Request_ThemQuyetDinh request)
        {
            var quyetDinh = new QuyetDinh()
            {
                NhanVienId = request.NhanVienId,
                HoSoLuongId = request.HoSoLuongId,
                NoiDung = request.NoiDung,
                HopDongId = null,
                NgayQuyetDinh = request.NgayQuyetDinh                                                                                                                                                         
            };
            _context.QuyetDinhs.Add(quyetDinh);
            await _context.SaveChangesAsync();
            return QuyetDinhConverter.EntityToDTO(quyetDinh);
        }

        public async Task<bool> XoaQuyetDinh(int id)
        {
            var quyetDinh = await _context.QuyetDinhs.FindAsync(id);
            if (quyetDinh == null)
            {
                return false;
            }

            try
            {
                var hopDong = await _context.HopDongs.FindAsync(quyetDinh.HopDongId);
                if (hopDong != null)
                {
                    _context.HopDongs.Remove(hopDong);
                    _context.SaveChangesAsync();
                }
                _context.QuyetDinhs.Remove(quyetDinh);
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
