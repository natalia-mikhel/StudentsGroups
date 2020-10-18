using System;

namespace Domain.UseCases.Groups.Dto
{
    public class UpdateGroupDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
    }
}