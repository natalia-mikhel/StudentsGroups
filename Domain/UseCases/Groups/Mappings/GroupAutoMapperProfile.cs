using AutoMapper;
using Domain.Entities;
using Domain.UseCases.Groups.Dto;

namespace Domain.UseCases.Groups.Mappings
{
    public class GroupAutoMapperProfile : Profile
    {
        public GroupAutoMapperProfile()
        {
            CreateMap<CreateGroupDto, Group>();
            CreateMap<UpdateGroupDto, Group>();
            CreateMap<AddStudentToGroupDto, StudentGroup>();
        }
    }
}