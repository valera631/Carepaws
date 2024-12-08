using CarePaws.Application.Services;
using CarePaws.Domain.Common;
using CarePaws.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarePaws.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
        
           

            // Регистрация других сервисов
            services.AddScoped<VolunteerRegistrationService>();
            services.AddScoped<VolunteerLoginService>();
            services.AddScoped<VolunteerProfileService>();
            services.AddScoped<JwtService>();

            return services;
        }
    }
}