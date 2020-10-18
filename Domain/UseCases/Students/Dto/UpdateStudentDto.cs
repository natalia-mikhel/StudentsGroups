using System;
using Domain.Enums;

namespace Domain.UseCases.Students.Dto
{
    public class UpdateStudentDto
    {
        public Guid Id { get; set; }
        
        public Gender Gender { get; set; }
        
        public string Surname { get; set; }
        
        public string Name { get; set; }
        
        public string MiddleName { get; set; }
        
        public string Identifier { get; set; }
    }
}