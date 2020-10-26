using System;

namespace Domain.UseCases.Students.Dto
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Identifier { get; set; }
        
        public string Groups { get; set; }
    }
}