using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.InsertCommaent {
    public class InsertCommentHandler : IRequestHandler<InsertCommentCommand, ResultViewModel> 
    {
        private readonly DevFreelaDbContext _context;
        //Utilizando padrão Repository
        private readonly IProjectRepository _repository;
        public InsertCommentHandler(DevFreelaDbContext context, IProjectRepository repository) 
        {
            _context = context;
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken) 
        {
            //var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == request.IdProject);

            //Utilizando padrão Repository
            var exists = await _repository.Exists(request.IdProject);

            //if (project is null) {
            //    return ResultViewModel.Error("Projeto não existe.");
            //}

            //Utilizando padrão Repository
            if (!exists) 
            {
                return ResultViewModel.Error("Projeto não existe.");
            }

            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            //Utilizando padrão Repository
            await _repository.AddComment(comment);

            //await _context.ProjectComments.AddAsync(comment);
            //await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
