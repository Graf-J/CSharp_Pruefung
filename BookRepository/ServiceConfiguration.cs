using BookRepository.Data;
using BookRepository.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookRepository
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddBookService(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Database Context
            services.AddDbContext<DataContext>(options => options.UseMySql(
                configuration.GetConnectionString("MariaDB"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("MariaDB"))
            ));

            // Register the BookService
            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }
}
