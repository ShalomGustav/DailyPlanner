using DailyPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyPlanner.Domain.Configurations
{
    /// <summary>
    /// Конфигурация сущности планировщика
    /// </summary>
    public class PlannerTaskConfiguration : IEntityTypeConfiguration<PlannerTaskEntity>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<PlannerTaskEntity> builder)
        {
            builder.ToTable("PLannerTasks");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasMaxLength(2000);

            builder.Property(x => x.DueDate)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();
        }
    }
}
