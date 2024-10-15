using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.DeleteProject {
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, ResultViewModel> 
    {
        private readonly DevFreelaDbContext _context;
        //Utilizando padrão Repository
        private readonly IProjectRepository _repository;
        public DeleteProjectHandler(DevFreelaDbContext context, IProjectRepository repository) 
        {
            _context = context;
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteProjectCommand request, CancellationToken cancellationToken) 
        {
            //var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == request.Id);

            //Utilizando padrão Repository
            var project = await _repository.GetById(request.Id);

            if (project is null) {
                return ResultViewModel.Error("Projeto não existe.");
            }

            project.SetAsDeleted();

            //Utilizando padrão Repository
            await _repository.Update(project);

            //_context.Projects.Update(project);
            //_context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
