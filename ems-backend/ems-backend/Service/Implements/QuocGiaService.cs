﻿using ems_backend.Data.DataContext;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.QuocGiaRequest;
using ems_backend.Models.ResponseModels.DataQuocGia;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class QuocGiaService : IQuocGiaService
    {
        private readonly AppDbContext _context;
        public QuocGiaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckTenQuocGiaExists(string tenQuocGia)
        {
            return await _context.QuocGias.AnyAsync(qg => qg.TenQuocGia.ToLower() == tenQuocGia.ToLower());
        }

        public async Task<DataResponseQuocGia> LayQuocGiaTheoId(int id)
        {
            var quocGia = await _context.QuocGias
            .Include(qg => qg.NguoiTao)
            .Include(qg => qg.NguoiCapNhat).FirstOrDefaultAsync(qg => qg.Id == id);
            return QuocGiaConverter.EntityToDTO(quocGia);
        }

        public async Task<IEnumerable<DataResponseQuocGia>> LayTatCaQuocGia()
        {
            var query = _context.QuocGias
                .Include(qg => qg.NguoiTao)
                .Include(qg => qg.NguoiCapNhat)
                .AsQueryable();
            var result = query.Select(qg => QuocGiaConverter.EntityToDTO(qg));
            return result;
        }

        public async Task<DataResponseQuocGia> SuaQuocGia(int id, Request_SuaQuocGia request)
        {
            var quocGia = await _context.QuocGias.FindAsync(id);
            if (quocGia == null)
            {
                return null;
            }

            quocGia.TenQuocGia = request.TenQuocGia;
            quocGia.MoTa = request.MoTa;
            quocGia.NguoiCapNhatId = request.NguoiCapNhatId;
            quocGia.IsActive = request.IsActive;
            quocGia.NgayCapNhat = DateTime.Now;

            await _context.SaveChangesAsync();
            return QuocGiaConverter.EntityToDTO(quocGia);
        }

        public async Task<DataResponseQuocGia> ThemQuocGia(Request_ThemQuocGia request)
        {
            var quocGia = new QuocGia()
            {
                TenQuocGia = request.TenQuocGia,
                MoTa = request.MoTa,
                NguoiTaoId = request.NguoiTaoId,
                NguoiCapNhatId = request.NguoiCapNhatId,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                IsActive = request.IsActive
            };

            _context.QuocGias.Add(quocGia);
            await _context.SaveChangesAsync();
            return QuocGiaConverter.EntityToDTO(quocGia);
        }

        public async Task<bool> XoaQuocGia(int id)
        {
            var quocGia = await _context.QuocGias.FindAsync(id);
            if (quocGia == null)
            {
                return false;
            }

            try
            {
                _context.QuocGias.Remove(quocGia);
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