using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.UseCases.Exceptions;
using MediatR;

namespace Domain.UseCases.Groups.Commands
{
    internal class RemoveStudentFromGroupCommandHandler : AsyncRequestHandler<RemoveStudentFromGroupCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public RemoveStudentFromGroupCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        protected override async Task Handle(RemoveStudentFromGroupCommand command, CancellationToken cancellationToken)
        {
            var studentGroup = _dbContext.StudentGroups.FirstOrDefault(x =>
                x.StudentId == command.RemoveStudentFromGroupDto.StudentId &&
                x.GroupId == command.RemoveStudentFromGroupDto.GroupId);

            if (studentGroup == null)
            {
                throw new EntityNotFoundException();
            }

            _dbContext.StudentGroups.Remove(studentGroup);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}