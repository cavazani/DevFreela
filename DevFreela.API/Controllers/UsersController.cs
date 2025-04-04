﻿using DevFreela.Core.Entities;
using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Controllers 
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase 
    {
        private readonly DevFreelaDbContext _context;
        public UsersController(DevFreelaDbContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Filtrar o usuario com base no parametro Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var user = _context.Users
                .Include(u => u.Skills)
                    .ThenInclude(u => u.Skill)
                .SingleOrDefault(u => u.Id == id);

            if (user is null) 
            {
                return NotFound();
            }

            var model = UserViewModel.FromEntity(user);

            return Ok(model);
        }

        /// <summary>
        /// Cria novo usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(CreateUserInputModel model) 
        {
            var user = new User(model.FullName, model.Email, model.BirthDate);

            _context.Users.Add(user);
            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Adiciona e associa skill ao usuario criado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{id}/skills")]
        public IActionResult PostSkills(int id, UserSkillsInputModel model) 
        {
            var userSkills = model.SkillIds.Select(s => new UserSkill(id, s)).ToList();

            _context.UserSkills.AddRange(userSkills);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(int id, IFormFile file) 
        {
            var description = $"FIle: {file.FileName}, Size: {file.Length}";

            // Processar a imagem

            return Ok(description);
        }
    }
}
