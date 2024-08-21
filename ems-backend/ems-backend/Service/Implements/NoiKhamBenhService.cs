using ems_backend.Common.HandleExceptions;
using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.NoiKhamBenhRequest;
using ems_backend.Models.ResponseModels.DataNoiKhamBenh;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class NoiKhamBenhService : INoiKhamBenhService
    {
        private readonly AppDbContext _context;
        
        public NoiKhamBenhService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            if (!await _context.NoiKhamBenhs.AnyAsync(nkb => nkb.Email.ToLower() == email.ToLower()) || HandleValidationException.ValidateEmail(email))
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CheckSoDienThoaiExists(string soDienThoai)
        {
            if (!await _context.NoiKhamBenhs.AnyAsync(nkb => nkb.SDT == soDienThoai) || HandleValidationException.ValidatePhoneNumber(soDienThoai))
            {
                return false;
            }
            return true;
        }

        public async Task<DataResponseNoiKhamBenh> LayNoiKhamBenhTheoId(int id)
        {
            var noiKhamBenh = await _context.NoiKhamBenhs
              .Include(nh => nh.NguoiTao)
              .Include(nh => nh.NguoiCapNhat).FirstOrDefaultAsync(nkb => nkb.Id == id);
            return NoiKhamBenhConverter.EntityToDTO(noiKhamBenh);
        }
    

        public async Task<PageResult<DataResponseNoiKhamBenh>> LayTatCaNoiKhamBenh(bool? isActive, int pageSize = 10, int pageNumber = 1)
        {
            var query = _context.NoiKhamBenhs
                  .Include(nkb => nkb.NguoiTao)
                  .Include(nkb => nkb.NguoiCapNhat)
                  .AsQueryable();
            if (isActive.HasValue)
            {
                query = query.Where(nkb => nkb.IsActive == isActive.Value);
            }
            var result = Pagination.GetPagedData(query.Select(x => NoiKhamBenhConverter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        public async Task<DataResponseNoiKhamBenh> SuaNoiKhamBenh(int id, Request_SuaNoiKhamBenh request)
        {
            var noiKhamBenh = await _context.NoiKhamBenhs.FindAsync(id);
            if (noiKhamBenh == null)
            {
                return null;
            }

            noiKhamBenh.TenNoiKhamBenh = request.TenNoiKhamBenh;
            noiKhamBenh.DiaChi = request.DiaChi;
            noiKhamBenh.Email = request.Email;
            noiKhamBenh.SDT = request.SDT;
            noiKhamBenh.GhiChu = request.GhiChu;
            noiKhamBenh.NguoiCapNhatId = request.NguoiCapNhatId;
            noiKhamBenh.IsActive = request.IsActive;
            noiKhamBenh.NgayCapNhat = DateTime.Now;

            await _context.SaveChangesAsync();
            return NoiKhamBenhConverter.EntityToDTO(noiKhamBenh);
        }

        public async Task<DataResponseNoiKhamBenh> ThemNoiKhamBenh(Request_ThemNoiKhamBenh request)
        {
            var noiKhamBenh = new NoiKhamBenh()
            {
                TenNoiKhamBenh = request.TenNoiKhamBenh,
                Email = request.Email,
                DiaChi = request.DiaChi,
                SDT = request.SDT,
                GhiChu = request.GhiChu,
                NguoiTaoId = request.NguoiTaoId,
                NguoiCapNhatId = request.NguoiCapNhatId,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                IsActive = request.IsActive
            };

            _context.NoiKhamBenhs.Add(noiKhamBenh);
            await _context.SaveChangesAsync();
            return NoiKhamBenhConverter.EntityToDTO(noiKhamBenh);
        }

        public async Task<bool> XoaNoiKhamBenh(int id)
        {
            var noiKhamBenh = await _context.NoiKhamBenhs.FindAsync(id);
            if (noiKhamBenh == null)
            {
                return false;
            }

            try
            {
                foreach (var nhanVien in _context.NhanViens)
                {
                    if (nhanVien.NoiKhamBenhId == id)
                        nhanVien.NoiKhamBenhId = null;
                }
                _context.NoiKhamBenhs.Remove(noiKhamBenh);
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
