using DailyPlanner.Application.Models;

namespace DailyPlanner.Application.Interfaces
{
    /// <summary>
    /// Предоставляет операции для работы с хранилищем задач планировщика.
    /// </summary>
    public interface IPlannerTaskRepository
    {
        /// <summary>
        /// Добавляет новую задачу
        /// </summary>
        /// <param name="task">Добавляемая задача</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Задача</returns>
        Task AddAsync(PlannerTaskModel task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Возвращает задачу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Найденная задача</returns>
        Task<PlannerTaskModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Возвращает список всех задач
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список задач</returns>
        Task<IReadOnlyCollection<PlannerTaskModel>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
