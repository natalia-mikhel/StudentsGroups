using Domain.Enums;

namespace Domain.UseCases.Students.Dto
{
    public class CreateStudentDto
    {
        public Gender Gender { get; set; }
        
        public string Surname { get; set; }
        
        public string Name { get; set; }
        
        public string MiddleName { get; set; }
        
        public string Identifier { get; set; }
    }
}