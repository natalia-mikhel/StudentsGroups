using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.UseCases.Exceptions;
using MediatR;

namespace Domain.UseCases.Groups.Commands
{
    internal class UpdateGroupCommandHandler : AsyncRequestHandler<UpdateGroupCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateGroupCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        protected override async Task Handle(UpdateGroupCommand command, CancellationToken cancellationToken)
        {
            var group = _mapper.Map<Group>(command.UpdateGroupDto);

            if (_dbContext.Groups.All(x => x.Id != group.Id))
            {
                throw new EntityNotFoundException();
            }
            
            _dbContext.Groups.Update(group);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}