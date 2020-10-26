using System.Collections.Generic;
using Domain.UseCases.Students.Dto;
using MediatR;

namespace Domain.UseCases.Students.Queries
{
    public class GetStudentsQuery : IRequest<List<StudentDto>>
    {
        public StudentFilterDto StudentFilterDto { get; set; }
    }
}