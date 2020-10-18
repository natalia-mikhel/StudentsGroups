using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.UseCases.Exceptions;
using MediatR;

namespace Domain.UseCases.Students.Commands
{
    internal class DeleteStudentCommandHandler : AsyncRequestHandler<DeleteStudentCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteStudentCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        protected override async Task Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
        {
            var student = _dbContext.Students.FirstOrDefault(x => x.Id == command.Id);
            if (student == null)
            {
                throw new EntityNotFoundException();
            }

            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}