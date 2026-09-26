using AutoMapper;
using DailyPlanner.Application.Models;
using DailyPlanner.Domain.Entities;

namespace DailyPlanner.Domain.Mappers
{
    /// <summary>
    /// Профиль преобразования моделей и сущностей задач планировщика.
    /// </summary>
    public class PlannerTaskMappingProfile : Profile
    {
        public PlannerTaskMappingProfile()
        {
            CreateMap<PlannerTaskModel, PlannerTaskEntity>();
            CreateMap<PlannerTaskEntity, PlannerTaskModel>();
        }
    }
}
