using DailyPlanner.Application.Interfaces;
using DailyPlanner.Application.Models;
using MediatR;

namespace DailyPlanner.Application.Tasks.Commands
{
    /// <summary>
    /// Команда создания задачи планировщика
    /// </summary>
    public class CreatePlannerTaskCommandHandler : IRequestHandler<CreatePlannerTaskCommand, PlannerTaskModel>
    {
        private readonly IPlannerTaskRepository _plannerTaskRepository;

        public CreatePlannerTaskCommandHandler(IPlannerTaskRepository plannerTaskRepository)
        {
            _plannerTaskRepository = plannerTaskRepository;
        }

        public async Task<PlannerTaskModel> Handle(CreatePlannerTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new PlannerTaskModel
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                CreatedAt = DateTime.Now,
                Status = PlannerTaskStatus.New
            };

            await _plannerTaskRepository.AddAsync(task, cancellationToken);

            return task;
        }
    }
}
