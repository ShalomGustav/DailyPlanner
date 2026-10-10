using DailyPlanner.Application.Models;

namespace DailyPlanner.Http.Requests
{
    /// <summary>
    /// Запрос на изменение статуса задачи планировщика
    /// </summary>
    public class ChangePlannerTaskStatusRequest
    {
        /// <summary>
        /// Новый статус задачи
        /// </summary>
        public PlannerTaskStatus Status { get; set; }
    }
}
