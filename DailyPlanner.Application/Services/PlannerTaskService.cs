using DailyPlanner.Application.Interfaces;
using DailyPlanner.Application.Models;

namespace DailyPlanner.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class PlannerTaskService : IPlannerTaskService
    {
        private readonly IPlannerTaskRepository _plannerTaskRepository;

        public PlannerTaskService(IPlannerTaskRepository plannerTaskRepository)
        {
            _plannerTaskRepository = plannerTaskRepository;
        }

        /// <summary>
        /// Создаёт новую задачу
        /// </summary>
        /// <param name="model">Данные для создания задачи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Созданная задача</returns>
        public async Task<PlannerTaskModel> CreateAsync(
            CreatePlannerTaskModel model,
            CancellationToken cancellationToken = default)
        {
            var task = new PlannerTaskModel
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                CreatedAt = DateTime.UtcNow,
                Status = PlannerTaskStatus.New
            };

            await _plannerTaskRepository.AddAsync(task, cancellationToken);

            return task;
        }
    }
}
