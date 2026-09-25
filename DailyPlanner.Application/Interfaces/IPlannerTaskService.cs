using DailyPlanner.Application.Models;

namespace DailyPlanner.Application.Interfaces
{
    /// <summary>
    /// Предоставляет операции для работы с задачами планировщика.
    /// </summary>
    public interface IPlannerTaskService
    {
        /// <summary>
        /// Создаёт новую задачу
        /// </summary>
        /// <param name="model">Данные для создания задачи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Созданная задача</returns>
        Task<PlannerTaskModel> CreateAsync(
            CreatePlannerTaskModel model,
            CancellationToken cancellationToken = default);
    }
}
