using DailyPlanner.Application.Interfaces;
using DailyPlanner.Application.Models;
using MediatR;

namespace DailyPlanner.Application.Tasks.Commands
{
    internal class UpdatePlannerTaskCommandHandler : IRequestHandler<UpdatePlannerTaskCommand, PlannerTaskModel?>
    {
        private readonly IPlannerTaskRepository _plannerTaskRepository;

        public UpdatePlannerTaskCommandHandler(IPlannerTaskRepository plannerTaskRepository)
        {
            _plannerTaskRepository = plannerTaskRepository;
        }

        public async Task<PlannerTaskModel?> Handle(UpdatePlannerTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _plannerTaskRepository.GetByIdAsync(request.Id, cancellationToken);

            if (task == null)
            {
                return null;
            }

            task.Title = request.Title;
            task.Description = request.Description;
            task.DueDate = request.DueDate;

            await _plannerTaskRepository.UpdateAsync(task, cancellationToken);

            return task;
        }
    }
}
