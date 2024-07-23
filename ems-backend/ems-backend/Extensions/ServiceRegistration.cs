using ems_backend.Data.DataContext;
using ems_backend.Models.Converters;
using ems_backend.Models.Response;
using ems_backend.Models.ResponseModels.DataChucDanh;
using ems_backend.Service.Implements;
using ems_backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Extensions
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services, string connectionString)
        {
            // Register DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            // ChucDanhService
            services.AddScoped<ChucDanhConverter>();
            services.AddScoped<ResponseObject<DataResponseChucDanh>>();
            services.AddScoped<IChucDanhService, ChucDanhService>();
        }
    }
}