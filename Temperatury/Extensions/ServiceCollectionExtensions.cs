using Application.Interfaces.Repository;
using Application.Interfaces.Repository.SettingsRepositoriesInterfaces;
using Application.Interfaces.Repository.TemperaturyRepositoriesInterfaces;
using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.Repositories;
using Infrastructure.Repositories.SettingsRepositories;
using Infrastructure.Repositories.TemperaturyRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Temperatury.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITemperaturyRepository, TemperaturyRepository>();
            services.AddScoped<ISensorSettingsRepository, SensorSettingsRepository>();
            return services;
        }
        
        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITemperaturyService, TemperaturyService>();
            services.AddTransient<ISensorsService, SensorsService>();
            return services;
        }
    }
}
