using Domain.UseCases.Students.Dto;
using MediatR;

namespace Domain.UseCases.Students.Commands
{
    public class CreateStudentCommand : IRequest
    {
        public CreateStudentDto CreateStudentDto { get; set; }
    }
}