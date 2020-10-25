using System;

namespace Domain.UseCases.Groups.Dto
{
    public class RemoveStudentFromGroupDto
    {
        public Guid GroupId { get; set; }
        
        public Guid StudentId { get; set; }
    }
}