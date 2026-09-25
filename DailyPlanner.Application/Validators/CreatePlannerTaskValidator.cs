using DailyPlanner.Application.Models;
using FluentValidation;

namespace DailyPlanner.Application.Validators
{
    /// <summary>
    /// Валидатор модели создания задачи планировщика.
    /// </summary>
    public class CreatePlannerTaskValidator : AbstractValidator<CreatePlannerTaskModel>
    {
        public CreatePlannerTaskValidator()
        {
            RuleFor(x => x.Title)
               .NotEmpty()
               .WithMessage("Название задачи обязательно.")
               .MaximumLength(200)
               .WithMessage("Название задачи не должно превышать 200 символов.");

            RuleFor(x => x.Description)
                .MaximumLength(2000)
                .WithMessage("Описание задачи не должно превышать 2000 символов.");

            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("Дата выполнения задачи должна быть в будущем.");
        }
    }
}
