using eshop.DataAccess.Data;
using eshop.DataAccess.Repositories;
using eshop.Services;
using eshop.Services.MapProfiler;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eshop.MVC.Extensions
{
    public static class IoCExtensions
    {
        /// <summary>
        /// Bu uygulamanın çalışması için gereken; hem servis hem de repository instance'larını ekleyen extension method.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString">appsettings içerisinde yer alan bağlantı cümlesi</param>
        /// <returns></returns>
        public static IServiceCollection AddNecessaryInecjtions(this IServiceCollection services, string connectionString)
        {

            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddDbContext<TurkcellDbContext>(options => options.UseSqlServer(connectionString));
            return services;

        }
    }
}
