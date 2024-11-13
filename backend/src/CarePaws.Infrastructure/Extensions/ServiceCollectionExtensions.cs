using CarePaws.Infrastructure.Repositories;
using CarePaws.Domain.Repositories;
using CarePaws.Domain.Common;
using Microsoft.Extensions.DependencyInjection;
using CarePaws.Infrastructure.Services;
using CarePaws.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarePaws.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Регистрация DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DATABASE"))
                       .UseSnakeCaseNamingConvention());

            // Регистрация сервисов и репозиториев
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IVolunteerRepository, VolunteerRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
