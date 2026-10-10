namespace DailyPlanner.Http.Requests
{
    /// <summary>
    /// Запрос на изменение задачи планировщика
    /// </summary>
    public class UpdatePlannerTaskRequest
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Дата и время, к которым необходимо выполнить задачу
        /// </summary>
        public DateTime DueDate { get; set; }
    }
}
