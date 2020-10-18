using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.UseCases.Exceptions;
using MediatR;

namespace Domain.UseCases.Students.Commands
{
    internal class CreateStudentCommandHandler : AsyncRequestHandler<CreateStudentCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        protected override async Task Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(command.CreateStudentDto);

            if (_dbContext.Students.Any(x => x.Identifier != null && x.Identifier == student.Identifier))
            {
                throw new DuplicateUniqueValueException();
            }
            
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}