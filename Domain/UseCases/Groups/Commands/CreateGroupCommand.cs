using Domain.UseCases.Groups.Dto;
using MediatR;

namespace Domain.UseCases.Groups.Commands
{
    public class CreateGroupCommand : IRequest
    {
        public CreateGroupDto CreateGroupDto { get; set; }
    }
}