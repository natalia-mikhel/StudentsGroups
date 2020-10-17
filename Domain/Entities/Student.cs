using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities
{
    public class Student
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        [Required]
        public Gender Gender { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string Surname { get; set; }        
        
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        
        [MaxLength(60)]
        public string MiddleName { get; set; }
        
        [MinLength(6)]
        [MaxLength(16)]
        public string Identifier { get; set; }
        
        public List<StudentGroup> StudentGroups { get; set; }
     
        public Student()
        {
            StudentGroups = new List<StudentGroup>();
        }
    }
}