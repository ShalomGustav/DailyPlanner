using DailyPlanner.Application.Models;
using MediatR;

namespace DailyPlanner.Application.Tasks.Queries.GetAll
{
    public class GetPlannerTasksQuery : IRequest<IReadOnlyCollection<PlannerTaskModel>>
    {
    }
}
