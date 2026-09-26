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

        /// <summary>
        /// Возвращает все задачи планировщика
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список задач планировщика.</returns>
        Task<IReadOnlyCollection<PlannerTaskModel>> GetAllAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Возвращает задачу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Найденная задача или null, если задача отсутствует</returns>
        Task<PlannerTaskModel?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Изменяет статус задачи планировщика
        /// </summary>
        /// <param name="model">Модель изменения статуса задачи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Задача с обновлённым статусом или null, если задача не найдена</returns>
        Task<PlannerTaskModel?> ChangeStatusAsync(
            ChangePlannerTaskStatusModel model,
            CancellationToken cancellationToken = default);
    }
}
