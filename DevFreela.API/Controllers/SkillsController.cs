using DevFreela.Core.Entities;
using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers 
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase 
    {
        private readonly DevFreelaDbContext _context;
        public SkillsController(DevFreelaDbContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Filtrar todos os skill criados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() 
        {
            var skills = _context.Skills.ToList();

            return Ok(skills);
        }

        /// <summary>
        /// Adiciona novo skill
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(CreateSkillInputModel model) 
        {
            var skill = new Skill(model.Description);

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
