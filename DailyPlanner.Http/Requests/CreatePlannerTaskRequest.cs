namespace DailyPlanner.Http.Requests
{
    /// <summary>
    /// HTTP-модель запроса на создание задачи планировщика
    /// </summary>
    public class CreatePlannerTaskRequest
    {
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
