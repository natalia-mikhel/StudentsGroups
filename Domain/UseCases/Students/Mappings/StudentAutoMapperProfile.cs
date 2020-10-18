using AutoMapper;
using Domain.Entities;
using Domain.UseCases.Students.Dto;

namespace Domain.UseCases.Students.Mappings
{
    public class StudentAutoMapperProfile : Profile
    {
        public StudentAutoMapperProfile()
        {
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
        }
    }
}