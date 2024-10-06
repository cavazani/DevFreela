using DevFreela.Application.Models;
using Microsoft.AspNetCore.Mvc;
using DevFreela.Application.Services;

namespace DevFreela.API.Controllers {
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase 
     {

        private readonly IProjectService _service;
        public ProjectsController(IProjectService service) 
        {
            _service = service;
        }

        /// <summary>
        /// Api responsavel por filtrar pelo nome do title ou description
        /// </summary>
        /// <param name="search">Termo de busca utilizado para filtrar pelo título ou descrição dos projetos. Se vazio, retorna todos os projetos.</param>
        /// <param name="page">Número da página atual para a paginação. A contagem começa em 0.</param>
        /// <param name="size">Quantidade de itens por página.</param>
        /// <returns>Retorna uma lista de projetos filtrados, com base nos critérios de busca e paginação.</returns>
        [HttpGet]
        public IActionResult Get(string search = "", int page = 0, int size = 3) 
        {
            var result = _service.GetAll();

            return Ok(result);
        }

        // GET api/projects/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var result = _service.GetById(id);

            if(!result.IsSuccess) 
            {
                return BadRequest(result);
            }


            return Ok(result);
        }

        // POST api/projects
        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model) 
        {
            var result = _service.Insert(model); 

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        // PUT api/projects/1234
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectInputModel model) 
        {
            var result = _service.Update(model);

            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        //  DELETE api/projects/1234
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var result = _service.Delete(id);

            if (!result.IsSuccess) {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // PUT api/projects/1234/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id) 
        {
            var result = _service.Start(id);

            if (!result.IsSuccess) {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // PUT api/projects/1234/complete
        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id) 
        {
            var result = _service.Complete(id);

            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // POST api/projects/1234/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateProjectCommentInputModel model) 
        {
            var result = _service.InsertComment(id, model);

            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
