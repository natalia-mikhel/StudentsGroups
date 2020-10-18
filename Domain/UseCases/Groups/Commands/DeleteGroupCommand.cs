using System;
using MediatR;

namespace Domain.UseCases.Groups.Commands
{
    public class DeleteGroupCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}