using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.UseCases.Exceptions;
using MediatR;

namespace Domain.UseCases.Groups.Commands
{
    internal class AddStudentToGroupCommandHandler : AsyncRequestHandler<AddStudentToGroupCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddStudentToGroupCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        protected override async Task Handle(AddStudentToGroupCommand command, CancellationToken cancellationToken)
        {
            var studentGroup = _mapper.Map<StudentGroup>(command.AddStudentToGroupDto);

            if (_dbContext.StudentGroups.Any(x =>
                x.StudentId == studentGroup.StudentId && x.GroupId == studentGroup.GroupId))
            {
                throw new DuplicateException("This student is already in this group.");
            }

            _dbContext.StudentGroups.Add(studentGroup);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}