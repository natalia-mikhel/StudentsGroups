using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.UseCases.Exceptions;
using MediatR;

namespace Domain.UseCases.Groups.Commands
{
    internal class DeleteGroupCommandHandler : AsyncRequestHandler<DeleteGroupCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteGroupCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        protected override async Task Handle(DeleteGroupCommand command, CancellationToken cancellationToken)
        {
            var group = _dbContext.Groups.FirstOrDefault(x => x.Id == command.Id);
            if (group == null)
            {
                throw new EntityNotFoundException();
            }

            _dbContext.Groups.Remove(group);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}