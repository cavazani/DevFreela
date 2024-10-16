using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Queries.GetProjectById {
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectViewModel>> 
    {
        private readonly DevFreelaDbContext _context;

        //Utilizando padrão Repository
        private readonly IProjectRepository _repository;
        public GetProjectByIdHandler(DevFreelaDbContext context, IProjectRepository repository) 
        {
            _context = context;
            _repository = repository;
        }

        public async Task<ResultViewModel<ProjectViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken) 
        {
            //var project = await _context.Projects
            //    .Include(p => p.Client)
            //    .Include(p => p.Freelancer)
            //    .Include(p => p.Comments)
            //    .SingleOrDefaultAsync(p => p.Id == request.Id);

            //Utilizando padrão Repository
            var project = await _repository.GetDetailsById(request.Id);

            if (project == null) 
            {
                return ResultViewModel<ProjectViewModel>.Error("Projeto não existe.");
            }

            var model = ProjectViewModel.FromEntity(project);

            return ResultViewModel<ProjectViewModel>.Success(model);
        }
    }
}
