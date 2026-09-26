using DailyPlanner.Application.Models;

namespace DailyPlanner.Domain.Entities
{
    /// <summary>
    /// Сущность задачи планировщика
    /// </summary>
    public class PlannerTaskEntity
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название задачи.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата и время, к которым необходимо выполнить задачу
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Дата и время создания задачи
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Текущий статус задачи
        /// </summary>
        public PlannerTaskStatus Status { get; set; }
    }
}