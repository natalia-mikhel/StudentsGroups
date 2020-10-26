using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.UseCases.Exceptions;
using Domain.UseCases.Students.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Domain.UseCases.Students.Queries
{
    internal class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<StudentDto>>
    {
        private readonly IDbContext _dbContext;

        public GetStudentsQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<StudentDto>> Handle(GetStudentsQuery query, CancellationToken cancellationToken)
        {
            var students = FilterStudents(_dbContext.Students, query.StudentFilterDto);
            var studentDtoList = students.Select(x => new StudentDto()
            {
                Id = x.Id,
                Name = x.Surname + " " + x.Name + (string.IsNullOrEmpty(x.MiddleName) ? string.Empty : " " + x.MiddleName),
                Identifier = x.Identifier,
                Groups = x.StudentGroups.Select(g => g.Group.Name).Join(", ")
            });
            
            return await studentDtoList.ToListAsync();
        }
        
        private IQueryable<Student> FilterStudents(IQueryable<Student> students, StudentFilterDto filter)
        {
            if (filter.Page < 1 || filter.Count < 1)
                throw new IncorrectPaginationValuesException("Page and Count must be positive");

            if (filter.Gender != null)
                students = students.Where(x => x.Gender == filter.Gender);

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                var nameFilter = filter.Name.Trim();
                students = students.Where(x => (x.Surname + " " + x.Name + (string.IsNullOrEmpty(x.MiddleName) ? string.Empty : " " + x.MiddleName)).Contains(nameFilter));
            }

            if (!string.IsNullOrEmpty(filter.Identifier))
                students = students.Where(x => x.Identifier.Contains(filter.Identifier));

            if (!string.IsNullOrEmpty(filter.GroupName))
                students = students.Where(x => x.StudentGroups.Any(g => g.Group.Name.Contains(filter.GroupName)));

            students = students.Skip((filter.Page - 1) * filter.Count).Take(filter.Count);
            
            return students;
        }
    }
}