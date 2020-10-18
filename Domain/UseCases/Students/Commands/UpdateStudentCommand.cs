using Domain.UseCases.Students.Dto;
using MediatR;

namespace Domain.UseCases.Students.Commands
{
    public class UpdateStudentCommand : IRequest
    {
        public UpdateStudentDto UpdateStudentDto { get; set; }
    }
}