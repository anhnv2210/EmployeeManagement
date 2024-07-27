using ems_backend.Data.DataContext;
using ems_backend.Models.Converters;
using ems_backend.Models.ResponseModels.DataChucDanhPhongBan;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class ChucDanhTheoPhongBanService : IChucDanhTheoPhongBanService
    {
        private readonly AppDbContext _context;
        public ChucDanhTheoPhongBanService (AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DataResponseChucDanhPhongBan>> GetChucDanhTheoPhongBanAsync()
        {
            var result = await _context.ChucDanhPhongBans
            .Include(cdpb => cdpb.PhongBan)
            .Include(cdpb => cdpb.ChucDanh)
            .Select(cdpb => ChucDanhPhongBanConverter.EntityToDTO(cdpb))
            .ToListAsync();

            return result;
        }
    }
}
