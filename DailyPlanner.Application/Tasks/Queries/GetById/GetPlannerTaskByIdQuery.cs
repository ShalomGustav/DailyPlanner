using DailyPlanner.Application.Models;
using MediatR;

namespace DailyPlanner.Application.Tasks.Queries.GetById
{
    public class GetPlannerTaskByIdQuery : IRequest<PlannerTaskModel>
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid Id { get; set; }
    }
}