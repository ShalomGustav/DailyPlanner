using DailyPlanner.Application.Interfaces;
using MediatR;

namespace DailyPlanner.Application.Tasks.Commands
{
    public class DeletePlannerTaskCommandHandler : IRequestHandler<DeletePlannerTaskCommand, bool>
    {
        private readonly IPlannerTaskRepository _plannerTaskRepository;

        public DeletePlannerTaskCommandHandler(IPlannerTaskRepository plannerTaskRepository)
        {
            _plannerTaskRepository = plannerTaskRepository;
        }

        public async Task<bool> Handle(DeletePlannerTaskCommand request, CancellationToken cancellationToken)
            => await _plannerTaskRepository.DeleteAsync(request.Id, cancellationToken);
    }
}
