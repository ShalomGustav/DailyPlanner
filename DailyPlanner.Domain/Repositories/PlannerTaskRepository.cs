using AutoMapper;
using DailyPlanner.Application.Interfaces;
using DailyPlanner.Application.Models;
using DailyPlanner.Domain.Entities;
using DailyPlanner.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DailyPlanner.Domain.Repositories
{
    /// <summary>
    /// Репозиторий задач планировщика
    /// </summary>
    public class PlannerTaskRepository : IPlannerTaskRepository
    {
        private readonly PlannerDbContext _context;
        private readonly IMapper _mapper;

        public PlannerTaskRepository(PlannerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(PlannerTaskModel task, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<PlannerTaskEntity>(task);

            await _context.PlannerTasks.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyCollection<PlannerTaskModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _context.PlannerTasks
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<PlannerTaskModel>>(entities);
        }

        public async Task<PlannerTaskModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.PlannerTasks
                .AsNoTracking()
                .FirstOrDefaultAsync(it => it.Id == id);

            return entity == null ? null : _mapper.Map<PlannerTaskModel>(entity);
        }

        public async Task UpdateAsync(PlannerTaskModel task, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<PlannerTaskEntity>(task);

            _context.PlannerTasks.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.PlannerTasks.FirstOrDefaultAsync(it => it.Id == id, cancellationToken);

            if (entity != null)
            {
                return false;
            }

            _context.PlannerTasks.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
