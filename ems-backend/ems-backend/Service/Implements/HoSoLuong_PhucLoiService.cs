using ems_backend.Data.DataContext;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.HoSoLuongRequest;
using ems_backend.Models.ResponseModels.DataHoSoLuong;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class HoSoLuong_PhucLoiService : IHoSoLuong_PhucLoiService
    {
        private readonly AppDbContext _context;
        public HoSoLuong_PhucLoiService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddHoSoLuong_PhucLoiAsync(List<Request_HoSoLuong_PhucLoi> requests)
        {
            var entities = requests.Select(dto => new HoSoLuong_PhucLoi
            {
                HoSoLuongId = dto.HoSoLuongId,
                PhucLoiId = dto.PhucLoiId,
            }).ToList();

            _context.HoSoLuong_PhucLois.AddRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DataResponseHoSoLuongPhucLoi>> GetHoSoLuong_PhucLoiAsync(int hoSoLuongId)
        {
            return await _context.HoSoLuong_PhucLois
               .Include(x => x.PhucLoi)
               .Include(x => x.HoSoLuong)
               .Where(h => h.HoSoLuongId == hoSoLuongId)
               .Select(x => HoSoLuongPhucLoiConverter.EntityToDTO(x))
               .ToListAsync();
        }
    }
}
