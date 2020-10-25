using Domain.UseCases.Groups.Dto;
using MediatR;

namespace Domain.UseCases.Groups.Commands
{
    public class RemoveStudentFromGroupCommand : IRequest
    {
        public RemoveStudentFromGroupDto RemoveStudentFromGroupDto { get; set; }
    }
}