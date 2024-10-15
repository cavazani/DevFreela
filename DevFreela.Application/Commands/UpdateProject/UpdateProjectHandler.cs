using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.UpdateProject {
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, ResultViewModel> 
    {
        private readonly DevFreelaDbContext _context;
        //Utilizando padrão Repository
        private readonly IProjectRepository _repository;
        public UpdateProjectHandler(DevFreelaDbContext context, IProjectRepository repository) 
        {
            _context = context;
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateProjectCommand request, CancellationToken cancellationToken) 
        {
            //var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == request.IdProject);

            //Utilizando padrão Repository
            var project = await _repository.GetById(request.IdProject);

            if (project is null) {
                return ResultViewModel.Error("Projeto não existe.");
            }

            project.Update(request.Title, request.Description, request.TotalCost);

            //Utilizando padrão Repository
            await _repository.Update(project);

            //_context.Projects.Update(project);
            //await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
