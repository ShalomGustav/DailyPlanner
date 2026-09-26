using System;
using System.Collections.Generic;
using System.Text;

namespace DailyPlanner.Application.Models
{
    /// <summary>
    /// Модель изменения статуса задачи
    /// </summary>
    public class ChangePlannerTaskStatusModel
    {
        /// <summary>
        /// Идентификатор задач
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Новый статус задачи
        /// </summary>
        public PlannerTaskStatus Status { get; set; }
    }
}
