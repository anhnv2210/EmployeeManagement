using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.HoSoLuongRequest;
using ems_backend.Models.ResponseModels.DataHoSoLuong;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class HoSoLuongService : IHoSoLuongService
    {
        private readonly AppDbContext _context;
        public HoSoLuongService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DataResponseHoSoLuong> LayHoSoLuongTheoId(int id)
        {
            var query = await _context.HoSoLuongs
                .Include(x => x.NhanVien)
                .Include(x => x.PhongBan)
                .Include(x => x.ChucDanh)
                .FirstOrDefaultAsync(x =>x.Id == id);
            return HoSoLuongConverter.EntityToDTO(query);
        }

        public async Task<PageResult<DataResponseHoSoLuong>> LayTatCaHoSoLuong(int pageSize, int pageNumber)
        {
            var query = _context.HoSoLuongs
                .Include(x => x.NhanVien)
                .Include(x => x.PhongBan)
                .Include(x => x.ChucDanh)
                .AsQueryable();

            var result = Pagination.GetPagedData(query.Select(x => HoSoLuongConverter.EntityToDTO(x)), pageSize, pageNumber);

            return result;
        }

        public async Task<DataResponseHoSoLuong> ThemHoSoLuong(Request_ThemHoSoLuong request)
        {
            var hoSoLuong = new HoSoLuong()
            {
                NhanVienId = request.NhanVienId,
                PhongBanId = request.PhongBanId,
                ChucDanhId  = request.ChucDanhId,
                ThangLuong = request.ThangLuong,
                BacLuong = request.BacLuong,
                LuongMax = request.LuongMax,
                LuongMin = request.LuongMin,
            };

            _context.HoSoLuongs.Add(hoSoLuong);
            await _context.SaveChangesAsync();
            return HoSoLuongConverter.EntityToDTO(hoSoLuong);
        }
    }
}
