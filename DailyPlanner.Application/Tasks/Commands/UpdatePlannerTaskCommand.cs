using DailyPlanner.Application.Models;
using MediatR;

namespace DailyPlanner.Application.Tasks.Commands
{
    public class UpdatePlannerTaskCommand : IRequest<PlannerTaskModel>
    {
        /// <summary>
        /// Идентификатор задачи.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название задачи.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Описание задачи.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Дата и время выполнения задачи.
        /// </summary>
        public DateTime DueDate { get; set; }
    }
}
