using System;

namespace Domain.UseCases.Groups.Dto
{
    public class AddStudentToGroupDto
    {
        public Guid GroupId { get; set; }
        
        public Guid StudentId { get; set; }
    }
}