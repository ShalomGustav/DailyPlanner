using DailyPlanner.Application.Interfaces;
using DailyPlanner.Application.Models;
using MediatR;

namespace DailyPlanner.Application.Tasks.Commands
{
    public class ChangePlannerTaskStatusCommandHandler : IRequestHandler<ChangePlannerTaskStatusCommand, PlannerTaskModel>
    {
        private readonly IPlannerTaskRepository _plannerTaskRepository;

        public ChangePlannerTaskStatusCommandHandler(IPlannerTaskRepository plannerTaskRepository)
        {
            _plannerTaskRepository = plannerTaskRepository;
        }

        /// <summary>
        /// Меняем статус задачи
        /// </summary>
        /// <param name="request">Команда изменения</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Измененная задача</returns>
        public async Task<PlannerTaskModel> Handle(ChangePlannerTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await _plannerTaskRepository.GetByIdAsync(request.Id, cancellationToken);

            if (task == null)
            {
                return null;
            }

            task.Status = request.Status;

            await _plannerTaskRepository.UpdateAsync(task, cancellationToken);

            return task;
        }
    }
}
