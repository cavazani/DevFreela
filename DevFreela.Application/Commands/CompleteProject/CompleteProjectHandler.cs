using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CompleteProject {
    public class CompleteProjectHandler : IRequestHandler<CompleteProjectCommand, ResultViewModel> 
    {
        private readonly DevFreelaDbContext _context;
        //Utilizando padrão Repository
        private readonly IProjectRepository _repository;
        public CompleteProjectHandler(DevFreelaDbContext context, IProjectRepository repository) 
        {
            _context = context;
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(CompleteProjectCommand request, CancellationToken cancellationToken) 
        {
            //var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == request.Id);

            //Utilizando padrão Repository
            var project = await _repository.GetById(request.Id);

            if (project is null) 
            {
                return ResultViewModel.Error("Projeto não existe.");
            }

            project.Complete();

            //Utilizando padrão Repository
            await _repository.Update(project);

            //_context.Projects.Update(project);
            //await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
