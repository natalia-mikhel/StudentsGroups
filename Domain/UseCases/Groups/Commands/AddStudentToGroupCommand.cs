﻿using Domain.UseCases.Groups.Dto;
using MediatR;

namespace Domain.UseCases.Groups.Commands
{
    public class AddStudentToGroupCommand : IRequest
    {
        public AddStudentToGroupDto AddStudentToGroupDto { get; set; }
    }
}