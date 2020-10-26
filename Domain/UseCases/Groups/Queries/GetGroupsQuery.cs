using System.Collections.Generic;
using Domain.UseCases.Groups.Dto;
using MediatR;

namespace Domain.UseCases.Groups.Queries
{
    public class GetGroupsQuery : IRequest<List<GroupDto>>
    {
        public GroupFilterDto GroupFilterDto { get; set; }
    }
}