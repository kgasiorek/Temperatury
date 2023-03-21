using Application.Interfaces.Repository;
using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Temperatury.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITemperaturyRepository, TemperaturyRepository>();
            return services;
        }
        
        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITemperaturyService, TemperaturyService>();
            return services;
        }
    }
}
