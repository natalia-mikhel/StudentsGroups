using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.UseCases.Exceptions;
using Domain.UseCases.Groups.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Domain.UseCases.Groups.Queries
{
    internal class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, List<GroupDto>>
    {
        private readonly IDbContext _dbContext;

        public GetGroupsQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<GroupDto>> Handle(GetGroupsQuery query, CancellationToken cancellationToken)
        {
            var students = FilterGroups(_dbContext.Groups, query.GroupFilterDto);
            var studentDtoList = students.Select(x => new GroupDto()
            {
                Id = x.Id,
                GroupName = x.Name,
                StudentsCount = x.StudentGroups.Count
            });
            
            return await studentDtoList.ToListAsync();
        }
        
        private IQueryable<Group> FilterGroups(IQueryable<Group> groups, GroupFilterDto filter)
        {
            if (filter.Page < 1 || filter.Count < 1)
                throw new IncorrectPaginationValuesException("Page and Count must be positive");

            if (!string.IsNullOrEmpty(filter.Name))
                groups = groups.Where(x => x.Name.Contains(filter.Name));
            
            groups = groups.Skip((filter.Page - 1) * filter.Count).Take(filter.Count);
            
            return groups;
        }
    }
}