using MediatR;

namespace DailyPlanner.Application.Tasks.Commands
{
    public class DeletePlannerTaskCommand : IRequest<bool>
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid Id { get; set; }
    }
}
