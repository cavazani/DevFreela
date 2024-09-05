﻿using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers {

    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase {

        private readonly FreelanceTotalCostConfig _config;

        public ProjectsController(IOptions<FreelanceTotalCostConfig> options) 
        {
            _config = options.Value;
        }




        // GET api/projects?search=crm
        [HttpGet]
        public IActionResult Get(string search) {
            return Ok();
        }

        // GET api/projects/12345
        [HttpGet("{id}")]
        public IActionResult GetById() {
            return Ok();
        }

        // POST api/projects
        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model) 
        {
            if(model.TotalCost < _config.Minimum || model.TotalCost > _config.Maximum) 
            { 
                return BadRequest("numero fora do limites.");
            }
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        //PUT api/projects/1234
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectInputModel model) 
        {
            return NoContent();
        }

        //DELETE api/projects/1234
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            return NoContent();
        }

        //PUT api/projects/1234/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id) 
        {
            return NoContent();
        }

        //PUT api/projects/1234/complete
        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id) {
            return NoContent();
        }

        // POST api/projects/1234/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateProjectInputModel model)
        {
            return Ok();
        }

    }
}
