using Domain.UseCases.Groups.Dto;
using MediatR;

namespace Domain.UseCases.Groups.Commands
{
    public class UpdateGroupCommand : IRequest
    {
        public UpdateGroupDto UpdateGroupDto { get; set; }
    }
}