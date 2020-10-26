using System;

namespace Domain.UseCases.Groups.Dto
{
    public class GroupDto
    {
        public Guid Id { get; set; }

        public string GroupName { get; set; }
        
        public int StudentsCount { get; set; }
    }
}