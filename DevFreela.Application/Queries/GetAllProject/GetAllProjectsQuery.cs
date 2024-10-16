using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProject {
    public class GetAllProjectsQuery : IRequest<ResultViewModel<List<ProjectItemViewModel>>>
    {

    }
}
