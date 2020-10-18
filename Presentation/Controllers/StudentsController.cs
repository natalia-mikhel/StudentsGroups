using System;
using System.Threading.Tasks;
using Domain.UseCases.Students.Commands;
using Domain.UseCases.Students.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        // POST api/students
        [HttpPost]
        public async Task<ActionResult<Unit>> Post([FromBody] CreateStudentDto createStudentDto)
        {
            return await _mediator.Send(new CreateStudentCommand() {CreateStudentDto = createStudentDto});
        }
        
        // PUT api/students
        [HttpPut]
        public async Task<ActionResult<Unit>> Put([FromBody] UpdateStudentDto updateStudentDto)
        {
            return await _mediator.Send(new UpdateStudentCommand() {UpdateStudentDto = updateStudentDto});
        }
        
        // DELETE api/students/940D6255-ADB7-4834-736F-08D872C6D334
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteStudentCommand() {Id = id});
        }
    }
}