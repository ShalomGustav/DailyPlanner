using DailyPlanner.Application.Models;
using DailyPlanner.Application.Tasks.Commands;
using DailyPlanner.Application.Tasks.Queries.GetAll;
using DailyPlanner.Application.Tasks.Queries.GetById;
using DailyPlanner.Http.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DailyPlanner.Http.Controlles
{
    [ApiController]
    [Route("api/tasks")]
    public class PlannerTasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlannerTasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PlannerTaskModel>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetPlannerTaskByIdQuery
            {
                Id = id
            };

            var task = await _mediator.Send(query, cancellationToken);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<PlannerTaskModel>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = new GetPlannerTasksQuery();

            var tasks = await _mediator.Send(query, cancellationToken);

            return Ok(tasks);
        }

        [HttpPost]
        public async Task<ActionResult<PlannerTaskModel>> CreateAsync(
            CreatePlannerTaskRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreatePlannerTaskCommand
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate
            };

            var task = await _mediator.Send(command, cancellationToken);

            return Ok(task);
        }

        [HttpPatch("{id:guid}/status")]
        public async Task<ActionResult<PlannerTaskModel>> ChangeStatusAsync(
            Guid id,
            ChangePlannerTaskStatusRequest request,
            CancellationToken cancellationToken)
        {
            var command = new ChangePlannerTaskStatusCommand
            {
                Id = id,
                Status = request.Status,
            };

            var task = await _mediator.Send(command, cancellationToken);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<PlannerTaskModel>> UpdateAsync(
            Guid id,
            UpdatePlannerTaskRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdatePlannerTaskCommand
            {
                Id = id,
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate
            };

            var task = await _mediator.Send(command, cancellationToken);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeletePlannerTaskCommand
            {
                Id = id,
            };

            var deleted = await _mediator.Send(command, cancellationToken);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}