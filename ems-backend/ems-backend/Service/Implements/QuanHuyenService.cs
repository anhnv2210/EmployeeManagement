﻿using ems_backend.Data.DataContext;
using ems_backend.Models.Converters;
using ems_backend.Models.Entities;
using ems_backend.Models.RequestModel.QuanHuyenRequest;
using ems_backend.Models.ResponseModels.DataQuanHuyen;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class QuanHuyenService : IQuanHuyenService
    { 
        private readonly AppDbContext _context;
        public QuanHuyenService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DataResponseQuanHuyen> LayQuanHuyenTheoId(int id)
        {
            var quanHuyen = await _context.QuanHuyens
            .Include(qh => qh.QuocGia)
            .Include(qh => qh.TinhThanh)
            .Include(qh => qh.NguoiTao)
            .Include(qh => qh.NguoiCapNhat).FirstOrDefaultAsync(qh => qh.Id == id);
            return QuanHuyenConverter.EntityToDTO(quanHuyen);
        }

        public async Task<IEnumerable<DataResponseQuanHuyen>> LayTatCaQuanHuyen()
        {
            var query = _context.QuanHuyens
                .Include(qh => qh.QuocGia)
                .Include(qh => qh.TinhThanh)
                .Include(qh => qh.NguoiTao)
                .Include(qh => qh.NguoiCapNhat)
                .AsQueryable();
            var result = query.Select(qh => QuanHuyenConverter.EntityToDTO(qh));
            return result;
        }

        public async Task<DataResponseQuanHuyen> SuaQuanHuyen(int id, Request_SuaQuanHuyen request)
        {
            var quanHuyen = await _context.QuanHuyens.FindAsync(id);
            if (quanHuyen == null)
            {
                return null;
            }

            quanHuyen.TenQuanHuyen = request.TenQuanHuyen;
            quanHuyen.MoTa = request.MoTa;
            quanHuyen.NguoiCapNhatId = request.NguoiCapNhatId;
            quanHuyen.IsActive = request.IsActive;
            quanHuyen.NgayCapNhat = DateTime.Now;

            await _context.SaveChangesAsync();
            return QuanHuyenConverter.EntityToDTO(quanHuyen);
        }

        public async Task<DataResponseQuanHuyen> ThemQuanHuyen(Request_ThemQuanHuyen request)
        {
            var quanHuyen = new QuanHuyen()
            {
                TenQuanHuyen = request.TenQuanHuyen,
                QuocGiaId = request.QuocGiaId,
                TinhThanhId = request.TinhThanhId,
                MoTa = request.MoTa,
                NguoiTaoId = request.NguoiTaoId,
                NguoiCapNhatId = request.NguoiCapNhatId,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                IsActive = request.IsActive
            };

            _context.QuanHuyens.Add(quanHuyen);
            await _context.SaveChangesAsync();
            return QuanHuyenConverter.EntityToDTO(quanHuyen);
        }

        public async Task<bool> XoaQuanHuyen(int id)
        {
            var quanHuyen = await _context.QuanHuyens.FindAsync(id);
            if (quanHuyen == null)
            {
                return false;
            }

            try
            {
                _context.QuanHuyens.Remove(quanHuyen);
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