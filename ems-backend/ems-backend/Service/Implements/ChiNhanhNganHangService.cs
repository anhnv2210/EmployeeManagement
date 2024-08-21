using ems_backend.Common.HandleExceptions;
using ems_backend.Data.DataContext;
using ems_backend.Data.Reponsitories.HandlePagination;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.ChiNhanhNganHang;
using ems_backend.Models.ResponseModels.DataChiNhanhNganHang;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class ChiNhanhNganHangService : IChiNhanhNganHangService
    {
        private readonly AppDbContext _context;
        public ChiNhanhNganHangService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            if (!await _context.ChiNhanhNganHangs.AnyAsync(cnnh => cnnh.Email.ToLower() == email.ToLower()) || HandleValidationException.ValidateEmail(email))
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CheckSoDienThoaiExists(string soDienThoai)
        {
            if (!await _context.ChiNhanhNganHangs.AnyAsync(cnnh => cnnh.SDT == soDienThoai) || HandleValidationException.ValidatePhoneNumber(soDienThoai))
            {
                return false;
            }
            return true;
        } 

        public async Task<DataResponseChiNhanhNganHang> LayChiNhanhNganHangTheoId(int id)
        {
            var chiNhanh = await _context.ChiNhanhNganHangs
              .Include(cnnh => cnnh.NguoiTao)
              .Include(cnnh => cnnh.NguoiCapNhat)
              .Include(cnnh => cnnh.NganHang)
              .FirstOrDefaultAsync(nh => nh.Id == id);
            return ChiNhanhNganHangConverter.EntityToDTO(chiNhanh);
        }

        public async Task<PageResult<DataResponseChiNhanhNganHang>> LayTatCaChiNhanhNganHang(bool? isActive, int pageSize = 10, int pageNumber = 1)
        {
            var query = _context.ChiNhanhNganHangs
                  .Include(cnnh => cnnh.NguoiTao)
                  .Include(cnnh => cnnh.NguoiCapNhat)
                  .Include(cnnh => cnnh.NganHang)
                  .AsQueryable();
            if (isActive.HasValue)
            {
                query = query.Where(nh => nh.IsActive == isActive.Value);
            }
            var result = Pagination.GetPagedData(query.Select(x => ChiNhanhNganHangConverter.EntityToDTO(x)), pageSize, pageNumber);
            return result;
        }

        public async Task<IEnumerable<DataResponseChiNhanhNganHang>> LayTatCaChiNhanhNganHangByNganHang(int nganHangId)
        {
            var query = _context.ChiNhanhNganHangs
              .Include(cnnh => cnnh.NguoiTao)
              .Include(cnnh => cnnh.NguoiCapNhat)
              .Include(cnnh => cnnh.NganHang)
              .Where(cnnh => cnnh.NganHangId == nganHangId).
              AsQueryable();
            return query.Select(x => ChiNhanhNganHangConverter.EntityToDTO(x)); 

        }

        public async Task<DataResponseChiNhanhNganHang> SuaChiNhanhNganHang(int id, Request_SuaChiNhanhNganHang request)
        {
            var chiNhanh = await _context.ChiNhanhNganHangs.FindAsync(id);
            if (chiNhanh == null)
            {
                return null;
            }

            chiNhanh.TenChiNhanhNganHang = request.TenChiNhanhNganHang;
            chiNhanh.DiaChi = request.DiaChi;
            chiNhanh.Email = request.Email;
            chiNhanh.SDT = request.SoDienThoai;
            chiNhanh.MoTa = request.MoTa;
            chiNhanh.NguoiCapNhatId = request.NguoiCapNhatId;
            chiNhanh.IsActive = request.IsActive;
            chiNhanh.NgayCapNhat = DateTime.Now;

            await _context.SaveChangesAsync();
            return ChiNhanhNganHangConverter.EntityToDTO(chiNhanh);
        }

        public async Task<DataResponseChiNhanhNganHang> ThemChiNhanhNganHang(Request_ThemChiNhanhNganHang request)
        {
            var chiNhanh = new ChiNhanhNganHang()
            {
                TenChiNhanhNganHang = request.TenChiNhanhNganHang,
                Email = request.Email,
                DiaChi = request.DiaChi,
                SDT = request.SoDienThoai,
                MoTa = request.MoTa,
                NguoiTaoId = request.NguoiTaoId,
                NguoiCapNhatId = request.NguoiCapNhatId,
                NganHangId = request.NganHangId,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                IsActive = request.IsActive
            };

            _context.ChiNhanhNganHangs.Add(chiNhanh);
            await _context.SaveChangesAsync();
            return ChiNhanhNganHangConverter.EntityToDTO(chiNhanh);
        }

        public async Task<bool> XoaChiNhanhNganHang(int id)
        {
            var chiNhanh = await _context.ChiNhanhNganHangs.FindAsync(id);
            if (chiNhanh == null)
            {
                return false;
            }

            try
            {
                foreach (var nhanVien in _context.NhanViens)
                {
                    if(nhanVien.ChiNhanhNganHangId == id)
                        nhanVien.ChiNhanhNganHangId = null; 
                }
                _context.ChiNhanhNganHangs.Remove(chiNhanh);
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
