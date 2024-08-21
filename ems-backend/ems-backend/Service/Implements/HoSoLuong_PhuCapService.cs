using ems_backend.Data.DataContext;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.HoSoLuongRequest;
using ems_backend.Models.ResponseModels.DataHoSoLuong;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ems_backend.Service.Implements
{
    public class HoSoLuong_PhuCapService : IHoSoLuong_PhuCapService
    {
        private readonly AppDbContext _context;
        public HoSoLuong_PhuCapService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddHoSoLuong_PhuCapAsync(List<Request_HoSoLuong_PhuCap> requests)
        {
            var entities = requests.Select(dto => new HoSoLuong_PhuCap
            {
                HoSoLuongId = dto.HoSoLuongId,
                PhuCapId = dto.PhuCapId,
                SoTien = dto.SoTien
            }).ToList();

            _context.HoSoLuong_PhuCaps.AddRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DataResponseHoSoLuongPhuCap>> GetHoSoLuong_PhuCapAsync(int hoSoLuongId)
        {
            return await _context.HoSoLuong_PhuCaps
                .Include(x => x.PhuCap)
                .Include(x => x.HoSoLuong)
                .Where(h => h.HoSoLuongId == hoSoLuongId)
                .Select(x => HoSoLuongPhuCapConverter.EntityToDTO(x))
                .ToListAsync();

        }
    }
}
