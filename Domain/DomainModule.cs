using MediatR;
using Domain.UseCases.Students.Commands;
using Microsoft.Extensions.DependencyInjection;
using Utils.Modules;

namespace Domain
{
    public class DomainModule: Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateStudentCommandHandler));
        }
    }
}