using DailyPlanner.Application.Interfaces;
using DailyPlanner.Application.Models;
using FluentValidation;

namespace DailyPlanner.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class PlannerTaskService : IPlannerTaskService
    {
        private readonly IPlannerTaskRepository _plannerTaskRepository;
        private readonly IValidator<CreatePlannerTaskModel> _validator;

        public PlannerTaskService(IPlannerTaskRepository plannerTaskRepository, IValidator<CreatePlannerTaskModel> validator)
        {
            _plannerTaskRepository = plannerTaskRepository;
            _validator = validator;
        }

        public Task<PlannerTaskModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _plannerTaskRepository.GetByIdAsync(id, cancellationToken);
        }

        public Task<IReadOnlyCollection<PlannerTaskModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _plannerTaskRepository.GetAllAsync(cancellationToken);
        }

        public async Task<PlannerTaskModel?> ChangeStatusAsync(
            ChangePlannerTaskStatusModel model,
            CancellationToken cancellationToken = default)
        {
            var task = await _plannerTaskRepository.GetByIdAsync(model.Id, cancellationToken);

            if (task == null)
            {
                return null;
            }

            task.Status = model.Status;

            await _plannerTaskRepository.UpdateAsync(task, cancellationToken);

            return task;
        }

        public async Task<PlannerTaskModel> CreateAsync(
            CreatePlannerTaskModel model,
            CancellationToken cancellationToken = default)
        {
            await _validator.ValidateAndThrowAsync(model, cancellationToken);

            var task = new PlannerTaskModel
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                CreatedAt = DateTime.Now,
                Status = PlannerTaskStatus.New
            };

            await _plannerTaskRepository.AddAsync(task, cancellationToken);

            return task;
        }

        public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _plannerTaskRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task<PlannerTaskModel?> UpdateAsync(
            UpdatePlannerTaskModel model,
            CancellationToken cancellationToken = default)
        {
            var task = await _plannerTaskRepository.GetByIdAsync(model.Id, cancellationToken);

            if (task == null)
            {
                return null;
            }

            task.Title = model.Title;
            task.Description = model.Description;
            task.DueDate = model.DueDate;

            await _plannerTaskRepository.UpdateAsync(task, cancellationToken);

            return task;
        }
    }
}
