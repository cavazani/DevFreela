using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllProject {
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, ResultViewModel<List<ProjectItemViewModel>>> 
    {
        private readonly DevFreelaDbContext _context;
        //Utilizando padrão Repository
        private readonly IProjectRepository _repository;
        public GetAllProjectsHandler(DevFreelaDbContext context, IProjectRepository repository) 
        {
            _context = context;
            _repository = repository;
        }
        public async Task<ResultViewModel<List<ProjectItemViewModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken) 
        {
            //var projects = await _context.Projects
            //    .Include(p => p.Client)
            //    .Include(p => p.Freelancer)
            //    .Where(p => !p.IsDeleted)
            //    .ToListAsync();

            //Utilizando padrão Repository
            var projects = await _repository.GetAll();

            var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<ProjectItemViewModel>>.Success(model);
        }
    }
}
