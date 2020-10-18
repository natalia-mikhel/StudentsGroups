using System;
using MediatR;

namespace Domain.UseCases.Students.Commands
{
    public class DeleteStudentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}