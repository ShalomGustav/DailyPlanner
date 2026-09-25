namespace DailyPlanner.Application.Models
{
    /// <summary>
    /// Модель создания задачи планировщика
    /// </summary>
    public class CreatePlannerTaskModel
    {
        /// <summary>
        /// Название задачи
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата и время, к которым необходимо выполнить задачу
        /// </summary>
        public DateTime DueDate { get; set; }
    }
}
