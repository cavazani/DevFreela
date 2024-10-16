using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.StartProject {
    public class StartProjectHandler : IRequestHandler<StartProjectCommand, ResultViewModel> 
    {
        private readonly DevFreelaDbContext _context;
        //Utilizando padrão Repository
        private readonly IProjectRepository _repository;
        public StartProjectHandler(DevFreelaDbContext context, IProjectRepository repository) 
        {
            _context = context;
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(StartProjectCommand request, CancellationToken cancellationToken) 
        {
            //var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == request.Id);

            //Utilizando padrão Repository
            var project = await _repository.GetById(request.Id);

            if (project is null) {
                return ResultViewModel.Error("Projeto não existe.");
            }

            project.Start();

            //Utilizando padrão Repository
            await _repository.Update(project);

            //_context.Projects.Update(project);
            //await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
