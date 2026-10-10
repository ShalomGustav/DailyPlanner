using DailyPlanner.Application.Interfaces;
using DailyPlanner.Application.Models;
using DailyPlanner.Application.Services;
using DailyPlanner.Application.Tasks.Commands;
using DailyPlanner.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DailyPlanner.Application.DependencyInjection
{
    /// <summary>
    /// Методы расширения для регистрации зависимостей слоя Application
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Регистрирует зависимости слоя Application
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <returns>Коллекция сервисов с зарегистрированными зависимостями</returns>
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddScoped<IPlannerTaskService, PlannerTaskService>();
            services.AddScoped<IValidator<CreatePlannerTaskModel>, CreatePlannerTaskValidator>();
            services.AddMediatR(it => it.RegisterServicesFromAssemblies(typeof(CreatePlannerTaskCommand).Assembly));

            return services;
        }
    }
}