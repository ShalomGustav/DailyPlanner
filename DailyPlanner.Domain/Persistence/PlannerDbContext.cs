using DailyPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyPlanner.Domain.Persistence
{
    /// <summary>
    /// Контекст базы данных планировщика
    /// </summary>
    public class PlannerDbContext : DbContext
    {
        public PlannerDbContext(DbContextOptions<PlannerDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Задачи планировщика
        /// </summary>
        public DbSet<PlannerTaskEntity> PlannerTasks { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlannerDbContext).Assembly);
        }
    }
}