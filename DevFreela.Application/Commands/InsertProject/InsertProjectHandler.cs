using DevFreela.Application.Models;
using DevFreela.Application.Notification.ProjectCreated;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.InsertProject 
{
    public class InsertProjectHandler : IRequestHandler<InsertProjectCommand, ResultViewModel<int>> 
    {
        private readonly DevFreelaDbContext _context;
        private readonly IMediator _mediator;

        //Utilizando padrão Repository
        private readonly IProjectRepository _repository;
        public InsertProjectHandler(DevFreelaDbContext context, IMediator mediator, IProjectRepository repository) 
        {
            _context = context;
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken) 
        {
            var project = request.ToEntity();

            //await _context.Projects.AddAsync(project);
            //_context.SaveChanges();

            //var projectCreated = new ProjectCreatedNotification(project.Id, project.Title, project.TotalCost);
            //await _mediator.Publish(projectCreated);

            //Utilizando padrão Repository
            await _repository.Add(project);

            return ResultViewModel<int>.Success(project.Id);
        }
    }
}
