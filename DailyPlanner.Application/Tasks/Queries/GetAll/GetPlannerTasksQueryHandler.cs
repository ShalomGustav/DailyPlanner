using DailyPlanner.Application.Interfaces;
using DailyPlanner.Application.Models;
using MediatR;

namespace DailyPlanner.Application.Tasks.Queries.GetAll
{
    public class GetPlannerTasksQueryHandler : IRequestHandler<GetPlannerTasksQuery, IReadOnlyCollection<PlannerTaskModel>>
    {
        private readonly IPlannerTaskRepository _plannerTaskRepository;

        public GetPlannerTasksQueryHandler(IPlannerTaskRepository plannerTaskRepository)
        {
            _plannerTaskRepository = plannerTaskRepository;
        }

        public async Task<IReadOnlyCollection<PlannerTaskModel>> Handle(GetPlannerTasksQuery request, CancellationToken cancellationToken)
            => await _plannerTaskRepository.GetAllAsync(cancellationToken);
    }
}
