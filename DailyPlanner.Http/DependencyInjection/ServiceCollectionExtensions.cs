using Microsoft.Extensions.DependencyInjection;

namespace DailyPlanner.Http.DependencyInjection
{
    /// <summary>
    /// Методы расширения для регистрации зависимостей HTTP-слоя
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHttp(this IServiceCollection services)
        {
            services.AddControllers().AddApplicationPart(typeof(ServiceCollectionExtensions).Assembly);

            return services;
        }
    }
}
