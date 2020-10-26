using Domain.Enums;

namespace Domain.UseCases.Students.Dto
{
    public class StudentFilterDto
    {
        public Gender? Gender { get; set; }
        
        public string Name { get; set; }
        
        public string Identifier { get; set; }
        
        public string GroupName { get; set; }
        
        public int Page { get; set; }
        
        public int Count { get; set; }
    }
}