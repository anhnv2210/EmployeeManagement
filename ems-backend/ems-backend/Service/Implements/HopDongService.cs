using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.HopDongRequest;
using ems_backend.Models.ResponseModels.DataHopDongLaoDong;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class HopDongService : IHopDongService
    {
        private readonly AppDbContext _context;
        public HopDongService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DataResponseHopDong> LayHopDongTheoId(int id)
        {
            var result = await _context.HopDongs
               .Include(hd => hd.NhanVien).ThenInclude(nv => nv.ChucDanh)
               .Include(hd => hd.HoSoLuong)
               .Include(hd => hd.LoaiHopDong)
               .FirstOrDefaultAsync(hd => hd.Id == id);
            return HopDongConverter.EntityToDTO(result);
        }

        public async Task<PageResult<DataResponseHopDong>> LayTatCaHopDong(int pageSize = 10, int pageNumber = 1)
        {
            var query =  _context.HopDongs
               .Include(hd => hd.NhanVien).ThenInclude(nv => nv.ChucDanh)
               .Include(hd => hd.HoSoLuong)
               .Include(hd => hd.LoaiHopDong)
                .AsQueryable();
            var result = Pagination.GetPagedData(query.Select(x => HopDongConverter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        public async Task<DataResponseHopDong> SuaHopDong(int id, Request_SuaHopDong request)
        {

            var hopDong = await _context.HopDongs.FindAsync(id);
            if (hopDong == null)
            {
                return null;
            }

            hopDong.NhanVienId = request.NhanVienId;
            hopDong.HoSoLuongId = request.HoSoLuongId;
            hopDong.QuyetDinhId = request.QuyetDinhId;
            hopDong.ChiTietHopDong = request.ChiTietHopDong;
            hopDong.LoaiHopDongId = request.LoaiHopDongId;
            hopDong.NgayBatDau = request.NgayBatDau;
            hopDong.NgayKetThuc = request.NgayKetThuc;

            await _context.SaveChangesAsync();
            return HopDongConverter.EntityToDTO(hopDong);
        }

        public async Task<DataResponseHopDong> ThemHopDong(Request_ThemHopDong request)
        {
            var hopDong = new HopDong()
            {
                NhanVienId = request.NhanVienId,
                LoaiHopDongId = request.LoaiHopDongId,
                HoSoLuongId = request.HoSoLuongId,
                ChiTietHopDong = request.ChiTietHopDong,
                QuyetDinhId = request.QuyetDinhId,
                NgayBatDau = request.NgayBatDau,
                NgayKetThuc = request.NgayKetThuc
            };

            _context.HopDongs.Add(hopDong);
            await _context.SaveChangesAsync();

            var quyetDinh = await _context.QuyetDinhs.FindAsync(hopDong.QuyetDinhId);
            if (quyetDinh != null)
            {
                quyetDinh.HopDongId = hopDong.Id;
                _context.Update(quyetDinh);
                _context.SaveChangesAsync();
            }
            return HopDongConverter.EntityToDTO(hopDong);
        }

        public async Task<bool> XoaHopDong(int id)
        {
            var hopDong = await _context.HopDongs.FindAsync(id);
            if (hopDong == null)
            {
                return false;
            }

            try
            {
                var quyetDinh = await _context.QuyetDinhs.FindAsync(hopDong.QuyetDinhId);
                if(quyetDinh != null)
                {
                    _context.QuyetDinhs.Remove(quyetDinh);
                    await _context.SaveChangesAsync();
                }
                _context.HopDongs.Remove(hopDong);
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
