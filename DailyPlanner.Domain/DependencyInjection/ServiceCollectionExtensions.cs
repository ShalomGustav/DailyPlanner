using DailyPlanner.Application.Interfaces;
using DailyPlanner.Domain.Mappers;
using DailyPlanner.Domain.Persistence;
using DailyPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DailyPlanner.Domain.DependencyInjection
{
    /// <summary>
    /// Методы расширения для регистрации зависимостей слоя Domain.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Регистрирует зависимости слоя Domain
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="configuration">Конфигурация приложения</param>
        /// <returns>Коллекция сервисов с зарегистрированными зависимостями</returns>
        public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PlannerDbContext>(it => it.UseSqlServer(connectionString));

            services.AddAutoMapper(it => { }, typeof(PlannerTaskMappingProfile).Assembly);

            services.AddScoped<IPlannerTaskRepository, PlannerTaskRepository>();

            return services;
        }
    }
}
