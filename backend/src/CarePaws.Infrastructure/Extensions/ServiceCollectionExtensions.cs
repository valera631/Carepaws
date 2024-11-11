using CarePaws.Infrastructure.Repositories;
using CarePaws.Domain.Repositories;
using CarePaws.Domain.Common;
using Microsoft.Extensions.DependencyInjection;
using CarePaws.Infrastructure.Services;
using CarePaws.Domain.Services;

namespace CarePaws.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IVolunteerRepository, VolunteerRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
