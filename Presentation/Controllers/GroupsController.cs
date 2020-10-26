using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.UseCases.Groups.Commands;
using Domain.UseCases.Groups.Dto;
using Domain.UseCases.Groups.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET api/groups
        [HttpGet]
        public async Task<ActionResult<List<GroupDto>>> Get([FromQuery] GroupFilterDto groupFilterDto)
        {
            return await _mediator.Send(new GetGroupsQuery() {GroupFilterDto = groupFilterDto});
        }

        // POST api/groups
        [HttpPost]
        public async Task<ActionResult<Unit>> Post([FromBody] CreateGroupDto createGroupDto)
        {
            return await _mediator.Send(new CreateGroupCommand() {CreateGroupDto = createGroupDto});
        }
        
        // PUT api/groups
        [HttpPut]
        public async Task<ActionResult<Unit>> Put([FromBody] UpdateGroupDto updateGroupDto)
        {
            return await _mediator.Send(new UpdateGroupCommand() {UpdateGroupDto = updateGroupDto});
        }
        
        // DELETE api/groups/940D6255-ADB7-4834-736F-08D872C6D334
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteGroupCommand() {Id = id});
        }
        
        // POST api/groups/addStudent
        [HttpPost("addStudent")]
        public async Task<ActionResult<Unit>> AddStudent([FromBody] AddStudentToGroupDto addStudentToGroupDto)
        {
            return await _mediator.Send(new AddStudentToGroupCommand() {AddStudentToGroupDto = addStudentToGroupDto});
        }
        
        // POST api/groups/removeStudent
        [HttpPost("removeStudent")]
        public async Task<ActionResult<Unit>> RemoveStudent([FromBody] RemoveStudentFromGroupDto removeStudentFromGroupDto)
        {
            return await _mediator.Send(new RemoveStudentFromGroupCommand() {RemoveStudentFromGroupDto = removeStudentFromGroupDto});
        }
    }
}