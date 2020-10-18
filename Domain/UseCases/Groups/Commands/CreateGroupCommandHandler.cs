using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Domain.UseCases.Groups.Commands
{
    internal class CreateGroupCommandHandler: AsyncRequestHandler<CreateGroupCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGroupCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        protected override async Task Handle(CreateGroupCommand command, CancellationToken cancellationToken)
        {
            var group = _mapper.Map<Group>(command.CreateGroupDto);

            _dbContext.Groups.Add(group);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}