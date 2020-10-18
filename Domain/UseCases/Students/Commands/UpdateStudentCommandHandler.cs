using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.UseCases.Exceptions;
using MediatR;

namespace Domain.UseCases.Students.Commands
{
    internal class UpdateStudentCommandHandler : AsyncRequestHandler<UpdateStudentCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        protected override async Task Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(command.UpdateStudentDto);

            if (_dbContext.Students.All(x => x.Id != student.Id))
            {
                throw new EntityNotFoundException();
            }
            
            if (_dbContext.Students.Any(x => x.Identifier != null && x.Identifier == student.Identifier && x.Id != student.Id))
            {
                throw new DuplicateUniqueValueException();
            }
            
            _dbContext.Students.Update(student);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}