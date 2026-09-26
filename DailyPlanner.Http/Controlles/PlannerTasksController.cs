using DailyPlanner.Application.Interfaces;
using DailyPlanner.Application.Models;
using DailyPlanner.Http.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DailyPlanner.Http.Controlles
{
    [ApiController]
    [Route("api/tasks")]
    public class PlannerTasksController : ControllerBase
    {
        private readonly IPlannerTaskService _plannerTaskService;

        public PlannerTasksController(IPlannerTaskService plannerTaskService)
        {
            _plannerTaskService = plannerTaskService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyCollection<PlannerTaskModel>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var tasks = await _plannerTaskService.GetAllAsync(cancellationToken);

            if (tasks == null)
            {
                return NotFound();
            }

            return Ok(tasks);
        }

        [HttpPost]
        public async Task<ActionResult<PlannerTaskModel>> CreateAsync(
            CreatePlannerTaskRequest request,
            CancellationToken cancellationToken)
        {
            var model = new CreatePlannerTaskModel
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate
            };

            var task = await _plannerTaskService.CreateAsync(model, cancellationToken);

            return Ok(task);
        }

    }
}
