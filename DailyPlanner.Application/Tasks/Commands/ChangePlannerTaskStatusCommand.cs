using DailyPlanner.Application.Models;
using MediatR;

namespace DailyPlanner.Application.Tasks.Commands
{
    public class ChangePlannerTaskStatusCommand : IRequest<PlannerTaskModel>
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Новый статус задачи
        /// </summary>
        public PlannerTaskStatus Status { get; set; }
    }
}
