using CarePaws.Application.Services;
using CarePaws.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarePaws.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Регистрация сервисов уровня Application
            services.AddScoped<VolunteerRegistrationService>();
            services.AddScoped<VolunteerLoginService>();

            return services;
        }
    }
}