using DailyPlanner.Application.Models;
using MediatR;

namespace DailyPlanner.Application.Tasks.Commands
{
    /// <summary>
    /// Команда создания задачи планировщика
    /// </summary>
    public class CreatePlannerTaskCommand : IRequest<PlannerTaskModel>
    {
        /// <summary>
        /// Название задачи
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Дата и время, к которым необходимо выполнить задачу
        /// </summary>
        public DateTime DueDate { get; set; }
    }
}
