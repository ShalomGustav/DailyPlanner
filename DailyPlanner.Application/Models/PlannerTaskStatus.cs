namespace DailyPlanner.Application.Models
{
    /// <summary>
    /// Статус задачи планировщика.
    /// </summary>
    public enum PlannerTaskStatus
    {
        /// <summary>
        /// Новая задача.
        /// </summary>
        New = 0,

        /// <summary>
        /// Задача находится в работе.
        /// </summary>
        InProgress = 1,

        /// <summary>
        /// Задача выполнена.
        /// </summary>
        Completed = 2,

        /// <summary>
        /// Задача отменена.
        /// </summary>
        Cancelled = 3
    }
}
