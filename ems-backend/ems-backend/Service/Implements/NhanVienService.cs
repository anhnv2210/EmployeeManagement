using ems_backend.Data.DataContext;
using ems_backend.Models.Converters;
using ems_backend.Models.ResponseModels.DataNhanVien;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class NhanVienService : INhanVienService
    {
        private readonly AppDbContext _context;
        public NhanVienService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DataResponseNhanVien>> LayTatCaNhanVien()
        {
            var query = _context.NhanViens
                .Include(nv => nv.PhongBan)
                .Include(nv => nv.ChucDanhPhongBan).ThenInclude(cdpb => cdpb.ChucDanh)
                .Include(nv => nv.XaPhuong)
                .Include(nv => nv.QuanHuyen)
                .Include(nv => nv.TinhThanh)
                .Include(nv => nv.NganHang)
                .Include(nv => nv.ChiNhanhNganHang)
                .Include(nv => nv.NoiKhamBenh)
                .Include(nv => nv.NguoiTao)
                .Include(nv => nv.NguoiCapNhat)
                .AsQueryable();
            var result = query.Select(x => NhanVienConverter.EntityToDTO(x));
            return result;
        }
    }
}
