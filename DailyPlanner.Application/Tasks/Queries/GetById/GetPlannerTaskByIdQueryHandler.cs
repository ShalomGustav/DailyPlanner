using DailyPlanner.Application.Interfaces;
using DailyPlanner.Application.Models;
using MediatR;

namespace DailyPlanner.Application.Tasks.Queries.GetById
{
    public class GetPlannerTaskByIdQueryHandler : IRequestHandler<GetPlannerTaskByIdQuery, PlannerTaskModel?>
    {
        private readonly IPlannerTaskRepository _plannerTaskRepository;

        public GetPlannerTaskByIdQueryHandler(IPlannerTaskRepository plannerTaskRepository)
        {
            _plannerTaskRepository = plannerTaskRepository;
        }

        public async Task<PlannerTaskModel?> Handle(GetPlannerTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _plannerTaskRepository.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}