using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentMgmtCQRS.Application.Commands.CreateStudent;
using StudentMgmtCQRS.Application.Commands.UpdateStudent;
using StudentMgmtCQRS.Application.Commands.DeleteStudent;
using StudentMgmtCQRS.Application.Queries.GetAllStudents;
using StudentMgmtCQRS.Application.Queries.GetStudentById;

namespace StudentMgmtCQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _mediator.Send(new GetAllStudentsQuery()));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { StudentId = id });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateStudentCommand command)
        {
            if (id != command.Id) return BadRequest("ID mismatch.");
            var result = await _mediator.Send(command);
            return result ? Ok("Updated successfully") : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteStudentCommand(id));
            return result ? NoContent() : NotFound();
        }
    }
}
