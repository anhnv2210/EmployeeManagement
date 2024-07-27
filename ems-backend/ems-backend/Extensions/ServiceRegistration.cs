using ems_backend.Data.DataContext;
using ems_backend.Models.Converters;
using ems_backend.Models.Response;
using ems_backend.Models.ResponseModels.DataChucDanh;
using ems_backend.Models.ResponseModels.DataDanhMucKhac;
using ems_backend.Models.ResponseModels.DataLoaiHopDong;
using ems_backend.Models.ResponseModels.DataNhanVien;
using ems_backend.Models.ResponseModels.DataPhongBan;
using ems_backend.Models.ResponseModels.DataPhucLoi;
using ems_backend.Models.ResponseModels.DataTaiSan;
using ems_backend.Models.ResponseModels.ResponsePhuCap;
using ems_backend.Service.Implements;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Extensions
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<ChucDanhConverter>();
            services.AddScoped<ResponseObject<DataResponseChucDanh>>();
            services.AddScoped<IChucDanhService, ChucDanhService>();

            services.AddScoped<NhanVienConverter>();
            services.AddScoped<ResponseObject<DataResponseNhanVien>>();
            services.AddScoped<INhanVienService, NhanVienService>();

            services.AddScoped<PhongBanConverter>();
            services.AddScoped<ResponseObject<DataResponsePhongBan>>();
            services.AddScoped<IPhongBanService, PhongBanService>();

            services.AddScoped<LoaiHopDongConverter>();
            services.AddScoped<ResponseObject<DataResponseLoaiHopDong>>();
            services.AddScoped<ILoaiHopDongService, LoaiHopDongService>();

            services.AddScoped<PhuCapConverter>();
            services.AddScoped<ResponseObject<DataResponsePhuCap>>();
            services.AddScoped<IPhuCapService, PhuCapService>();

            services.AddScoped<PhucLoiConverter>();
            services.AddScoped<ResponseObject<DataResponsePhucLoi>>();
            services.AddScoped<IPhucLoiService, PhucLoiService>();

            services.AddScoped<TaiSanConverter>();
            services.AddScoped<ResponseObject<DataResponseTaiSan>>();
            services.AddScoped<ITaiSanService, TaiSanService>();

            services.AddScoped<DanhMucKhacConverter>();
            services.AddScoped<ResponseObject<DataResponseDanhMucKhac>>();
            services.AddScoped<IDanhMucKhacService, DanhMucKhacService>();

            services.AddScoped<IChucDanhTheoPhongBanService, ChucDanhTheoPhongBanService>();
        }
    }
}