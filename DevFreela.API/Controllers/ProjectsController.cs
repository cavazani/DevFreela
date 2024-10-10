using DevFreela.Application.Models;
using Microsoft.AspNetCore.Mvc;
using DevFreela.Application.Services;
using MediatR;
using DevFreela.Application.Queries.GetAllProject;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.CompleteProject;
using DevFreela.Application.Commands.InsertCommaent;

namespace DevFreela.API.Controllers {
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase 
     {

        private readonly IProjectService _service;
        private readonly IMediator _mediator;
        public ProjectsController(IProjectService service, IMediator mediator) 
        {
            _service = service;
            _mediator = mediator;
        }

        /// <summary>
        /// Api responsavel por filtrar pelo nome do title ou description
        /// </summary>
        /// <param name="search">Termo de busca utilizado para filtrar pelo título ou descrição dos projetos. Se vazio, retorna todos os projetos.</param>
        /// <param name="page">Número da página atual para a paginação. A contagem começa em 0.</param>
        /// <param name="size">Quantidade de itens por página.</param>
        /// <returns>Retorna uma lista de projetos filtrados, com base nos critérios de busca e paginação.</returns>
        [HttpGet]
        public async Task<IActionResult> Get(string search = "") 
        {
           // var result = _service.GetAll();

            var query = new GetAllProjectsQuery();

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET api/projects/1234
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var result = await _mediator.Send(new GetProjectByIdQuery(id));

            if(!result.IsSuccess) 
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // POST api/projects
        [HttpPost]
        public async Task<IActionResult> Post(InsertProjectCommand command) 
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        // PUT api/projects/1234
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProjectCommand command) 
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        //  DELETE api/projects/1234
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var result = await _mediator.Send(new DeleteProjectCommand(id));

            if (!result.IsSuccess) {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // PUT api/projects/1234/start
        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id) 
        {
            var result = await _mediator.Send(new StartProjectCommand(id));

            if (!result.IsSuccess) {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // PUT api/projects/1234/complete
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Complete(int id) 
        {
            var result = await _mediator.Send(new CompleteProjectCommand(id));

            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // POST api/projects/1234/comments
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, InsertCommentCommand command) 
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
